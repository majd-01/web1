using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace YourNamespace
{
    public partial class Products : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // سلسلة الاتصال بقاعدة البيانات
            string connStr = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DB;User ID=YOUR_USER;Password=YOUR_PASSWORD;";
            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                
                // استعلام استرجاع المنتجات
                string sql = "SELECT * FROM Products";
                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // توليد HTML للمنتجات
                        while (reader.Read())
                        {
                            Response.Write("<div class='product-card'>");
                            Response.Write("<img src='images/" + reader["Image"] + "' alt='" + reader["Name"] + "'>");
                            Response.Write("<h2>" + reader["Name"] + "</h2>");
                            Response.Write("<p>$" + reader["Price"] + "</p>");
                            Response.Write("<a href='product-detail.html?id=" + reader["ProductID"] + "'>View Details</a>");
                            Response.Write("</div>");
                        }
                    }
                }
            }
        }
    }
}