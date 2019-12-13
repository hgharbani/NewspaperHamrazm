using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewspaperHamrazm
{
    public partial class Index : Form
    {
        public Index()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            var city = new City.Index();
            city.ShowDialog();
        }

        private void Index_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton19_Click(object sender, EventArgs e)
        {
            var category = new Category.Index();
            category.ShowDialog();
        }

        private void toolStripButton21_Click(object sender, EventArgs e)
        {
            var newIndex = new News.Index();
            newIndex.ShowDialog();
        }
    }
}
