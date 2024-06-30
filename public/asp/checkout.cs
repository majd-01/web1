using System;
using System.Data.SqlClient;
using System.Web;

namespace YourNamespace
{
    public partial class OrderSubmit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                // قراءة البيانات من النموذج
                string name = Request.Form["name"];
                string address = Request.Form["address"];
                string email = Request.Form["email"];
                string total = Request.Form["total"];
                
                // سلسلة الاتصال بقاعدة البيانات
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
                
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    
                    // إدراج الطلب في قاعدة البيانات
                    string sql = "INSERT INTO Orders (Name, Address, Email, Total) VALUES (@Name, @Address, @Email, @Total)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Total", total);
                    
                    cmd.ExecuteNonQuery();
                    
                    conn.Close();
                }
                
                // عرض رسالة الشكر
                Response.Write("<h1>Thank you for your purchase!</h1>");
            }
        }
    }
}