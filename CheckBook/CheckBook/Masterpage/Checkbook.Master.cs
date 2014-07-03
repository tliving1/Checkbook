using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace CheckBook.Masterpage
{
    public partial class Checkbook : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!bool.Parse(WebConfigurationManager.AppSettings["ShowSideNavigation"].ToString()))
            {
                leftmenuDiv.Visible = false;
            }
            if (!bool.Parse(WebConfigurationManager.AppSettings["AllOtherPageContent"].ToString()))
            {
                content.Attributes.Add("style", " margin: 20px 0 20px 110px;padding: 0 10px 0 10px;line-height: 20px;text-align: left;");
            }
            else
            {
                content.Attributes.Add("style", " margin: 20px 0 20px 160px;padding: 0 10px 0 10px;line-height: 20px;text-align: left;");
            }
        }
    }
}