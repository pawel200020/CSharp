using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        private DateTime date;
        public Default()
        {
            date = new DateTime();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            setDateToLabel();
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            setDateToLabel();
        }
        private void setDateToLabel()
        {
            date = DateTime.Now;
            Label1.Text = date.Day+"."+date.Month+"."+date.Year;
            Label2.Text = date.Hour + ":" + date.Minute + ":" + date.Second;
        }
    }
}