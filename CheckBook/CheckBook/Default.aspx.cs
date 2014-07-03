using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CheckBook
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            datePicker.SelectedDate = DateTime.Now;
            DropDownList1.DataSource = Checkbook.Business.Listing.AllTransactionTypes();
            DropDownList1.DataTextField = "Value";
            DropDownList1.DataValueField = "Key";
            DropDownList1.DataBind();
            //transaction.NewTransaction("Thurston", "Giant", 45.25, true, DateTime.Now, "N", 1505,3);
        }
    }
}