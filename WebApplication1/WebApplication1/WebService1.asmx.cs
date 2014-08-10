using System;
using System.Web.Services;
using System.Data.SqlClient;
using sql_Connection;
using System.Data;

namespace WebApplication1
{

    [WebService(Namespace = "http://CurrencyConvertor/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
   // [System.ComponentModel.ToolboxItem(false)]
    
    public class WebService1 : System.Web.Services.WebService 
    {

        private SqlConnection conn = new SqlConnection(Connect.connection());
        private SqlCommand command;
        SqlDataAdapter data_adapter = new SqlDataAdapter();
        DataSet data_Set = new DataSet();
        public double currency_Amount;
        public double amount;
        private string currency_code;

        [WebMethod(Description = "Calculate currency by country prefix to euro")]
        public void getCurrency(string phoneNumber,
                                double convertionAmount)
        {
             
            try
            {
                conn.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

                var _prefix = phoneNumber.Substring(0, 3);

                    string query_string = string.Format("SELECT Currency_Code, Currency_Value_Euro FROM" + 
                                                        " dbo.Rates WHERE Prefix = '{0}'", _prefix);

                    command = conn.CreateCommand();
                    command.CommandText = query_string;
                    data_adapter = new SqlDataAdapter(command);
                    data_Set = new DataSet();
                    data_adapter.Fill(data_Set, "rates");

                    if (data_Set.Tables[0].Rows.Count == 0)
                    {
                        conn.Close();
                    }

                    else
                        {
                            currency_code = data_Set.Tables[0].Rows[0]["Currency_Code"].ToString();
                            var _convert = Double.Parse(data_Set.Tables[0].Rows[0]["Currency_Value_Euro"].ToString());
                            var currency_rate = (1 / _convert);
                            amount = double.Parse(convertionAmount.ToString());

                            currency_Amount = (currency_rate * amount);
                        }

              conn.Close();
        }


        [WebMethod(Description = "Convert euro to chosen currency")]
        public string convertCurrency( string listItem, string lbl_Result)
        {
            try
            {
                conn.Open();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }

            string query_string = string.Format("SELECT  Currency_Code ,Currency_Value_Euro FROM dbo.Rates"+
                                                " WHERE Currency_Code = '{0}' ", listItem);

            command = conn.CreateCommand();
            command.CommandText = query_string;
            data_adapter = new SqlDataAdapter(command);
            data_Set = new DataSet();
            data_adapter.Fill(data_Set, "rates");

            if (data_Set.Tables[0].Rows.Count == 0)
            {
                conn.Close();
            }

            else
            {
                var _code = data_Set.Tables[0].Rows[0]["Currency_Code"].ToString();
                var _cValue = Double.Parse(data_Set.Tables[0].Rows[0]["Currency_Value_Euro"].ToString());
                var _rate_Exchange = (1 / _cValue);
                var _value = currency_Amount / _rate_Exchange;

                lbl_Result = +amount + " " + currency_code + " = " + _value + " " + _code;
            
            }
            conn.Close();
            return lbl_Result;
        }


    }
}
