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
using repository= NewsPaperHamrazm.DataLayer.Repositories;
namespace NewspaperHamrazm.City
{
    public partial class CreateOrUpdate : Form
    {
        public readonly repository.City City;
        public CreateOrUpdate()
        {
            City =  new repository.City();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UnitOfWork db = new UnitOfWork())
            {
                if (City.CityId==0)
                {
                    var model = new repository.City()
                    {
                        CityName = txtCityName.Text,

                    };
                    var result = db.CityServices.AddCity(model);
                    if (result.IsChange)
                    {
                        db.Save();
                        MessageBox.Show(result.Message);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(result.Message);

                    }

                }
                else
                {
                    var model = new repository.City()
                    {
                        CityId = City.CityId,
                        CityName = txtCityName.Text,

                    };
                    var result = db.CityServices.UpdateCity(model);
                    if (result.IsChange)
                    {
                        db.Save();
                        MessageBox.Show(result.Message);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show(result.Message);

                    }
                }
            }
        }
    }
}
