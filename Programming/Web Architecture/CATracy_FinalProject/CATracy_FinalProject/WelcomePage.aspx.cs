using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CATracy_FinalProject
{
    public partial class WelcomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
        }

        protected void plazaBtn_Click(object sender, EventArgs e) //used postbackurl instead
        {
           
        }

        protected void exitBtn_Click(object sender, EventArgs e)
        {
          
        }
    }
}