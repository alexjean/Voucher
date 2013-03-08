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
    public partial class FormRecipePriceUpdate : Form
    {
        VEDataSet.RecipeDetailRow[] m_Details;
        VEDataSet m_vEDataSet;
        public FormRecipePriceUpdate(VEDataSet.RecipeDetailRow[] details, VEDataSet vEDataSet)
        {
            m_Details = details;
            m_vEDataSet=vEDataSet;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        void AddLine(string name, decimal weight,string strCost)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvShow);
            row.Cells[0].Value = name;
            row.Cells[1].Value = weight;
            row.Cells[2].Value = strCost;
            dgvShow.Rows.Add(row);
        }

        private decimal CalcCost(VEDataSet.RecipeDetailRow[] details, List<int> usedRecipes,bool show)  // usedRecipes填入己使用的配方,避免Recursive
        {
            decimal cost = 0m;
            // 去找DataTable,最後新增那行還是DataRowState.Detached, 會少加一行
            decimal totalWeight = 0m;
            foreach (var d in details)
            {
                if (d.IsWeightNull()) continue;
                if (d.IsSourceIDNull()) continue;
                decimal we;
                if (d.IsWeightNull()) we = 0m;
                else we = d.Weight;
                totalWeight += we;
                if (d.SourceID < 10000)  // 是食材
                {
                    var ingredients = from ing in m_vEDataSet.Ingredient where ing.IngredientID == d.SourceID select ing;
                    if (ingredients.Count() <= 0) continue;
                    var ingredient = ingredients.First();
                    string name;
                    if (ingredient.IsNameNull())
                        name="食材"+ingredient.IngredientID.ToString();
                    else
                        name=ingredient.Name;
                    if (ingredient.IsPriceNull())
                    {
                        MessageBox.Show(name + "沒有參考進價,無法計算每克成本!");
                        if (show) AddLine(name, we, "沒有參考進價");
                        continue;
                    }
                    if (ingredient.IsUnitWeightNull() || ingredient.UnitWeight <= 0)
                    {
                        MessageBox.Show(ingredient.Name + "沒有單位重量,無法計算每克成本!");
                        if (show) AddLine(name, we, "沒有單位重量");
                        continue;
                    }
                    decimal co=(decimal)ingredient.Price * we / ingredient.UnitWeight;
                    cost += co;
                    if (show) AddLine(name,we, co.ToString("N2"));
                }
                else                   // 是配方
                {
                    int recipeID = d.SourceID % 10000;
                    string name = "配方:" + recipeID.ToString();
                    var ids = from i in usedRecipes where i == recipeID select i;
                    if (ids.Count() == 0)   // 沒有使用過此配方可用
                    {
                        var recipes = from row in m_vEDataSet.Recipe where (row.RowState != DataRowState.Deleted) && (row.RecipeID == recipeID) select row;
                        if (recipes.Count() > 0)
                        {
                            usedRecipes.Add(recipeID);
                            var recipe = recipes.First();
                            if (!recipe.IsRecipeNameNull()) name ="配方:"+recipe.RecipeName;
                            var details1 = recipe.GetRecipeDetailRows();
                            decimal we1=0;
                            foreach (VEDataSet.RecipeDetailRow r in details1)
                            {
                                if (r.IsWeightNull()) continue;
                                we1 += r.Weight;
                            }
                            if (we1 != 0m)
                            {
                                decimal co = CalcCost(details1, usedRecipes,show:false) * we / we1;
                                cost += co;
                                if (show) AddLine(name, we, co.ToString("N2"));
                            }
                            else
                                if (show) AddLine(name, we, "無配方重量");
                        }
                    }
                    else
                    {
                        MessageBox.Show(name + "重複使用,不計入!");
                        if (show) AddLine(name, we, "重複配方不計");
                    }
                }
            }
            dgvShow.Columns["ColumnWeight"].HeaderText = "總重 "+totalWeight.ToString()+"克";
            return cost;
        }


        private void FormRecipePriceUpdate_Shown(object sender, EventArgs e)
        {
            decimal cost=CalcCost(m_Details, usedRecipes: new List<int>(),show:true);
            labelCost.Text = cost.ToString("N2");
            Tag = cost;
        }


    }
}
