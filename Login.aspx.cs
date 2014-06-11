using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /* Method that submits the login inputs and checks whether its correct before user continues */
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        /* Building connection to database */
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /*SQL command to select all fields from the table with the username the user inputs */
        SqlCommand cmd = new SqlCommand("select * from UserTable where Username ='" 
                                            + tbLoginUser.Text + "'", connection);
        cmd.Parameters.Add("@user", System.Data.SqlDbType.VarChar);
        cmd.Parameters["@user"].Value = tbLoginUser.Text;
        SqlDataReader result = cmd.ExecuteReader(); //reads the username from database using sql command

        /* Checks username input exists in the database */
        if (result.Read())
        {
            result.Close();
            /* SQL command to get the password for the username input */
            SqlCommand checkPassword = new SqlCommand("select Password from UserTable where Username ='" 
                                        + tbLoginUser.Text + "'", connection);
            /* Removes additional spaces including in the password */
            String password = checkPassword.ExecuteScalar().ToString().Replace(" ","");

            /* Checks if the password input matches the database password for the user */
            if (password == tbLoginPass.Text)
            {
                Session["Username"] = tbLoginUser.Text;
                Response.Redirect("Game.aspx"); //redirects to the game once logged in
            }
            else
            {
                lblPass.Text = "Password incorrect - Please try again";
            }
        }
        else
        {
            lblNotuser.Text = "Username not recognized - Please try again";
        }        
    }

    /* Method which sends user to registration */
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}