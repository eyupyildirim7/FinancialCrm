using FinancialCrm.Models;
using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FinancialCrm
{
    public partial class FrmDashboard : Form
    {
        public FrmDashboard()
        {
            InitializeComponent();
        }
            int  count=0;
        FinancialCrmDbEntities db= new FinancialCrmDbEntities();
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            var totalBalance = db.Banks.Sum(x => x.BankBalance);
            lblTotalBalance.Text = totalBalance.ToString();

            var lastBankProcessAmount = db.BankProcess.OrderByDescending(x => x.BankProcessId).Take(1).Select(y => y.Amount).FirstOrDefault();
            lblLastBankProcessAmount.Text = lastBankProcessAmount.ToString()+ "₺";

            //Chart 1 Kodlari 
            var bankdata = db.Banks.Select(x =>new
            {
                x.BankTitle,
                x.BankBalance
            }).ToList();
            chart1.Series.Clear();
            var series = chart1.Series.Add("Series1");
            foreach(var item in bankdata)
            {
                series.Points.AddXY(item.BankTitle, item.BankBalance);
            }
            //chart 2 kodlari
            var billData = db.Bills.Select(x => new{
                x.BillTitle,
                x.BillAmount
            }).ToList();
            chart2.Series.Clear();
            var series2 = chart2.Series.Add("Faturalar");
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Renko;
            foreach(var item in billData)
            {
                series2.Points.AddXY(item.BillTitle, item.BillAmount);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            count++;
            if(count %4 == 1)
            {
                var elektirikFaturasi= db.Bills.Where(x => x.BillTitle == "Elektirik Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Elektirik Faturasi";
                lblBillAmaount.Text=elektirikFaturasi.ToString() + "₺";

            }
            if (count % 4 == 2)
            {
                var elektirikFaturasi = db.Bills.Where(x => x.BillTitle == "Dogalgaz Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Dogalgaz Faturasi";
                lblBillAmaount.Text = elektirikFaturasi.ToString() + "₺";

            }
            if (count % 4 == 3)
            {
                var elektirikFaturasi = db.Bills.Where(x => x.BillTitle == "Su Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Su Faturasi";
                lblBillAmaount.Text = elektirikFaturasi.ToString() + "₺";

            }
            if (count % 4 == 0)
            {
                var elektirikFaturasi = db.Bills.Where(x => x.BillTitle == "Internet Faturasi").Select(y => y.BillAmount).FirstOrDefault();
                lblBillTitle.Text = "Internet Faturasi";
                lblBillAmaount.Text = elektirikFaturasi.ToString() + "₺";

            }
        }

        private void btnBillForm_Click(object sender, EventArgs e)
        {

            FrmBilling frm = new FrmBilling();
            frm.Show();
            this.Hide();
        }

        private void btnBanksForm_Click(object sender, EventArgs e)
        {
            FrmBanks frm = new FrmBanks();
            frm.Show();
            this.Hide();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
