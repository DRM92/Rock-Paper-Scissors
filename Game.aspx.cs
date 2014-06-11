using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class Game : System.Web.UI.Page
{
    /* Creating own vairable using enum - options available for user */
    enum Option { Rock, Paper, Scissors, Lizard, Spock };
    Option compOption; //computer can use all values in the enum type option

    /* Initialising stats */
    int win = 0;
    int loss = 0;
    int draw = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        /* Welcomes each unique user by their ID */
        lblWelcome.Text = Session["Username"].ToString();
        Birthday(); //check if users birthday

        /* Retrieving stats for each user */ 
        Get_Win();
        Get_Loss();
        Get_Draw();
        Games_Played();
    }

    protected void playButton_Click(object sender, EventArgs e)
    {
        /* Checks that atleast one option is chosen by user */
        if (rbRock.Checked || rbPaper.Checked || 
                rbScissors.Checked || rbLizard.Checked || rbSpock.Checked)
        {
            ResultLabel.Text = "";
            playButton.Text = "Play Again"; //Changes button to text to inform user to play again

            /* Calls all methods to control game and statistics */
            Computer_Action();
            User_Paper();
            User_Lizard();
            User_Rock();
            User_Scissors();
            User_Spock();
            Get_Win();
            Get_Loss();
            Get_Draw();
            Games_Played();
        }
        else
        {
            lblOption.Text = "Please choose an option!"; //when no option is chosen
        }
    }

    /* Method that chooses a random option for the user and outputs their choice */
    private void Computer_Action()
    {
        Random ranComp = new Random();
        int choices = 5; //Rock, Paper, Scissors, Lizard, Spock = 5
        int computerOption = ranComp.Next(choices) + 1; //Random choice generator

        /* If statement for each random value - sets vairable to option 
         * and outputs the choice to inform user */
        if (computerOption == 1)
        {
            compOption = Option.Rock;
            CompLabel.Text = "The Computers choice is Rock!";
        }
        else if (computerOption == 2)
        {
            compOption = Option.Paper;
            CompLabel.Text = "The Computers choice is Paper!";
        }
        else if (computerOption == 3)
        {
            compOption = Option.Scissors;
            CompLabel.Text = "The Computers choice is Scissors!";
        }
        else if (computerOption == 4)
        {
            compOption = Option.Lizard;
            CompLabel.Text = "The Computers choice is Lizard!";
        }
        else if (computerOption == 5)
        {
            compOption = Option.Spock;
            CompLabel.Text = "The Computers choice is Spock!";
        }
    }

    /* Method to check whether it is the users birthday - If yes, wishes happy birthday to user */
    private void Birthday()
    {
        String userID = Session["Username"].ToString(); //Gets the current user
        /* Establishing a connection to the database */
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /* SQL statement to retrieve the dob for the current user */
        SqlCommand getDOB = new SqlCommand("select DOB from UserTable where Username ='" + userID + "'", connection);
        getDOB.ExecuteNonQuery(); //returns row with users dob
        lblBirthday.Text = getDOB.ExecuteScalar().ToString(); //temporary sets dob in birthday text
        connection.Close();

        /* Splits the date into just days and month - removing the year */
        String[] dateMonth = lblBirthday.Text.Split(new char[] { '/' });
        /* Sets birthday label to dd/MM */
        lblBirthday.Text = dateMonth[0] + "/" + dateMonth[1]; 
        
        /* If the day and month is the same as todays date - wishes user happy birthday */
        if (lblBirthday.Text.Equals(DateTime.Now.ToString("dd/MM")))
        {
            lblBirthday.Text = "Its your birthday! Have a great day!";
        }
        else
        {
            lblBirthday.Text = "";
        }        
    }

    /* Method which gets the current win stat for the current user */
    private void Get_Win()
    {
        String userID = Session["Username"].ToString(); 
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /* Gets the current win value from database for the current user */
        SqlCommand getWins = new SqlCommand ("select Win from UserTable where Username ='" 
                                + userID + "'", connection);
        getWins.ExecuteNonQuery();
        lblWin.Text = getWins.ExecuteScalar().ToString(); //sets the label to the win row value for the user
        connection.Close();
    }

    /* Method that updates the win row for each user by 1 when called */
    private void User_Win()
    {
        String userID = Session["Username"].ToString();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /* Updates current users Wins in the database */
        SqlCommand updateWin = new SqlCommand("UPDATE UserTable SET Win='" + win +
                                "' Where Username ='" + userID + "'", connection);
        updateWin.ExecuteNonQuery();
        connection.Close();
    }

    /* Method which gets the current Loss stat for the current user */
    private void Get_Loss()
    {
        String userID = Session["Username"].ToString();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /* Gets the current loss value from database for the current user */
        SqlCommand getLoss = new SqlCommand("select Loss from UserTable where Username ='" 
                                + userID + "'", connection);
        getLoss.ExecuteNonQuery();
        lblLoss.Text = getLoss.ExecuteScalar().ToString(); //sets the label to the loss row value for the user
        connection.Close();
    }

    /* Method that updates the loss row for each user by 1 when called */
    private void User_Loss()
    {
        String userID = Session["Username"].ToString();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /* Updates current users loss in the database */
        SqlCommand updateWin = new SqlCommand("UPDATE UserTable SET Loss='" + loss + 
                                "' Where Username ='" + userID + "'", connection);
        updateWin.ExecuteNonQuery();
        connection.Close();
    }

    /* Method which gets the current Draw stat for the current user */
    private void Get_Draw()
    {
        String userID = Session["Username"].ToString();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /* Gets the current draw value from database for the current user */
        SqlCommand getDraw = new SqlCommand("select Draw from UserTable where Username ='" 
                                + userID + "'", connection);
        getDraw.ExecuteNonQuery();
        lblDraw.Text = getDraw.ExecuteScalar().ToString();
        connection.Close();
    }

    /* Method that updates the draw row for each user by 1 when called */
    private void User_Draw()
    {
        String userID = Session["Username"].ToString();
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        connection.Open();
        /* Updates current users loss in the database*/
        SqlCommand updateDraw = new SqlCommand("UPDATE UserTable SET Draw='" + draw +
                                    "' Where Username ='" + userID + "'", connection);
        updateDraw.ExecuteNonQuery();
        connection.Close();
    }

    /* Method that calculates the total games played by each user */
    private void Games_Played()
    {
        int played = 0;
        /* Parses the string labels as ints to calculate the total plays from the statistics */
        played = int.Parse(lblLoss.Text) + int.Parse(lblWin.Text) + int.Parse(lblDraw.Text);
        lblPlayed.Text = played.ToString();
    }

    /* Method that determines the results when the user is rock and updates the statistics */
    private void User_Rock()
    {
        /* Informs users of their choice */
        if (rbRock.Checked)
        {
            UserLabel.Text = "Your choice is Rock!";

            /* Losing result - Informs user they lost and updates loss statistic */
            if (compOption == Option.Paper || compOption == Option.Spock)
            {
                ResultLabel.Text = "Computer Wins!";
                string sLoss = lblLoss.Text;
                loss = int.Parse(sLoss) + 1;
                User_Loss();
            }
            /* Winning Result - Informs user they won and updates win statistic */
            else if (compOption == Option.Scissors || compOption == Option.Lizard)
            {
                ResultLabel.Text = "User Wins!";
                string sWin = lblWin.Text;
                win = int.Parse(sWin) + 1;
                User_Win();
            }
            /* Draw Result - Informs user they tied and updates draw statistic */
            else if (compOption == Option.Rock)
            {
                ResultLabel.Text = "The game is a draw!";
                string sDraw = lblDraw.Text;
                draw = int.Parse(sDraw) + 1;
                User_Draw();
            }
        }
    }

    private void User_Paper()
    {
        /* Informs users of their choice */
        if (rbPaper.Checked)
        {
            UserLabel.Text = "Your choice is Paper!";

            /* Losing result - Informs user they lost and updates loss statistic */
            if (compOption == Option.Scissors || compOption == Option.Lizard)
            {
                ResultLabel.Text = "Computer Wins!";
                string sLoss = lblLoss.Text;
                loss = int.Parse(sLoss) + 1;
                User_Loss();
            }
            /* Winning Result - Informs user they won and updates win statistic */
            else if (compOption == Option.Rock || compOption == Option.Spock)
            {
                ResultLabel.Text = "User Wins!";
                string sWin = lblWin.Text;
                win = int.Parse(sWin) + 1;
                User_Win();
            }
            /* Draw Result - Informs user they tied and updates draw statistic */
            else if (compOption == Option.Paper)
            {
                ResultLabel.Text = "The game is a draw!";
                string sDraw = lblDraw.Text;
                draw = int.Parse(sDraw) + 1;
                User_Draw();
            }
        }
    }

    private void User_Scissors()
    {
        /* Informs users of their choice */
        if (rbScissors.Checked)
        {
            UserLabel.Text = "Your choice is Scissors!";

            /* Losing result - Informs user they lost and updates loss statistic */
            if (compOption == Option.Spock || compOption == Option.Rock)
            {
                ResultLabel.Text = "Computer Wins!";
                string sLoss = lblLoss.Text;
                loss = int.Parse(sLoss) + 1;
                User_Loss();
            }
            /* Winning Result - Informs user they won and updates win statistic */
            else if (compOption == Option.Paper || compOption == Option.Lizard)
            {
                ResultLabel.Text = "User Wins!";
                string sWin = lblWin.Text;
                win = int.Parse(sWin) + 1;
                User_Win();
            }
            /* Draw Result - Informs user they tied and updates draw statistic */
            else if (compOption == Option.Scissors)
            {
                ResultLabel.Text = "The game is a draw!";
                string sDraw = lblDraw.Text;
                draw = int.Parse(sDraw) + 1;
                User_Draw();
            }
        }
    }

    private void User_Lizard()
    {
        /* Informs users of their choice */
        if (rbLizard.Checked)
        {
            UserLabel.Text = "Your choice is Lizard!";

            /* Losing result - Informs user they lost and updates loss statistic */
            if (compOption == Option.Rock || compOption == Option.Scissors)
            {
                ResultLabel.Text = "Computer Wins!";
                string sLoss = lblLoss.Text;
                loss = int.Parse(sLoss) + 1;
                User_Loss();
            }
            /* Winning Result - Informs user they won and updates win statistic */
            else if (compOption == Option.Paper || compOption == Option.Spock)
            {
                ResultLabel.Text = "User Wins!";
                string sWin = lblWin.Text;
                win = int.Parse(sWin) + 1;
                User_Win();
            }
            /* Draw Result - Informs user they tied and updates draw statistic */
            else if (compOption == Option.Lizard)
            {
                ResultLabel.Text = "The game is a draw!";
                string sDraw = lblDraw.Text;
                draw = int.Parse(sDraw) + 1;
                User_Draw();
            }
        }
    }

    private void User_Spock()
    {
        /* Informs users of their choice */
        if (rbSpock.Checked)
        {
            UserLabel.Text = "Your choice is Spock";

            /* Losing result - Informs user they lost and updates loss statistic */
            if (compOption == Option.Paper || compOption == Option.Lizard)
            {
                ResultLabel.Text = "Computer Wins!";
                string sLoss = lblLoss.Text;
                loss = int.Parse(sLoss) + 1;
                User_Loss();
            }
            /* Winning Result - Informs user they won and updates win statistic */
            else if (compOption == Option.Rock || compOption == Option.Scissors)
            {
                ResultLabel.Text = "User Wins!";
                string sWin = lblWin.Text;
                win = int.Parse(sWin) + 1;
                User_Win();
            }
            /* Draw Result - Informs user they tied and updates draw statistic */
            else if (compOption == Option.Spock)
            {
                ResultLabel.Text = "The game is a draw!";
                string sDraw = lblDraw.Text;
                draw = int.Parse(sDraw) + 1;
                User_Draw();
            }
        }
    }

    /* Method to allow the user to logout of their account */
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
}