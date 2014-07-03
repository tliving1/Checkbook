using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace CheckBook
{
    public partial class Transactions : System.Web.UI.Page
    {
        Checkbook.Business.Transaction transaction = new Checkbook.Business.Transaction();
        DataTable dt;//
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.PageSize = Int32.Parse(drpdownResults.SelectedValue);
            GridView1.PagerSettings.Mode = PagerButtons.NumericFirstLast;
            GridView1.RowStyle.HorizontalAlign = HorizontalAlign.Center;
            dt = transaction.GetAllTransactions();
            GridView1.DataSource = dt;
            GridView1.DataBind(); 
        }

        private void BindList()
        {
           
        }
    }
}