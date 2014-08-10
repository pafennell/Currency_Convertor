namespace sql_Connection
{
    
    public class Connect 
    {
        public static string connection()
        {
            string connect= "Data Source= .\\SQLEXPRESS;Initial Catalog=Currency_Rates;Integrated Security=True";
            return connect; 
        }

    }
}
