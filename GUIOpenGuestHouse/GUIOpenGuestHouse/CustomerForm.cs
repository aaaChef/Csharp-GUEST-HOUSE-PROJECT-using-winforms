using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUIOpenGuestHouse
{
    public partial class CustomerForm : Form
    {
        public int Saveduserid { get; set; }

        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            pnlCustomerMenu.Visible = true;

            pnlUpdateInfo.Visible = false;
            pnlMakeReservation.Visible = false;
            pnlViewAvailableRooms.Visible = false;
            pnlChangeAccountStatusAD.Visible = false;
            pnlViewOwnSummaryReport.Visible = false;

        }
        private void linklblBacktoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- View/Own/Summary/Report ----###########/////////////////
        /// //////////////##############History of customers or already booked before()#############/////////////////
        /// </summary>
        private void btnGuestSReoport_Click(object sender, EventArgs e)
        {
            pnlCustomerMenu.Visible = false;
            pnlViewOwnSummaryReport.Visible = true;

            DBAccess objdBAccess = new DBAccess();
            DataTable dtusers12 = new DataTable();

            string query1 = "select accid,fname,status,HistorySummary   from useracc, usersinfo where useracc.userid=usersinfo.accid and HistorySummary is not Null and userid=" + Saveduserid + ";";
            objdBAccess.readDatathroughAdapter(query1, dtusers12);
            if (dtusers12.Rows.Count != 0)
            {
                txtVOSid.Text = dtusers12.Rows[0]["accid"].ToString();
                txtVOSfname.Text = dtusers12.Rows[0]["fname"].ToString();
                txtVOSstatus.Text = dtusers12.Rows[0]["status"].ToString();
                txtHistorySummary.Text = dtusers12.Rows[0]["HistorySummary"].ToString();
            }
            else
            {
                pnlCustomerMenu.Visible = true;
                pnlViewOwnSummaryReport.Visible = false;
                MessageBox.Show("Never Visited this hotel before.This is to view your previous booking", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            objdBAccess.closeConn();

        }
        private void btnBackToMMGuestSummary_Click_1(object sender, EventArgs e)
        {
            pnlCustomerMenu.Visible = true;
            pnlViewOwnSummaryReport.Visible = false;
        }



        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- Make/Reservation ----###########/////////////////
        /// //////////////##############History of customers or already booked before()#############/////////////////
        /// </summary>
        /// 
        private void btnSaveAssignR_Click(object sender, EventArgs e)
        {
            string RoomType = "";

            int userAcc = Saveduserid;
            string searchchoice = "userid";
            int numdayStay = Convert.ToInt32(nudNumberOfDays.Value);
            bool flag;
            int priceRoom = 0;



            flag = false;
            if (rbTypeSAssignR.Checked) { RoomType = "Standard"; flag = true; priceRoom = 19; }
            else if (rbTypePAssignR.Checked) { RoomType = "Presidential"; flag = true; priceRoom = 299; }
            else if (rbTypeLAssignR.Checked) { RoomType = "Lexury"; flag = true; priceRoom = 49; }
            else { MessageBox.Show("Please choose one of room types."); flag = false; }
            if (flag)
            {
                DBAccess objdBAccess = new DBAccess();
                DataTable dt = new DataTable();
                SqlCommand lOGINcmd = new SqlCommand();
                lOGINcmd.CommandText = "select * from useracc where " + searchchoice + "= @userAcc and status!='onhold'and status!='deactivated' and status!='active' ;";
                lOGINcmd.Parameters.AddWithValue("@userAcc", userAcc);
                //  lOGINcmd.Parameters.AddWithValue("@searchchoice", searchchoice);
                objdBAccess.readDatathroughAdapterSql(lOGINcmd, dt);

                if (dt.Rows.Count == 1)
                {

                    if (flag)
                    {

                        DataTable dtUsers = new DataTable();

                        int cidnum = Convert.ToInt32(dt.Rows[0]["userid"]);

                        string cmd = "UPDATE TOP (1) rooms SET Ruserid = @cidnum, isTaken = 'FALSE', isBooked = 'TRUE' WHERE (roomType = @RoomType) AND (isTaken = 'FALSE' OR isTaken= NULL )  AND (isBooked!='TRUE' or isBooked is  NULL );";

                        SqlCommand updatecmd = new SqlCommand(cmd);
                        updatecmd.Parameters.AddWithValue("@RoomType", RoomType);
                        updatecmd.Parameters.AddWithValue("@cidnum", cidnum);




                        int row = objdBAccess.executeQuery(updatecmd);
                        if (row > 0)
                        {
                            DBAccess objdBAccess1 = new DBAccess();

                            string cmd1 = "Update useracc set status='onhold' where userid = @cidnum; ";
                            SqlCommand updatecmd1 = new SqlCommand(cmd1);
                            updatecmd1.Parameters.AddWithValue("@cidnum", cidnum);
                            int row1 = objdBAccess1.executeQuery(updatecmd1);
                            if (row1 > 0)
                            {
                                MessageBox.Show("Sucessfully booked room.", "success", MessageBoxButtons.OK);
                                int TotalAmountDue = priceRoom * numdayStay;
                                string cmd2 = "Update usersinfo set numOfDaysToStay=@numdayStay, totalAmountDue=@TotalAmountDue where accid = @cidnum; ";
                                SqlCommand updatecmd2 = new SqlCommand(cmd2);
                                updatecmd2.Parameters.AddWithValue("@cidnum", cidnum);
                                updatecmd2.Parameters.AddWithValue("@numdayStay", numdayStay);
                                updatecmd2.Parameters.AddWithValue("@TotalAmountDue", TotalAmountDue);

                                objdBAccess1.executeQuery(updatecmd2);
                                pnlMakeReservation.Visible = false;
                                pnlCustomerMenu.Visible = true;


                                nudNumberOfDays.Value = 1;
                                rbTypeSAssignR.Checked = false;
                                rbTypePAssignR.Checked = false;
                                rbTypeLAssignR.Checked = false;


                            }
                            else
                            {
                                MessageBox.Show("error in account table");
                            }

                        }
                        else
                        {
                            MessageBox.Show("all rooms are reserved, change type of room", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }


                }
                else
                {
                    MessageBox.Show("Not Allowed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }



        }

        private void btnBacktoMMCAmenu_Click(object sender, EventArgs e)
        {
            pnlMakeReservation.Visible = false;
            pnlCustomerMenu.Visible = true;


            nudNumberOfDays.Value = 1;
            rbTypeSAssignR.Checked = false;
            rbTypePAssignR.Checked = false;
            rbTypeLAssignR.Checked = false;
        }

        private void btnMakeReservation_Click(object sender, EventArgs e)
        {
            pnlMakeReservation.Visible = true;
            pnlCustomerMenu.Visible = false;


            nudNumberOfDays.Value = 1;
            rbTypeSAssignR.Checked = false;
            rbTypePAssignR.Checked = false;
            rbTypeLAssignR.Checked = false;
        }

        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- View/Available/Rooms ----###########/////////////////
        /// //////////////##############History of customers or already booked before()#############/////////////////
        /// </summary>
        /// 

        private void btnViewAvailableRoom_Click(object sender, EventArgs e)
        {
            pnlCustomerMenu.Visible = false;
            pnlViewAvailableRooms.Visible = true;

            DBAccess objdBAccess = new DBAccess();
            DataTable dtusers = new DataTable();
            string query = "select roomNumber,roomType,pricePerNight from rooms where isTaken=0 and (isBooked is null or isBooked=0)";
            objdBAccess.readDatathroughAdapter(query, dtusers);
            dgvViewAvailableR.DataSource = dtusers;
            dgvViewAvailableR.ReadOnly = true;
            dgvViewAvailableR.AllowUserToAddRows = false;
            dgvViewAvailableR.AllowUserToDeleteRows = false;

            objdBAccess.closeConn();
        }

        private void btnBacktoMMviewAvailableR_Click(object sender, EventArgs e)
        {
            pnlCustomerMenu.Visible = true;
            pnlViewAvailableRooms.Visible = false;
        }

        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- activate/deactivate ----###########/////////////////
        /// //////////////##############History of customers or already booked before()#############/////////////////
        /// </summary>
        /// 
        private void btnDRactivateCA_Click(object sender, EventArgs e)
        {
            pnlCustomerMenu.Visible = false;
            pnlChangeAccountStatusAD.Visible = true;


            DataGridViewButtonColumn activateButtonColumn = new DataGridViewButtonColumn();
            activateButtonColumn.Name = "Activate";
            activateButtonColumn.Text = "Activate";
            activateButtonColumn.UseColumnTextForButtonValue = true;



            DataGridViewButtonColumn deactivateButtonColumn = new DataGridViewButtonColumn();
            deactivateButtonColumn.Name = "Deactivate";
            deactivateButtonColumn.Text = "Deactivate";
            deactivateButtonColumn.UseColumnTextForButtonValue = true;

            if (dgvActivateDeactivate.Columns.Count == 3)
            {
                dgvActivateDeactivate.Columns.Add(deactivateButtonColumn);
                dgvActivateDeactivate.Columns.Add(activateButtonColumn);
            }

            dgvADLoadData();



        }
        private void dgvADLoadData()
        {
            DBAccess objdBAccess = new DBAccess();
            DataTable dtusers1 = new DataTable();

            string query1 = "select userid,fname,status from useracc, usersinfo where useracc.userid=usersinfo.accid and userid=" + Saveduserid + " ;";
            objdBAccess.readDatathroughAdapter(query1, dtusers1);
            dgvActivateDeactivate.AutoGenerateColumns = false;
            dgvActivateDeactivate.DataSource = dtusers1;
        }

        private void btnBacktoMMActivateDeactivate_Click(object sender, EventArgs e)
        {
            pnlCustomerMenu.Visible = true;
            pnlChangeAccountStatusAD.Visible = false;
        }

        private void dgvActivateDeactivate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DBAccess objdBAccess = new DBAccess();
                DataTable dtusers1 = new DataTable();

                string query1 = "select userid,fname,status,whoDeactivatedAccount from useracc, usersinfo where useracc.userid=usersinfo.accid and userid=" + Saveduserid + " ;";
                objdBAccess.readDatathroughAdapter(query1, dtusers1);
                /* string checkwho = dtusers1.Rows[0]["whoDeactivatedAccount"].ToString();
                 bool ffflag = true;
                 ffflag = (checkwho == "admin") ?  false : true;
                 if (ffflag)
                 {*/
                int username = Convert.ToInt32(dgvActivateDeactivate.Rows[e.RowIndex].Cells["ADUserId"].Value);
                string removeBookingifOnHold = dgvActivateDeactivate.Rows[e.RowIndex].Cells["ADStatus"].Value.ToString();




                if (dgvActivateDeactivate.Columns[e.ColumnIndex].Name == "Deactivate")
                {

                    if (MessageBox.Show("Are You Sure You Want To Deactivate This Account?", "Change Account Status",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DBAccess objdBAccess1 = new DBAccess();

                        string cmd1 = "Update useracc set status='deactivated' where userid = @cidnum; ";
                        SqlCommand updatecmd1 = new SqlCommand(cmd1);
                        updatecmd1.Parameters.AddWithValue("@cidnum", username);
                        int row1 = objdBAccess1.executeQuery(updatecmd1);

                        if (row1 == 1)
                        {
                            string who = "own";
                            //string reason = Microsoft.VisualBasic.Interaction.InputBox("Reason for Deactivation:", "Input", "");
                            string reason = "";
                            string cmd21 = "Update usersinfo set whoDeactivatedAccount=@who where accid = @cidnum; ";

                            //string AdminReason = " deactivatedReason = @reason + '; ' + ISNULL(deactivatedReason, '')";
                            SqlCommand updatecmd21 = new SqlCommand(cmd21);
                            updatecmd21.Parameters.AddWithValue("@cidnum", username);
                            updatecmd21.Parameters.AddWithValue("@reason", reason);
                            updatecmd21.Parameters.AddWithValue("@who", who);
                            objdBAccess1.executeQuery(updatecmd21);
                            ///////if the status is onhold booking will be removed)
                            string msg = "";
                            if (removeBookingifOnHold == "onhold")
                            {
                                string cmd = "UPDATE rooms SET Ruserid = NULL,  isBooked = NULL WHERE (Ruserid = @cidnum);";

                                SqlCommand updatecmd111 = new SqlCommand(cmd);

                                updatecmd111.Parameters.AddWithValue("@cidnum", username);
                                objdBAccess1.executeQuery(updatecmd111);
                                string cmd2 = "Update usersinfo set numOfDaysToStay=Null, totalAmountDue=0 where accid = @cidnum; ";
                                SqlCommand updatecmd2 = new SqlCommand(cmd2);
                                updatecmd2.Parameters.AddWithValue("@cidnum", username);
                                objdBAccess1.executeQuery(updatecmd2);
                                msg = ".\n Room Reservation has been canceled.";
                            }
                           
                            MessageBox.Show("Account Deactivated " + msg, "Account Access Control", MessageBoxButtons.OK, MessageBoxIcon.Warning);




                            dgvADLoadData();
                        }
                        else
                        {
                            MessageBox.Show("Account Deactivation Failed", "Account Access Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (dgvActivateDeactivate.Columns[e.ColumnIndex].Name == "Activate")
                {
                    objdBAccess = new DBAccess();
                    DataTable dtusersSC1 = new DataTable();
                    string query2 = "select * from useracc where userid=" + Saveduserid + " and status='deactivated';";
                    objdBAccess.readDatathroughAdapter(query2, dtusersSC1);

                    if (dtusersSC1.Rows.Count == 1)
                    { 

                        if (MessageBox.Show("Are You Sure You Want To Activate This Account?", "Change Account Status",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DBAccess objdBAccess1 = new DBAccess();

                            string cmd1 = "Update useracc set status='inactive' where userid = @cidnum; ";
                            SqlCommand updatecmd1 = new SqlCommand(cmd1);
                            updatecmd1.Parameters.AddWithValue("@cidnum", username);
                            int row1 = objdBAccess1.executeQuery(updatecmd1);

                            if (row1 == 1)
                            {
                                MessageBox.Show("Account Activated", "Account Access Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvADLoadData();
                            }
                            else
                            {
                                MessageBox.Show("Account Activation Failed", "Account Access Control", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Must first be deactivated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                
            }


        }

        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- update/info ----###########/////////////////
        /// //////////////##############History of customers or already booked before()#############/////////////////
        /// </summary>
        private void updateinfoLoad()
        {

            DBAccess objdBAccess = new DBAccess();
            DataTable dtusersSC1 = new DataTable();
            string query2 = "select username,userid,password,status,fname,lname,age,phone,gender,HistorySummary,whoDeactivatedAccount,deactivatedReason,created_at from useracc, usersinfo where useracc.userid=usersinfo.accid AND accid=" + Saveduserid + ";";
            objdBAccess.readDatathroughAdapter(query2, dtusersSC1);

            txtUuserid.Text = dtusersSC1.Rows[0]["userid"].ToString();
            txtUuserStatus.Text = dtusersSC1.Rows[0]["status"].ToString();
            txtMFirstName.Text = dtusersSC1.Rows[0]["fname"].ToString();
            txtMLastName.Text = dtusersSC1.Rows[0]["lname"].ToString();
            txtMAge.Text = dtusersSC1.Rows[0]["age"].ToString();
            combMGender.Text = dtusersSC1.Rows[0]["gender"].ToString();
            txtMPhone.Text = dtusersSC1.Rows[0]["phone"].ToString();
            txtUusername.Text = dtusersSC1.Rows[0]["username"].ToString();
            txtUuserPassword.Text = dtusersSC1.Rows[0]["password"].ToString();
        }
        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            pnlUpdateInfo.Visible = true;
            pnlCustomerMenu.Visible = false;
            updateinfoLoad();
            DBAccess objdBAccess = new DBAccess();
            DataTable dt = new DataTable();
            SqlCommand lOGINcmd = new SqlCommand();
            lOGINcmd.CommandText = "select roomNumber,isBooked,isTaken,roomType,pricePerNight,numOfDaysToStay,totalAmountDue from useracc,usersinfo, rooms where usersinfo.accid=useracc.userid and rooms.Ruserid=usersinfo.accid and Ruserid=" + Saveduserid + ";";
            objdBAccess.readDatathroughAdapterSql(lOGINcmd, dt);

            dgvBookingInfo.ReadOnly = true;
            dgvBookingInfo.AllowUserToAddRows = false;
            dgvBookingInfo.AllowUserToDeleteRows = false;
            dgvBookingInfo.DataSource= dt;


        }

        private void btnMSave_Click(object sender, EventArgs e)
        {

            string userfName = txtMFirstName.Text;
            string userlName = txtMLastName.Text;
            string userAge = txtMAge.Text;
            string userGender = combMGender.Text;
            string userPhone = txtMPhone.Text;
            string updatePass = txtUuserPassword.Text;

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
            else if (userAge.Equals(""))
            {
                MessageBox.Show("Please enter your Age.");
            }
            else if (userGender.Equals(""))
            {
                MessageBox.Show("Please select your Type.");
            }
            else
            {
                //to check if username already exists
                DBAccess objdBAccess = new DBAccess();
                string checkUserName1 = userfName + "_" + userPhone + "@" + userAge;
                DataTable dt1 = new DataTable();
                SqlCommand lOGINcmd1 = new SqlCommand();
                lOGINcmd1.CommandText = "select * from useracc where username = @userName;";
                lOGINcmd1.Parameters.AddWithValue("@userName", checkUserName1);
                objdBAccess.readDatathroughAdapterSql(lOGINcmd1, dt1);
                
                 objdBAccess = new DBAccess();
                string checkUserName = userfName + "_" + userPhone + "@" + userAge;
                DataTable dt = new DataTable();
                SqlCommand lOGINcmd = new SqlCommand();
                lOGINcmd.CommandText = "select password,username,gender from useracc,usersinfo where usersinfo.accid=useracc.userid and username = @userName;";
                lOGINcmd.Parameters.AddWithValue("@userName", checkUserName);
                objdBAccess.readDatathroughAdapterSql(lOGINcmd, dt);

                if (dt.Rows.Count == 1)
                {
                    if ((dt.Rows[0]["password"].ToString() != updatePass) || (dt.Rows[0]["gender"].ToString() != userGender))
                    {
                        lblnotifySignUP.Text = "";
                        
                        string inscmd = "update usersinfo set lname=@userlName,gender=@userGender  where accid=" + Saveduserid + ";";
                        SqlCommand insertcmd = new SqlCommand(inscmd);
                        insertcmd.Parameters.AddWithValue("@userfName", userfName);
                        insertcmd.Parameters.AddWithValue("@userlName", userlName);
                        insertcmd.Parameters.AddWithValue("@userAge", userAge);
                        insertcmd.Parameters.AddWithValue("@userPhone", userPhone);
                        insertcmd.Parameters.AddWithValue("@userGender", userGender);
                        int row = objdBAccess.executeQuery(insertcmd);


                        if (row > 0)
                        {
                            string cUserName = userfName + "_" + userPhone + "@" + userAge;
                            string Query = "";
                            string msg = "";
                            if (dt1.Rows.Count == 0)
                            {
                                Query = "update useracc set username=@cUserName,password=@updatePass where userid=" + Saveduserid + " ;";
                                SqlCommand acinsertcmd = new SqlCommand(Query);
                                 acinsertcmd.Parameters.AddWithValue("@cUserName", cUserName);
                                acinsertcmd.Parameters.AddWithValue("@updatePass", updatePass);
                                objdBAccess.executeQuery(acinsertcmd);
                                
                            }
                            else
                            {
                                Query = "update useracc set password=@updatePass where userid=" + Saveduserid + " ;";
                                SqlCommand acinsertcmd = new SqlCommand(Query);
                                acinsertcmd.Parameters.AddWithValue("@updatePass", updatePass);
                                msg = "only username cant be updated because its already existing.";
                                objdBAccess.executeQuery(acinsertcmd);
                            }





                            updateinfoLoad();
                            MessageBox.Show("*Updated sucessfully*" +$"\n{msg}", "success", MessageBoxButtons.OK);
                            
                            objdBAccess.closeConn();

                        }
                        else
                        {
                            MessageBox.Show(" Unsucessfully..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        lblnotifySignUP.Text = "account with the following details already availalbe";
                    }

                }
                
                else if (dt.Rows.Count == 0 && dt1.Rows.Count ==0)
                {


                    lblnotifySignUP.Text = "";


                    string inscmd = "update usersinfo set fname=@userfName,lname=@userlName,age=@userAge,phone=@userPhone,gender=@userGender  where accid=" + Saveduserid + ";";
                    SqlCommand insertcmd = new SqlCommand(inscmd);
                    insertcmd.Parameters.AddWithValue("@userfName", userfName);
                    insertcmd.Parameters.AddWithValue("@userlName", userlName);
                    insertcmd.Parameters.AddWithValue("@userAge", userAge);
                    insertcmd.Parameters.AddWithValue("@userPhone", userPhone);
                    insertcmd.Parameters.AddWithValue("@userGender", userGender);
                    int row = objdBAccess.executeQuery(insertcmd);


                    if (row > 0)
                    {
                        string cUserName = userfName + "_" + userPhone + "@" + userAge;
                        string Query = "update useracc set username=@cUserName,password=@updatePass where userid=" + Saveduserid + " ;";
                        SqlCommand acinsertcmd = new SqlCommand(Query);
                        acinsertcmd.Parameters.AddWithValue("@cUserName", cUserName);
                        acinsertcmd.Parameters.AddWithValue("@updatePass", updatePass);


                        objdBAccess.executeQuery(acinsertcmd);
                        //to get id 
                        DataTable dtt = new DataTable();
                        SqlCommand llOGINcmd = new SqlCommand();
                        llOGINcmd.CommandText = "select * from useracc where username = @cUserName;";
                        llOGINcmd.Parameters.AddWithValue("@cUserName", cUserName);
                        objdBAccess.readDatathroughAdapterSql(llOGINcmd, dtt);
                        int uid = Convert.ToInt32(dtt.Rows[0]["userid"]);

                        MessageBox.Show("Updated sucessfully\n use the following new details\n user-id: " + uid + "\n username: '" + cUserName + "'  \n password" + updatePass + " ", "success", MessageBoxButtons.OK);
                        updateinfoLoad();
                        objdBAccess.closeConn();

                    }
                    else
                    {
                        MessageBox.Show(" Unsucessfully..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

                
                else
                {
                    MessageBox.Show("username already exists. Not allowed to change.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }


            }
        }

        private void dtpicker_ValueChanged(object sender, EventArgs e)
        {
            txtMAge.Text = Convert.ToString((DateTime.Now.Year - dtpicker.Value.Year));
        }

        //BACK BackToMRoom FROM Register Customer
        private void btnBackToMRA_Click(object sender, EventArgs e)
        {
            pnlCustomerMenu.Visible = true;
            pnlUpdateInfo.Visible = false;

            txtMFirstName.Text = "";
            txtMLastName.Text = "";
            txtMAge.Text = " ";
            combMGender.Text = " ";
            txtMPhone.Text = "";
            dtpicker.Value = DateTime.Now;
        }

        private void btnCancelRoomUpdate_Click(object sender, EventArgs e)
        {
            DBAccess objdBAccess1 = new DBAccess();
            DataTable dt = new DataTable();
            SqlCommand lOGINcmd = new SqlCommand();
            lOGINcmd.CommandText = "select roomNumber,isBooked,isTaken,roomType,pricePerNight,numOfDaysToStay,totalAmountDue,Ruserid from useracc,usersinfo, rooms where usersinfo.accid=useracc.userid and rooms.Ruserid=usersinfo.accid and (isTaken=0 or isTaken!=null) and (isBooked=1) and Ruserid=" + Saveduserid + ";";
            objdBAccess1.readDatathroughAdapterSql(lOGINcmd, dt);

            if (dt.Rows.Count > 0)
            {
                string cmd1 = "BEGIN TRANSACTION;" +
                    "UPDATE rooms SET Ruserid = NULL,    isBooked = NULL WHERE Ruserid =" + Saveduserid + ";" +
                    " UPDATE useracc SET status = 'inactive' WHERE userid = (SELECT accid  FROM usersinfo    WHERE accid =" + Saveduserid + ");" +
                    " UPDATE usersinfo SET numOfDaysToStay = NULL,  totalAmountDue = NULL WHERE accid =" + Saveduserid + ";" +
                    "COMMIT TRANSACTION; ";

                SqlCommand updatecmd1 = new SqlCommand(cmd1);
                int row1 = objdBAccess1.executeQuery(updatecmd1);

                if (row1 > 0)
                {
                     dt = new DataTable();
                    lOGINcmd = new SqlCommand();
                    lOGINcmd.CommandText = "select roomNumber,isBooked,isTaken,roomType,pricePerNight,numOfDaysToStay,totalAmountDue,Ruserid from useracc,usersinfo, rooms where usersinfo.accid=useracc.userid and rooms.Ruserid=usersinfo.accid and (isTaken=0 or isTaken!=null) and (isBooked=1) and Ruserid=" + Saveduserid + ";";
                    objdBAccess1.readDatathroughAdapterSql(lOGINcmd, dt);
                    dgvBookingInfo.DataSource = dt;
                    MessageBox.Show("Cancelled Succesfully");
                    updateinfoLoad();
                }
            }
            else
            {
                MessageBox.Show("Not Allowed!");
            }
        }

    }
}
