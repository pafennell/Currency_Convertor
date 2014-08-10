using System;
using System.Data.SqlClient;
using System.Xml;

namespace Parser
{
    class Program
    {

        static SqlConnection connection = new SqlConnection(sql_Connection.Connect.connection());
        static SqlCommand command = new SqlCommand();

        static void Main(string[] args)
        {

            XmlReader reader = XmlReader.Create("http://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element)
                                   && reader.Name == "Cube")
                {
                    if (reader.HasAttributes)
                    {
                        var rate = Convert.ToDouble(reader.GetAttribute("rate"));
                        var currency = Convert.ToString(reader.GetAttribute("currency"));

                        string query_string = "UPDATE dbo.Rates SET Currency_Value_Euro = '" + rate + 
                                              "' WHERE Currency_Code = '" + currency + "'";

                        command = connection.CreateCommand();
                        command.CommandText = query_string;

                        try
                        {
                            connection.Open();
                        }
                        catch (SqlException e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }

            }
            Console.WriteLine("Update Complete");
            Console.ReadLine();
        }

    }
}