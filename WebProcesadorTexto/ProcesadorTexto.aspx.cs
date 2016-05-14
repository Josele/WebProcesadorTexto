using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProcesadorTexto
{
    public partial class ProcesadorTexto : System.Web.UI.Page
    {
        private TextProcess P1 =null;
        protected void Page_Load(object sender, EventArgs e)
        {
            P1 = new TextProcess();
            Button1.UseSubmitBehavior=false;
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            int number=0;
            this.P1.setTexto(TextBox1.ToString());
            Int32.TryParse(TextBox2.Text.ToString(), out number);
            //this.P1.ProcesarTexto(number);
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        { int number;
            if (TextBox2.Text.ToString().Trim()=="")
                Button1.UseSubmitBehavior = false;
            else if (Int32.TryParse(TextBox2.Text.ToString(), out number))
                Button1.UseSubmitBehavior = true;
            else
                Button1.UseSubmitBehavior = false;
        }
    }
}