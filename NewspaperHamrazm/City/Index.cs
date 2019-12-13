using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewspaperHamrazm.City
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var createCity=new CreateOrUpdate();
            var result = createCity.ShowDialog();
        }
    }
}
