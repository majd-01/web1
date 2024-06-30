using System;
using System.Data.SqlClient;
using System.Web;

namespace YourNamespace
{
    public partial class CartUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get product ID from the form request
            string productID = Request.Form["product_id"];
            
            // userID should be retrieved from session or similar mechanism
            int userID = 1; 
            
            // Database connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["YourConnectionStringName"].ConnectionString;
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                // Check if the product already exists in the cart
                string sql = "SELECT * FROM Cart WHERE UserID = @UserID AND ProductID = @ProductID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@ProductID", productID);
                
                SqlDataReader reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    // If the product exists, update the quantity
                    reader.Close();
                    sql = "UPDATE Cart SET Quantity = Quantity + 1 WHERE UserID = @UserID AND ProductID = @ProductID";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // If the product does not exist, insert a new product into the cart
                    reader.Close();
                    sql = "INSERT INTO Cart (UserID, ProductID, Quantity) VALUES (@UserID, @ProductID, 1)";
                    cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@ProductID", productID);
                    cmd.ExecuteNonQuery();
                }
                
                conn.Close();
            }
            
            // Redirect the user to the cart page
            Response.Redirect("../cart.html");
        }
    }
}