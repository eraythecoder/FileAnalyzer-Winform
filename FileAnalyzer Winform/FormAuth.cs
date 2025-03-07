using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FileAnalyzer_Winform
{
    public partial class formRegister : Form
    {
        // Connection string to connect to the SQL Server database
        private string connectionString = @"Data Source= ... ;Initial Catalog= ... ;Integrated Security= ... ";

        public formRegister()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // It hides the password text by showing '*' instead of the actual characters.
            txtRegisterPassword.PasswordChar = '*';
            txtLoginPassword.PasswordChar = '*';
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegisterUsername.Text.Trim();
            string password = txtRegisterPassword.Text.Trim();

            // Check if the username or password fields are empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username or password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hash the entered password before comparing it to the stored hash in the database
            string hashedPassword = Hash.HashPassword(password);

            // Establish a connection to the database using the connection string
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection to the database
                    con.Open();

                    // Query to check if the username already exists in the database
                    string checkUserQuery = "SELECT COUNT(*) FROM dbo.AppUser WHERE Username = @username";

                    using (SqlCommand checkCmd = new SqlCommand(checkUserQuery, con))
                    {
                        // Prevent SQL injection by using parameterized queries
                        checkCmd.Parameters.AddWithValue("@username", username);
                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            MessageBox.Show("This username is already in use!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // SQL query to insert the new user into the database
                    string insertQuery = "INSERT INTO dbo.AppUser (Username, Password) VALUES (@username, @password)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        // Add parameters for username and password to prevent SQL injection
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);

                        int result = cmd.ExecuteNonQuery();

                        // If the insertion is successful, show a success message and open the login form
                        if (result > 0)
                        {
                            MessageBox.Show("Registration successful!\n You can login now.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            // If the insertion failed, show an error message
                            MessageBox.Show("Registration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // If an exception occurs, show the error message
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string username = txtLoginUsername.Text.Trim();
            string password = txtLoginPassword.Text.Trim();

            // Check if the username or password fields are empty
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username or password cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();

                    // Hash the entered password to compare with the stored hash in the database
                    string hashedPassword = Hash.HashPassword(password);

                    // Query to check if the username and hashed password match in the database
                    string checkLoginQuery = "SELECT COUNT(*) FROM dbo.AppUser WHERE Username COLLATE Latin1_General_BIN = @username AND Password COLLATE Latin1_General_BIN = @password";

                    using (SqlCommand checkCmd = new SqlCommand(checkLoginQuery, con))
                    {
                        // Prevent SQL injection by using parameterized queries
                        checkCmd.Parameters.AddWithValue("@username", username);
                        checkCmd.Parameters.AddWithValue("@password", hashedPassword); // Use hashed password for comparison

                        // Execute the query and get the result
                        int userExists = (int)checkCmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            // If the user exists, navigate to the app form
                            FormMain formApp = new FormMain();
                            formApp.Show();
                            this.Hide();
                        }
                        else
                        {
                            // If the username or password is incorrect, show an error message
                            MessageBox.Show("Incorrect username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that occur during the process
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



    }
}
