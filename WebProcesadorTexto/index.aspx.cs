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
            
            this.P1.setTexto(TextBox1.Text);
            if (Int32.TryParse(TextBox2.Text, out number) && number > 1)
                if (TextBox1.Text != "" && TextBox1.Text != null)
                    TextBox4.Text = P1.ProcesarTexto(number);
            else
                TextBox4.Text = "You have to use a higher number than 1 or a not null text";
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