using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Checkbook.Business;

namespace CheckBook
{
    public partial class Index : System.Web.UI.Page
    {
        Checkbook.Business.Transaction transaction;
        protected void Page_Load(object sender, EventArgs e)
        {
           transaction = new Checkbook.Business.Transaction();
            if (!IsPostBack)
            {
                datePicker.SelectedDate = DateTime.Now;
                ddlTransactionType.DataSource = Checkbook.Business.Listing.AllTransactionTypes();
                ddlTransactionType.DataTextField = "Value";
                ddlTransactionType.DataValueField = "Key";
                ddlTransactionType.DataBind();
            }
            CalculateBalance();
        }

        protected void submitTransaction(object sender, EventArgs e)
        {
            transaction = new Checkbook.Business.Transaction();
            if (transaction.NewTransaction("Thurston", txtDescription.Text, Decimal.Parse(txtAmount.Text), radioDebit.SelectedValue, datePicker.SelectedDate.Value, (chkTransactionCleared.Checked?"T":"F"), String.IsNullOrEmpty(txtCheckNumber.Text)?null:(int?)Int32.Parse(txtCheckNumber.Text),Int32.Parse(ddlTransactionType.SelectedValue)))
            {
                CalculateBalance();
                ResetValues();
            }
        }

        private void ResetValues()
        {
            datePicker.SelectedDate = DateTime.Now;
            txtCheckNumber.Text = "";
            txtAmount.Text = "";
            txtDescription.Text = "";
            ddlTransactionType.SelectedIndex = 0;
            chkTransactionCleared.Checked = false;
        }

        private void CalculateBalance()
        {
            transaction.GetCummlativeTotals();
            lblCurrentBalance.Text = transaction.CurrentBalance.ToString("C");
            lblPendingBalance.Text = transaction.TotalPendingBalance.ToString("C");

        }
    }
}