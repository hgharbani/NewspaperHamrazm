using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsPaperHamrazm.DataLayer;
using respository=NewsPaperHamrazm.DataLayer.Repositories;
namespace NewspaperHamrazm.City
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowMaterialGrid()
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                dataGridView1.AutoGenerateColumns = false;
                List<respository.City> cities = db.CityServices.GetAllCity(new List<int>());
                dataGridView1.DataSource = cities;

            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            var createCity=new CreateOrUpdate();
            var result = createCity.ShowDialog();
            if (result == DialogResult.OK)
            {
                ShowMaterialGrid();
            }
        }

        private void Index_Load(object sender, EventArgs e)
        {
            ShowMaterialGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (textBox1.Text == "")
                {
                    ShowMaterialGrid();
                }
                else
                {
                   
                    var model = db.CityServices.GetByParamert(textBox1.Text);
                    dataGridView1.DataSource = model;

                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex == 2)
            {
                City.CreateOrUpdate frm = new City.CreateOrUpdate();
                frm.City.CityId = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                frm.txtCityName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                var createMaterialFoods = frm.ShowDialog();
                if (createMaterialFoods == DialogResult.Cancel|| createMaterialFoods == DialogResult.OK)
                {
                    ShowMaterialGrid();
                }
            }

            if (dataGridView1.CurrentCell.ColumnIndex == 3)
            {
           
               
                using (UnitOfWork db = new UnitOfWork())
                {

                    int id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    if (MessageBox.Show($"ایا از حذف {name} مطمئن هستید", "توجه", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var result = db.CityServices.DeleteCity(id);
                        if (result.IsChange)
                        {
                            db.Save();

                            MessageBox.Show(result.Message);
                        }
                        else
                        {
                            MessageBox.Show(result.Message);

                        }

                    }

                }

                ShowMaterialGrid();
            }

         
        }
    }
}
