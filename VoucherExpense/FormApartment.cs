//#define UseSQLServer
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VoucherExpense
{
    public partial class FormApartment : Form
    {
        public FormApartment()
        {
            InitializeComponent();
        }


        const string Key = "LordAlex";
        string[] ColumnsEncryted = new string[] {"LocalServerIP","DatabaseName"         ,"LocalUserID","LocalPassword",
                                                 "CloudServerIP","CloudSharedDatabase"  ,"CloudUserID","CloudPassword"};
        void CopyDecryptApartment(DamaiDataSet.ApartmentRow enc, DamaiDataSet.ApartmentRow dec)
        {
            dec.ApartmentID      = enc.ApartmentID;
            if (!enc.IsApartmentAllNameNull()) dec.ApartmentAllName = enc.ApartmentAllName;
            if (!enc.IsApartmentNameNull())    dec.ApartmentName    = enc.ApartmentName;
            if (!enc.IsAppartementCodeNull())  dec.AppartementCode  = enc.AppartementCode;
            DataRow encR = (DataRow)enc;
            DataRow decR = (DataRow)dec;
            foreach(string col in ColumnsEncryted)  // 這種寫法不檢查 IsNull, 所以這欄不准Null
            {
                try
                {
                    if (encR[col].ToString() == "") { decR[col] = ""; continue; }
                    byte[] buf = Encoder.RC2Decrypt(Convert.FromBase64String(encR[col].ToString()), Key);
                    decR[col] = Encoding.Unicode.GetString(buf);
                }
                catch(Exception ex){ } // 資料有問題不處理
            }
        }

        DamaiDataSet decryptedDataSet = new DamaiDataSet();
        private void FormApartment_Load(object sender, EventArgs e)
        {
            try
            {
                this.apartmentSQLAdapter.Fill(this.damaiDataSet.Apartment);
                foreach (var encryptedRow in damaiDataSet.Apartment)
                {
                    var decryptedRow=decryptedDataSet.Apartment.NewApartmentRow();
                    CopyDecryptApartment(encryptedRow, decryptedRow);
                    decryptedDataSet.Apartment.AddApartmentRow(decryptedRow);
                }
                decryptedDataSet.Apartment.AcceptChanges();
                this.apartmentBindingSource.DataSource = decryptedDataSet;
                MyFunction.SetFieldLength(apartmentDataGridView, damaiDataSet.Apartment);
            }
            catch (Exception ex)
            {
                MessageBox.Show("讀取部門資料庫錯誤:" + ex.Message);
            }
        }

        void EncryptCopyApartment(DamaiDataSet.ApartmentRow plainRow, DamaiDataSet.ApartmentDataTable encryptedTable)
        {
            var row=encryptedTable.FindByApartmentID(plainRow.ApartmentID);
            bool isNew = (row==null);
            if (isNew)
            {
                row = encryptedTable.NewApartmentRow();
                row.ApartmentID = plainRow.ApartmentID;
            }
            if (!plainRow.IsApartmentAllNameNull()) row.ApartmentAllName = plainRow.ApartmentAllName;
            if (!plainRow.IsApartmentNameNull())    row.ApartmentName    = plainRow.ApartmentName;
            if (!plainRow.IsAppartementCodeNull())  row.AppartementCode  = plainRow.AppartementCode;
            DataRow encR = (DataRow)row;
            DataRow plainR = (DataRow)plainRow;
            foreach (string col in ColumnsEncryted)  // 這種寫法不檢查 IsNull, 所以這欄不准Null
            {
                try
                {
                    string str = plainR[col].ToString().Trim();
                    if (str == "") { encR[col] = ""; continue; }
                    byte[] buf=Encoder.RC2Encrypt(Encoding.Unicode.GetBytes(str),Key);
                    encR[col] = Convert.ToBase64String(buf);
                }
                catch (Exception ex) { } // 資料有問題不處理
            }
            if (isNew) encryptedTable.AddApartmentRow(row);
        }

        private void apartmentBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.apartmentBindingSource.EndEdit();
            var decryptedTable=(DamaiDataSet.ApartmentDataTable)decryptedDataSet.Apartment.GetChanges();
            foreach (DamaiDataSet.ApartmentRow plainTextRow in decryptedTable)
                EncryptCopyApartment(plainTextRow, damaiDataSet.Apartment);
            this.apartmentSQLAdapter.Update(this.damaiDataSet.Apartment);
        }


        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MyFunction.AddNewItem(this.apartmentDataGridView, "columnApartmentID", "ApartmentID", this.damaiDataSet.Apartment);
            DataGridViewRow row = apartmentDataGridView.CurrentRow;             // 剛被新增那行一定是CurrentRow
            foreach (string s in ColumnsEncryted)
            {
                try
                {
                    row.Cells[s].Value = "";      // 因為在ColumnsEncrypted內的欄位在SQLDB內都被定義成不准NULL,所以必需填值
                }
                catch (Exception ex)
                {
                    MessageBox.Show("DataGridView欄位<" + s + ">設定初值失敗!程式錯誤,請將本訊息通知碼農修正錯誤!");
                }
            }
        }
    }
}
