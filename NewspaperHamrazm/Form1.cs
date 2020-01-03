using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NewsPaperHamrazm.DataLayer;
using NewsPaperHamrazm.DataLayer.Repositories;

namespace NewspaperHamrazm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string password = "";
        byte[] hash;
        private void button1_Click(object sender, EventArgs e)
        {
            var username = textBox1.Text.Trim().ToLower();
            password = textBox2.Text.Trim();

            var data = Encoding.ASCII.GetBytes(password);

            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(data);
            var hashedPassword = ASCIIEncoding.UTF8.GetString(md5data);
            Index index;
            using (var db = new UnitOfWork())
            {
                var user = new User()
                {
                    UserName = username,
                    Password = hashedPassword,
                    UserGroup = UserGroup.Admin
                };
                var searchUser = db.UserServices.GetUser(user);
                if (searchUser != null)
                {
                    index = new Index();
                    index.Show();
                }
                else
                {
                    MessageBox.Show("اطلاعات وارد شده صحیح نمی باشد");
                }
            }

        }
    }
}
