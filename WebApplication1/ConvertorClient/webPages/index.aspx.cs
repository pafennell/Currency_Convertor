using ConvertorClient;
using System;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        WebService1 service = new WebService1();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_Error.Text = "";
            lbl_Display.Text = "";
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            cRates rates = new cRates();

            if (txt_Amount.Text.Equals(""))
            {
                lbl_Error.Text = "Invalid Convertion Ammount Supplied";
            }

            else if (txt_prefix.Text.Equals(""))
                {
                    lbl_Error.Text = "Enter a valid PhoneNumber";
                }
                else
                {
                    rates.Amount = double.Parse(txt_Amount.Text);
                    var amount = rates.Amount;
                    rates.Prefix = txt_prefix.Text;
                    var _prefix = rates.Prefix;
                    var list = code_List.SelectedItem.ToString();
                    var display = "";

                    service.getCurrency(_prefix, amount);
                    
                    lbl_Display.Text = service.convertCurrency( list, display);
                }
           
        }
           
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

    }
}