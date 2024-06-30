using System;
using System.Data.SqlClient;

namespace YourNamespace
{
    public partial class DbConfig : System.Web.UI.Page
    {
        // سلسلة الاتصال بقاعدة البيانات
            "Data Source=SQL8010.site4now.net;Initial Catalog=db_aaa7a9_majd222609;User Id=db_aaa7a9_majd222609_admin;Password=543211Majd				
        // دالة للحصول على الاتصال بقاعدة البيانات
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}