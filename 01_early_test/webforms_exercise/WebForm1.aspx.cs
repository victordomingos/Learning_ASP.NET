using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webforms_exercise
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_click_me_Click(object sender, EventArgs e)
        {
            btn_click_me.Text = "Oh, no! Please stop!...";
        }
    }
}