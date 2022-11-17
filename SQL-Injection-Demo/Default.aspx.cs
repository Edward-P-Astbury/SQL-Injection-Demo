using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQL_Injection_Demo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDbConnect connect = new SqlDbConnect();

                connect.SqlQuery("INSERT INTO Names (FirstName, LastName) VALUES (@FirstName, @LastName)");

                // Utilise parameters, good practice 
                connect._command.Parameters.AddWithValue("@FirstName", txtBoxFirstName.Text.Trim());
                connect._command.Parameters.AddWithValue("@LastName", txtBoxLastName.Text.Trim());

                connect.NonQuery();

                // POOR secure coding practice, uncomment this line to test injections
                //connect.SqlQuery("SELECT * FROM Names WHERE LastName = '" + txtBoxLastName.Text.Trim() + "'");

                // CORRECT secure coding practice, comment these two lines to disable SQL injection security
                connect.SqlQuery("SELECT * FROM Names WHERE LastName=@LastName");
                connect._command.Parameters.AddWithValue("@LastName", txtBoxLastName.Text.Trim());

                listBoxDatabase.Items.Clear();

                labelOutput.Text = "List of accounts with the specified last name entered";

                foreach (DataRow dataRow in connect.RetrieveQuery().Rows)
                {
                    listBoxDatabase.Items.Add(dataRow[1].ToString() + " - " + dataRow[2].ToString());
                }
            }
            catch (Exception ex)
            {
                labelOutput.Text = "Query error " + ex;
            }
        }
    }
}