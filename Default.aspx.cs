using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /* SQL statement to get the number of usernames which are input by the user in the text box */
        SqlCommand checkDuplicate = new SqlCommand("select count(*) from UserTable where Username ='" 
                                    + tbUser.Text + "'", connection);
        /* Converts the output of the query from a string value to int */
        int checkUsername = Convert.ToInt32(checkDuplicate.ExecuteScalar().ToString());
        /* If the check is equal to 1, this means there is a username which is the same as the users
         * input (returns 1 as there is a username) therefore, the user cannot continue and is informed*/
        if (checkUsername == 1)
        {
            lblExist.Text = "Username already exists - Please choose another";
        }
        connection.Close();
    }

    /* Method that submits all the users details into the database */
    protected void Confirm_Click(object sender, EventArgs e)
    {
        /* Validation to ensure users dont leave fields blank */
        if (tbUser.Text == "" || tbPassword.Text == "" || tbdob.Text == "")
        {
            lblFill.Text = "Please complete all fields";
        }
        else
        {
            /* Checks that the passwords match */
            if (tbPassword.Text == tbConfirm.Text)
            {
                try
                {
                    /* Connect with the database */
                    SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    connection.Open();
                    /* SQL to insert user input into the database */
                    SqlCommand insertUser = new SqlCommand ("insert into UserTable (Username, DOB, Password) values(@user, @dob, @password)", connection);
                    insertUser.Parameters.AddWithValue("@user", tbUser.Text);
                    insertUser.Parameters.AddWithValue("@dob", tbdob.Text);
                    insertUser.Parameters.AddWithValue("@password", tbPassword.Text);
                    insertUser.ExecuteNonQuery();

                    connection.Close();
                    Session["dob"] = tbdob.Text;
                    Response.Redirect("Login.aspx"); //once registered in, move to login
                }
                catch (Exception)
                {
                    //Catch inserting errors
                }

            }
            else
            {
                lblPmatch.Text ="Passwords do not match - Please try again";
                lblPmatch2.Text = "Passwords do not match - Please try again";
                tbConfirm.Text = "";
                tbPassword.Text = "";
            }
        }
    }

    /* Method to reset all text boxes and remove error labels */
    protected void Cancel_Click(object sender, EventArgs e)
    {
        tbConfirm.Text = "";
        tbdob.Text = "";
        tbPassword.Text = "";
        tbUser.Text = "";
        lblExist.Text = "";
        lblFill.Text = "";
    }

    /* Method to forward the user to login page from registration */
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}