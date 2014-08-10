using System;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DelegateApp;
using System.Data;

namespace WebApplication1
{
    
    [WebService(Namespace = "http://convertRates/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
   
    public class WebService1 : System.Web.Services.WebService
    {

        private SqlConnection conn = new SqlConnection(Connect.connection());
        private SqlCommand command;
        SqlDataAdapter data_adapter = new SqlDataAdapter();
        DataSet data_Set = new DataSet();
        public double currency_Amount;
        public double amount;
        private string currency_code;
       
        [WebMethod]
        public void getCurrency(TextBox txt_prefix, TextBox txt_Amount, Label lbl_Error)
        {
            var _phoneNumber = txt_prefix.Text;

            if (_phoneNumber.Length < 3)
            {
                lbl_Error.Text = "Phone Number Is invalid";
            }
            else
            {
                var _prefix = _phoneNumber.Substring(0, 3);

                if (txt_Amount.Text.Equals(""))
                {
                    lbl_Error.Text = "Invalid Convertion Ammount Supplied";
                }
                else
                {
                    try
                    {
                        conn.Open();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                    string query_string = string.Format("SELECT Currency_Code, Currency_Value_Euro FROM dbo.Rates WHERE Prefix = '{0}'", _prefix);                  
                    
                    command = conn.CreateCommand();
                    command.CommandText = query_string;
                    data_adapter = new SqlDataAdapter(command);
                    data_Set = new DataSet();
                    data_adapter.Fill(data_Set, "rates");

                    if (data_adapter != null)
                    {
                        currency_code = data_Set.Tables[0].Rows[0]["Currency_Code"].ToString();
                        var _convert = Double.Parse(data_Set.Tables[0].Rows[0]["Currency_Value_Euro"].ToString());
                        var currency_rate = (1 / _convert);
                        amount = double.Parse(txt_Amount.Text);
                        currency_Amount = (currency_rate * amount);
                    }
                    
                    else
                    {
                        lbl_Error.Text = "Invalid Prefix Re-Enter";
                    }
                    conn.Close();
                    
                }
            }
        }

        [WebMethod]
        public void convertCurrency(TextBox txt_Ammount, DropDownList listItem, Label lbl_Result)
        {
            try
            {
                conn.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            string query_string = string.Format("SELECT  Currency_Code ,Currency_Value_Euro FROM dbo.Rates WHERE Currency_Code = '{0}' "
                                                , listItem.SelectedItem.Text);

            command = conn.CreateCommand();
            command.CommandText = query_string;
            data_adapter = new SqlDataAdapter(command);
            data_Set = new DataSet();
            data_adapter.Fill(data_Set, "rates");

            if (data_adapter != null)
            {
                var _code = data_Set.Tables[0].Rows[0]["Currency_Code"].ToString();
                var _cValue = Double.Parse(data_Set.Tables[0].Rows[0]["Currency_Value_Euro"].ToString());
                var _rate_Exchange = (1 / _cValue);
                var _value = currency_Amount / _rate_Exchange;
                lbl_Result.Text = amount + " " +
                          currency_code + " = " + _value + " " + _code;
            }
            conn.Close();
        }

    }
}
