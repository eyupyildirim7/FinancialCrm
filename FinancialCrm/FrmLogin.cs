using FinancialCrm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db = new FinancialCrmDbEntities();

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    
        private void btnSingIn_Click(object sender, EventArgs e)
        { 
            string kullaniciAdi=txtUserName.Text;
            string sifre=txtPassword.Text;

            var kullanici=db.Users.FirstOrDefault(x=>x.Username==kullaniciAdi &&x.Password==sifre);

            if (kullanici !=null)
            {
                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmDashboard mainForm = new FrmDashboard();
                mainForm.Show();

                // Login formunu gizle
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
