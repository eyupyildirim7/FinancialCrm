using FinancialCrm.Models;
using System.Linq;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmBilling : Form
    {
        public FrmBilling()
        {
            InitializeComponent();
        }
        FinancialCrmDbEntities db= new FinancialCrmDbEntities();

        private void FrmBilling_Load(object sender, System.EventArgs e)
        {
            var values =db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnBillList_Click(object sender, System.EventArgs e)
        {
            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnCreateBill_Click(object sender, System.EventArgs e)
        {
            string title=txtBillTitle.Text;
            decimal amount=decimal.Parse(txtBillAmount.Text);
            string periyot=txtBillPeriyot.Text;

            Bills bills =new Bills();
            bills.BillTitle= title; 
            bills.BillAmount=amount;
            bills.BillPeriod=periyot;
            db.Bills.Add(bills);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Eklendi","Ödeme & Faturalar",MessageBoxButtons.OK,MessageBoxIcon.Information);

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnRemoveBill_Click(object sender, System.EventArgs e)
        {
            int id=int.Parse(txtBillId.Text);
            var removeValue=db.Bills.Find(id);
            db.Bills.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values = db.Bills.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnUpdateBill_Click(object sender, System.EventArgs e)
        {
            string title = txtBillTitle.Text;
            decimal amount = decimal.Parse(txtBillAmount.Text);
            string periyot = txtBillPeriyot.Text;
            int id = int.Parse(txtBillId.Text);

            var values = db.Bills.Find(id);

            values.BillTitle = title;
            values.BillAmount = amount;
            values.BillPeriod = periyot;
          
            db.SaveChanges();
            MessageBox.Show("Ödeme Başarılı Bir Şekilde Sisteme Guncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

            var values2 = db.Bills.ToList();
            dataGridView1.DataSource = values2;

        }

        private void btnBanksForm_Click(object sender, System.EventArgs e)
        {
            FrmBanks frm= new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnBillForm_Click(object sender, System.EventArgs e)
        {
        }

        private void btnDashboardForm_Click(object sender, System.EventArgs e)
        {

            FrmDashboard frm = new FrmDashboard();
            frm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
