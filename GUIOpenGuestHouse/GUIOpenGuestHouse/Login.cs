using Microsoft.Data.SqlClient;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUIOpenGuestHouse
{
    public partial class Login : Form
    {
        DBAccess objdBAccess = new DBAccess();

        public Login()
        {
            InitializeComponent();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            lblnotifySignUP.Text = "";
            txtLUserName.Text = "";
            txtLPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            combGender.Text = "";
            txtPhone.Text = "";
            //////////////////////
            txtLUserName.Visible = false;
            txtLUserName.Clear();
            txtLUserName.BorderStyle = BorderStyle.None;
            ///////////
            txtLPassword.Visible = false;
            txtLPassword.Clear();
            txtLPassword.BorderStyle = BorderStyle.None;
            ///////////////
            txtLUserName.Clear(); // Clear the textbox
            txtLUserName.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                        // Set event handler to allow any input (no validation)
            txtLUserName.KeyPress += (s, ev) => { };

            //////////
            rbLuserid.Checked = false;
            rbLusername.Checked = false;
            //////////////
            pnlSignup.Visible = false;
            pnlLogin.Visible = true;

        }
        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####-----after-Login is clicked----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            DBAccess objdBAccess = new DBAccess();
            DataTable dtUsers = new DataTable();
            string userName = txtLUserName.Text;
            string userPassword = txtLPassword.Text;
            string searchchoice = "";
            bool flag = false;
            lblLNotify.Text = "";


            if (!(rbLuserid.Checked || rbLusername.Checked))
            {
                MessageBox.Show("Please choose Login Method:.");
                flag = false;
            }
            else if (rbLuserid.Checked)
            {
                searchchoice = "userid";
                flag = true;
            }
            else if (rbLusername.Checked)
            {
                searchchoice = "username";
                flag = true;
            }

            if (flag)
            {


                if (userName.Equals(""))
                {
                    MessageBox.Show("Please enter your username.");
                }
                else if (userPassword.Equals(""))
                {
                    MessageBox.Show("Please enter your password.");
                }
                else
                {
                    if ((userName == "admin" || userName == "000") && userPassword == "123")
                    {
                        this.Hide();
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                    }
                    else
                    {

                        //string cmd = "select * from users where Email='" + userEmail + "' AND Password='" + userPassword + "'";
                        SqlCommand lOGINcmd = new SqlCommand();
                        lOGINcmd.CommandText = "select * from useracc where " + searchchoice + "= @userName AND password = @userPassword ;";
                        lOGINcmd.Parameters.AddWithValue("@userName", userName);
                        lOGINcmd.Parameters.AddWithValue("@userPassword", userPassword);
                        objdBAccess.readDatathroughAdapterSql(lOGINcmd, dtUsers);

                        if (dtUsers.Rows.Count == 1)
                        {
                            string TempStatus = dtUsers.Rows[0]["status"].ToString();
                            //and status!= 'deactivated'
                            if (TempStatus == "deactivated")
                            {
                                lblLNotify.Text = "This account have been deactivated. call 1234";
                            }
                            else
                            {
                               // MessageBox.Show("Login sucessfully", "success", MessageBoxButtons.OK);
                                objdBAccess.closeConn();
                                this.Hide();
                                CustomerForm Cform = new CustomerForm();
                                Cform.Saveduserid = Convert.ToInt32(dtUsers.Rows[0]["userid"]);
                                Cform.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid Crenditionals", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }

                }
            }

        }
        private void rbLuserid_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLuserid.Checked)
            {
                txtLUserName.Visible = true;
                txtLUserName.BorderStyle = BorderStyle.Fixed3D;
                txtLUserName.ReadOnly = false;
                txtLPassword.Visible = true;
                txtLPassword.BorderStyle = BorderStyle.Fixed3D;
                txtLPassword.ReadOnly = false;
                txtLUserName.Clear(); // Clear the textbox
                                      //txtSearchAccAssignR.KeyPress -= AllowNonNumericInput; // Remove any existing event handler
                txtLUserName.KeyPress -= (s, ev) => { };
                txtLUserName.KeyPress += AllowNumericInput; // Set event handler to allow only numeric input
            }
        }

        private void rbLusername_CheckedChanged(object sender, EventArgs e)
        {
            if (rbLusername.Checked)
            {
                txtLUserName.Visible = true;
                txtLUserName.BorderStyle = BorderStyle.Fixed3D;
                txtLUserName.ReadOnly = false;
                txtLPassword.Visible = true;
                txtLPassword.BorderStyle = BorderStyle.Fixed3D;
                txtLPassword.ReadOnly = false;
                txtLUserName.Clear(); // Clear the textbox
                txtLUserName.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                            // Set event handler to allow any input (no validation)
                txtLUserName.KeyPress += (s, ev) => { };
            }
        }
        private void AllowNumericInput(object sender, KeyPressEventArgs e)
        {
            // Allow only numeric input
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####-----linkLabel- To go to signup----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>

        private void lbLinkSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtLUserName.Text = "";
            txtLPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            combGender.Text = "";
            txtPhone.Text = "";
            lblLNotify.Text = "";
            pnlLogin.Visible = false;
            pnlSignup.Visible = true;
            dtpicker.Value = DateTime.Now;
        }
        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####------Inside save signup----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {


            string userfName = txtFirstName.Text;
            string userlName = txtLastName.Text;
            string userAge = txtAge.Text;
            string userGender = combGender.Text;
            string userPhone = txtPhone.Text;


            if (userfName.Equals(""))
            {
                MessageBox.Show("Please enter your first name.");
            }
            else if (userlName.Equals(""))
            {
                MessageBox.Show("Please enter your last name.");
            }
            else if (userPhone.Equals(""))
            {
                MessageBox.Show("Please select your Type.");
            }
            else if (userAge.Equals("") || userAge.Equals(0))
            {
                MessageBox.Show("Please enter your Age.");
            }
            else if (userGender.Equals(""))
            {
                MessageBox.Show("Please select your Type.");
            }
            else
            {
                string checkUserName = userfName + "_" + userPhone + "@" + userAge;
                DataTable dt = new DataTable();
                SqlCommand lOGINcmd = new SqlCommand();
                lOGINcmd.CommandText = "select * from useracc where username = @userName;";
                lOGINcmd.Parameters.AddWithValue("@userName", checkUserName);
                objdBAccess.readDatathroughAdapterSql(lOGINcmd, dt);

                if (dt.Rows.Count == 1)
                { lblnotifySignUP.Text = "account with the following details already availalbe"; }
                else
                {
                    DBAccess objdBAccess = new DBAccess();
                    lblnotifySignUP.Text = "";


                    string inscmd = "insert into usersinfo(fname,lname,age,phone,gender) values (@userfName,@userlName,@userAge,@userPhone,@userGender);";
                    SqlCommand insertcmd = new SqlCommand(inscmd);
                    insertcmd.Parameters.AddWithValue("@userfName", userfName);
                    insertcmd.Parameters.AddWithValue("@userlName", userlName);
                    insertcmd.Parameters.AddWithValue("@userAge", userAge);
                    insertcmd.Parameters.AddWithValue("@userPhone", userPhone);
                    insertcmd.Parameters.AddWithValue("@userGender", userGender);
                    int row = objdBAccess.executeQuery(insertcmd);


                    if (row > 0)
                    {

                        string defaultPass = "123";
                        string defaultStatus = "inactive";
                        string cUserName = userfName + "_" + userPhone + "@" + userAge;
                        string Query = "insert into useracc(username,password,status) values (@cUserName,@defaultPass,@defaultStat);";
                        SqlCommand acinsertcmd = new SqlCommand(Query);
                        acinsertcmd.Parameters.AddWithValue("@cUserName", cUserName);
                        acinsertcmd.Parameters.AddWithValue("@defaultPass", defaultPass);
                        acinsertcmd.Parameters.AddWithValue("@defaultStat", defaultStatus);

                        objdBAccess.executeQuery(acinsertcmd);

                        //to get id 
                        DataTable dtt = new DataTable();
                        SqlCommand llOGINcmd = new SqlCommand();
                        llOGINcmd.CommandText = "select * from useracc where username = @cUserName;";
                        llOGINcmd.Parameters.AddWithValue("@cUserName", cUserName);
                        objdBAccess.readDatathroughAdapterSql(llOGINcmd, dtt);
                        int uid = Convert.ToInt32(dtt.Rows[0]["userid"]);

                        MessageBox.Show("Account created sucessfully\n use the following details\n user-id: " + uid + "\n username: '" + cUserName + "'  \n password is 123", "success", MessageBoxButtons.OK);
                        lblnotifySignUP.Text = "";
                        txtLUserName.Text = "";
                        txtLPassword.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtAge.Text = "";
                        combGender.Text = "";
                        txtPhone.Text = "";
                        //////////////////////
                        txtLUserName.Visible = false;
                        txtLUserName.Clear();
                        txtLUserName.BorderStyle = BorderStyle.None;
                        ///////////
                        txtLPassword.Visible = false;
                        txtLPassword.Clear();
                        txtLPassword.BorderStyle = BorderStyle.None;
                        ///////////////
                        txtLUserName.Clear(); // Clear the textbox
                        txtLUserName.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                                    // Set event handler to allow any input (no validation)
                        txtLUserName.KeyPress += (s, ev) => { };

                        //////////
                        rbLuserid.Checked = false;
                        rbLusername.Checked = false;
                        //////////////
                        pnlSignup.Visible = false;
                        pnlLogin.Visible = true;




                        txtLUserName.Text = "";
                        txtLPassword.Text = "";
                        txtFirstName.Text = "";
                        txtLastName.Text = "";
                        txtAge.Clear();
                        combGender.Text = "";
                        txtPhone.Text = "";
                        lblLNotify.Text = "";
                        dtpicker.Value = DateTime.Now;



                        objdBAccess.closeConn();
                    }
                    else
                    {
                        MessageBox.Show("Account creation is unsucessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            txtAge.Text = Convert.ToString((DateTime.Now.Year - dtpicker.Value.Year));
        }
        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####-----linkLabel- To go to Login Page----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>
        private void linklblBLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblnotifySignUP.Text = "";
            txtLUserName.Text = "";
            txtLPassword.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAge.Text = "";
            combGender.Text = "";
            txtPhone.Text = "";
            //////////////////////
            txtLUserName.Visible = false;
            txtLUserName.Clear();
            txtLUserName.BorderStyle = BorderStyle.None;
            ///////////
            txtLPassword.Visible = false;
            txtLPassword.Clear();
            txtLPassword.BorderStyle = BorderStyle.None;
            ///////////////
            txtLUserName.Clear(); // Clear the textbox
            txtLUserName.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                        // Set event handler to allow any input (no validation)
            txtLUserName.KeyPress += (s, ev) => { };

            //////////
            rbLuserid.Checked = false;
            rbLusername.Checked = false;
            //////////////
            pnlSignup.Visible = false;
            pnlLogin.Visible = true;
        }

        
    }
}
