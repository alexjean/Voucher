using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VoucherExpense
{
    public partial class FormOperatorAuthList : Form
    {
        int m_OperatorID;
        DamaiDataSet m_DataSet;
        // Operator Apartment 由m_DataSet從上層傳入,
        // m_DataSet.OperatorAuthList Copy進來編修
        // Save時再回存
        public FormOperatorAuthList(int operatorID,DamaiDataSet dataSet)
        {
            m_OperatorID = operatorID;
            m_DataSet    = dataSet;
            InitializeComponent();
        }

        private void FormOperatorAuthList_Load(object sender, EventArgs e)
        {
            var op = m_DataSet.Operator.FindByOperatorID(m_OperatorID);
            if (op == null)
            {
                MessageBox.Show("找不到ID<" + m_OperatorID.ToString() + ">的操作員!");
                Close();
                return;
            }
            this.Text = op.Name;
            this.apartmentBindingSource.DataSource = m_DataSet;
            var list = from row in m_DataSet.OperatorAuthList where row.OperatorID == m_OperatorID select row;
            foreach (var auth in list)
            {
                var row = damaiDataSet.OperatorAuthList.NewOperatorAuthListRow();
                row.ApartmentID = auth.ApartmentID;
                row.OperatorID = auth.OperatorID;
                row.ID = auth.ID;
                damaiDataSet.OperatorAuthList.AddOperatorAuthListRow(row);
            }
            damaiDataSet.OperatorAuthList.AcceptChanges();  // 將RowState.Added變成RowState.Unchanged, 這樣Delete時才會在
        }

        private void operatorAuthListBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.operatorAuthListBindingSource.EndEdit();
            foreach (var row in damaiDataSet.OperatorAuthList)
            {
                if (row.RowState == DataRowState.Deleted)
                {
                    if (row.HasVersion(DataRowVersion.Original))
                    {
                        Guid id = (Guid)row["ID", DataRowVersion.Original];     // Deleted的不能取值了,只能如此
                        var auth = m_DataSet.OperatorAuthList.FindByID(id);
                        if (auth != null) auth.Delete();
                    }
                }
                else
                {
                    var auth=m_DataSet.OperatorAuthList.FindByID(row.ID);
                    if (auth == null)
                    {
                        auth = m_DataSet.OperatorAuthList.NewOperatorAuthListRow();
                        auth.ID = row.ID;
                        auth.OperatorID = row.OperatorID;
                        auth.ApartmentID = row.ApartmentID;
                        m_DataSet.OperatorAuthList.AddOperatorAuthListRow(auth);
                    }
                    else
                    {
                        if (auth.OperatorID  != row.OperatorID ) auth.OperatorID  = row.OperatorID;
                        if (auth.ApartmentID != row.ApartmentID) auth.ApartmentID = row.ApartmentID;
                    }
                }
            }
            try
            {
                operatorAuthListTableAdapter.Update(m_DataSet.OperatorAuthList);    // Update時m_DataSet版自動AcceptChanges
                damaiDataSet.OperatorAuthList.AcceptChanges();                      // 編修Copy版AcceptChanges
            }
            catch (Exception ex)
            {
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            var row = this.operatorAuthListDataGridView.CurrentRow;
            row.Cells["columnID"].Value         = Guid.NewGuid();
            row.Cells["columnOperatorID"].Value = m_OperatorID;
            row.Cells["dgvComboName"].Value     = 1;
        }
    }
}
