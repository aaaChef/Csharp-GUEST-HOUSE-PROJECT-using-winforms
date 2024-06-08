using Microsoft.Data.SqlClient;
using System;
using System.CodeDom;
using System.Collections;
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

    public partial class AdminForm : Form
    {
        string RoomType;
        double PricePerNight;

        DBAccess objdBAccess = new DBAccess();
        DataTable dtUsers = new DataTable();
        public AdminForm()
        {
            InitializeComponent();
            //dgvViewAllR.CellContentClick += DataGridViewCellEventHandler(dgvViewAllR_CellContentClick1);


        }
        private void AdminForm_Load(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = true;
            pnlActDeaCus.Visible = false;
            pnlCheckIn.Visible = false;
            pnlCheckOut.Visible = false;
            pnlGuestSummary.Visible = false;
            pnlSearchCust.Visible = false;
            pnlViewAllCustomers.Visible = false;
            pnlViewAllR.Visible = false;
            pnlViewAvailableR.Visible = false;
            pnlManageRoom.Visible = false;

            pnlMRegisterCustomer.Visible = false;
            pnlMAddNewRoom.Visible = false;
            pnlMAssignRoomCustomerReservation.Visible = false;



        }


        private void linklblBacktoLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- Manage/Room ----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>
        /// /////-----------  -------------/////////////
        //MANAGE ROOM MENU
        private void btnmManageRoom_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = false;
            pnlManageRoom.Visible = true;

        }


        //BACK MAIN MENU
        private void btnMBacktoMM_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = true;
            pnlManageRoom.Visible = false;
        }
        //TO ENTER INSIDE  ADD ROOM
        private void btnMaddR_Click(object sender, EventArgs e)
        {
            pnlMAddNewRoom.Visible = true;
            pnlManageRoom.Visible = false;
        }
        //INSIDE ADD ROOM
        private void btnAddRoom_Click(object sender, EventArgs e)
        {

            bool flag = false;
            if (rbTypeP.Checked)
            {
                RoomType = "Presidential";
                PricePerNight = 299;
                flag = true;
            }
            else if (rbTypeL.Checked)
            {
                RoomType = "Lexury";
                PricePerNight = 49;
                flag = true;
            }
            else if (rbTypeS.Checked)
            {
                RoomType = "Standard";
                PricePerNight = 19;
                flag = true;
            }
            else
            {
                MessageBox.Show("please choose one of room type");
            }

            if (flag)
            {
                rbTypeS.Checked = false;
                rbTypeL.Checked = false;
                rbTypeP.Checked = false;
                
                //to insert data
                string inscmd = "insert into rooms(isTaken,roomType,pricePerNight) values ('FALSE',@RoomType,@PricePerNight);";
                SqlCommand insertcmd = new SqlCommand(inscmd);
                insertcmd.Parameters.AddWithValue("@PricePerNight", PricePerNight);
                insertcmd.Parameters.AddWithValue("@RoomType", RoomType);
               

                int row = objdBAccess.executeQuery(insertcmd);
                // end of data insertion
                //to read

                if (row > 0)
                {
                    //below needed
                    MessageBox.Show("Room Addition is sucessfull\n " +
                        PricePerNight + "\n" +
                        RoomType + "\n" +
                        "\n", "success", MessageBoxButtons.OK);

                }
                else
                {
                    MessageBox.Show("Room Addition is unsucessfull", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


            }


        }
        //BACK BackToMRoom FROM ADD ROOM

        private void btnBackToMRoom_Click(object sender, EventArgs e)
        {
            pnlMAddNewRoom.Visible = false;
            pnlManageRoom.Visible = true;

            rbTypeS.Checked = false;
            rbTypeL.Checked = false;
            rbTypeP.Checked = false;
        }
        //INSIDE ADD NEW CUSTOMER
        private void btnMSave_Click(object sender, EventArgs e)
        {

            string userfName = txtMFirstName.Text;
            string userlName = txtMLastName.Text;
            string userAge = txtMAge.Text;
            string userGender = combMGender.Text;
            string userPhone = txtMPhone.Text;


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

                        objdBAccess.closeConn();
                        txtMFirstName.Text = "";
                        txtMLastName.Text = "";
                        txtMAge.Text = "";
                        combMGender.Text = default;
                        txtMPhone.Text = "";
                        dtpicker.Value = DateTime.Now;
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
            txtMAge.Text = Convert.ToString((DateTime.Now.Year - dtpicker.Value.Year));
        }

        //BACK BackToMRoom FROM Register Customer
        private void btnBackToMRA_Click(object sender, EventArgs e)
        {
            pnlManageRoom.Visible = true;
            pnlMRegisterCustomer.Visible = false;

            txtMFirstName.Text = "";
            txtMLastName.Text = "";
            txtMAge.Text = " ";
            combMGender.Text = " ";
            txtMPhone.Text = "";
            dtpicker.Value = DateTime.Now;
        }

        //TO ENTER INSIDE  Register Customer
        private void btnMRegC_Click(object sender, EventArgs e)
        {
            pnlManageRoom.Visible = false;
            pnlMRegisterCustomer.Visible = true;

            txtMFirstName.Text = "";
            txtMLastName.Text = "";
            txtMAge.Text = "";
            combMGender.Text = " ";
            txtMPhone.Text = "";
            dtpicker.Value = DateTime.Now;
        }

        //TO ENTER INSIDE  assign room to Customer
        private void btnMAssignRoom_Click(object sender, EventArgs e)
        {

            pnlMAssignRoomCustomerReservation.Visible = true;
            pnlManageRoom.Visible = false;
            txtSearchAccAssignR.Text = "";
            txtSearchAccAssignR.Visible = false;
            txtSearchAccAssignR.ReadOnly = true;
            txtSearchAccAssignR.BorderStyle = BorderStyle.None;

            txtSearchAccAssignR.Clear(); // Clear the textbox
            txtSearchAccAssignR.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                               // Set event handler to allow any input (no validation)
            txtSearchAccAssignR.KeyPress += (s, ev) => { };

        }


        //radio button inside assign room to fix the textbox
        private void rbuserNameAssignR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbuserNameAssignR.Checked)
            {
                txtSearchAccAssignR.Text = "";
                txtSearchAccAssignR.Visible = true;
                txtSearchAccAssignR.ReadOnly = false;
                txtSearchAccAssignR.BorderStyle = BorderStyle.Fixed3D;
                txtSearchAccAssignR.Clear(); // Clear the textbox
                txtSearchAccAssignR.KeyPress -= AllowNumericInput; // Remove any existing event handler
                // Set event handler to allow any input (no validation)
                txtSearchAccAssignR.KeyPress += (s, ev) => { };
            }
        }
        private void rbuserIDAssignR_CheckedChanged(object sender, EventArgs e)
        {
            if (rbuserIDAssignR.Checked)
            {
                txtSearchAccAssignR.Text = "";
                txtSearchAccAssignR.Visible = true;
                txtSearchAccAssignR.ReadOnly = false;
                txtSearchAccAssignR.BorderStyle = BorderStyle.Fixed3D;

                txtSearchAccAssignR.Clear(); // Clear the textbox
                                             //txtSearchAccAssignR.KeyPress -= AllowNonNumericInput; // Remove any existing event handler
                txtSearchAccAssignR.KeyPress -= (s, ev) => { };
                txtSearchAccAssignR.KeyPress += AllowNumericInput; // Set event handler to allow only numeric input
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
        //INSIDE ADD NEW CUSTOMER
        private void btnSaveAssignR_Click(object sender, EventArgs e)
        {
            string userAcc = txtSearchAccAssignR.Text;
            string searchchoice = "";
            int numdayStay = Convert.ToInt32(nudNumberOfDays.Value);
            bool flag = false;
            int priceRoom = 0;
            if (rbuserIDAssignR.Checked)
            {
                searchchoice = "userid";
                flag = true;
            }
            else if (rbuserNameAssignR.Checked)
            {
                searchchoice = "username";
                flag = true;
            }
            else
            {
                MessageBox.Show("please choose search type first");
            }

            if (flag)
            {
                flag = true;

                if (userAcc == "")
                {
                    MessageBox.Show("Please enter your account info.");
                    flag = false;
                }
                if (flag)
                {
                    flag = false;
                    if (rbTypeSAssignR.Checked) { RoomType = "Standard"; flag = true; priceRoom = 19; }
                    else if (rbTypePAssignR.Checked) { RoomType = "Presidential"; flag = true; priceRoom = 299; }
                    else if (rbTypeLAssignR.Checked) { RoomType = "Lexury"; flag = true; priceRoom = 49; }
                    else { MessageBox.Show("Please choose one of room types."); flag = false; }
                    if (flag)
                    {

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
                                DBAccess objdBAccess = new DBAccess();
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
                                        MessageBox.Show("Room assigned sucessfully", "success", MessageBoxButtons.OK);
                                        int TotalAmountDue = priceRoom * numdayStay;
                                        string cmd2 = "Update usersinfo set numOfDaysToStay=@numdayStay, totalAmountDue=@TotalAmountDue where accid = @cidnum; ";
                                        SqlCommand updatecmd2 = new SqlCommand(cmd2);
                                        updatecmd2.Parameters.AddWithValue("@cidnum", cidnum);
                                        updatecmd2.Parameters.AddWithValue("@numdayStay", numdayStay);
                                        updatecmd2.Parameters.AddWithValue("@TotalAmountDue", TotalAmountDue);

                                        objdBAccess1.executeQuery(updatecmd2);
                                        rbuserNameAssignR.Checked = false;
                                        rbuserIDAssignR.Checked = false;
                                        nudNumberOfDays.Value = 1;
                                        txtSearchAccAssignR.Text = "";
                                        txtSearchAccAssignR.Visible = false;
                                        txtSearchAccAssignR.ReadOnly = true;
                                        txtSearchAccAssignR.BorderStyle = BorderStyle.None;
                                        txtSearchAccAssignR.Clear(); // Clear the textbox
                                        txtSearchAccAssignR.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                                                           // Set event handler to allow any input (no validation)
                                        txtSearchAccAssignR.KeyPress += (s, ev) => { };

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
            }
        }

        private void btnBacktoMRAssignR_Click(object sender, EventArgs e)
        {
            pnlMAssignRoomCustomerReservation.Visible = false;
            pnlManageRoom.Visible = true;
            rbuserNameAssignR.Checked = false;
            rbuserIDAssignR.Checked = false;
            txtSearchAccAssignR.Text = "";
            txtSearchAccAssignR.Visible = false;
            txtSearchAccAssignR.ReadOnly = true;
            txtSearchAccAssignR.BorderStyle = BorderStyle.None;
            nudNumberOfDays.Value = 1;

            txtSearchAccAssignR.Clear(); // Clear the textbox
            txtSearchAccAssignR.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                               // Set event handler to allow any input (no validation)
            txtSearchAccAssignR.KeyPress += (s, ev) => { };

            rbTypeSAssignR.Checked = false;
            rbTypePAssignR.Checked = false;
            rbTypeLAssignR.Checked = false;
        }


        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- CHECK/IN ----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>

        private void btnCheckIN_Click(object sender, EventArgs e)
        {

            //customer status is onhold or not
            //room is assigned or not to that specific cutomer 
            //calculate number of days to stay accept payment 
            // update status of customer and room

            pnlAdminMenu.Visible = false;
            pnlCheckIn.Visible = true;
            pnlCheckInPayment.Visible = false;
            lblCheckINaskPAYMENT.Text = "";

            txtCheckInSCustomer.Text = "";
            txtCheckInSCustomer.Visible = false;
            txtCheckInSCustomer.ReadOnly = true;
            txtCheckInSCustomer.BorderStyle = BorderStyle.None;
            txtCheckInSCustomer.Clear(); // Clear the textbox
            txtCheckInSCustomer.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                               // Set event handler to allow any input (no validation)
            txtCheckInSCustomer.KeyPress += (s, ev) => { };


        }

        private void rbcCheckInUID_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcCheckInUID.Checked)
            {
                txtCheckInSCustomer.Visible = true;
                txtCheckInSCustomer.ReadOnly = false;
                txtCheckInSCustomer.BorderStyle = BorderStyle.Fixed3D;
                txtCheckInSCustomer.Clear(); // Clear the textbox


                txtCheckInSCustomer.Clear(); // Clear the textbox
                                             //txtSearchAccAssignR.KeyPress -= AllowNonNumericInput; // Remove any existing event handler
                txtCheckInSCustomer.KeyPress -= (s, ev) => { };
                txtCheckInSCustomer.KeyPress += AllowNumericInput; // Set event handler to allow only numeric input
            }
        }

        private void rbcCheckInUNAME_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcCheckInUNAME.Checked)
            {
                txtCheckInSCustomer.Visible = true;
                txtCheckInSCustomer.ReadOnly = false;
                txtCheckInSCustomer.BorderStyle = BorderStyle.Fixed3D;
                txtCheckInSCustomer.Clear(); // Clear the textbox


                txtCheckInSCustomer.Clear(); // Clear the textbox
                txtCheckInSCustomer.KeyPress -= AllowNumericInput; // Remove any existing event handler
                // Set event handler to allow any input (no validation)
                txtCheckInSCustomer.KeyPress += (s, ev) => { };
            }

        }


        private int totalCkinPay;
        string searchchoice = "";
        int cidnum = 0;
        private void btnCinSearchCustomr_Click(object sender, EventArgs e)
        {
            string userAcc = txtCheckInSCustomer.Text;
            string searchchoice = "";
            bool flag = false;
            if (rbcCheckInUID.Checked)
            {
                searchchoice = "userid";
                flag = true;
            }
            else if (rbcCheckInUNAME.Checked)
            {
                searchchoice = "username";
                flag = true;
            }
            else
            {
                MessageBox.Show("please choose search type first");
            }

            if (flag)
            {
                flag = true;

                if (userAcc == "")
                {
                    MessageBox.Show("Please enter your account info.");
                    flag = false;
                }
                if (flag)
                {

                    DataTable dt = new DataTable();
                    SqlCommand lOGINcmd = new SqlCommand();
                    lOGINcmd.CommandText = "select * from useracc where " + searchchoice + "= @userAcc and status='onhold' and status!='deactivated';";
                    lOGINcmd.Parameters.AddWithValue("@userAcc", userAcc);
                    objdBAccess.readDatathroughAdapterSql(lOGINcmd, dt);

                    if (dt.Rows.Count == 1)
                    {

                        if (flag)
                        {
                            cidnum = Convert.ToInt32(dt.Rows[0]["userid"]);
                            DBAccess dBAccess = new DBAccess();
                            DataTable dtt = new DataTable();
                            SqlCommand llOGINcmd = new SqlCommand();
                            llOGINcmd.CommandText = "select * from usersinfo where accid= @cidnum ;";
                            llOGINcmd.Parameters.AddWithValue("@cidnum", cidnum);
                            dBAccess.readDatathroughAdapterSql(llOGINcmd, dtt);
                            totalCkinPay = Convert.ToInt32(dtt.Rows[0]["totalAmountDue"]);
                            pnlCheckInPayment.Visible = true;
                            lblCheckINaskPAYMENT.Text = "His Total Amount due is $" + totalCkinPay + "\n did you accept the money?";
                            txtCheckInSCustomer.ReadOnly = true;
                            rbcCheckInUNAME.Visible = false;
                            rbcCheckInUID.Visible = false;
                            label19.Visible = false;

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("error in user-account table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("No reservation availabe or account may be deactivated!!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }

        }


        private void backToMMfCheckin_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = true;
            pnlCheckIn.Visible = false;

            totalCkinPay = 0;
            txtCheckInSCustomer.Clear();
            rbcCheckInNO.Checked = false;
            rbcCheckInYES.Checked = false;
            pnlCheckInPayment.Visible = false;
            lblCheckINaskPAYMENT.Text = "";
            rbcCheckInUNAME.Checked = false;
            rbcCheckInUID.Checked = false;
            txtCheckInSCustomer.ReadOnly = false;
            rbcCheckInUNAME.Visible = true;
            rbcCheckInUID.Visible = true;
            label19.Visible = true;


            txtCheckInSCustomer.Text = "";
            txtCheckInSCustomer.Visible = false;
            txtCheckInSCustomer.ReadOnly = true;
            txtCheckInSCustomer.BorderStyle = BorderStyle.None;
            txtCheckInSCustomer.Clear(); // Clear the textbox
            txtCheckInSCustomer.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                               // Set event handler to allow any input (no validation)
            txtCheckInSCustomer.KeyPress += (s, ev) => { };



        }

        private void btnCheckINFinal_Click(object sender, EventArgs e)
        {
            string userAcc = txtCheckInSCustomer.Text;
            bool flag = false;
            if (rbcCheckInYES.Checked)
            {
                flag = true;
            }
            else if (rbcCheckInNO.Checked)
            {
                MessageBox.Show("Must pay first to check-in");
                flag = false;
            }
            else
            {
                MessageBox.Show("please select whether you accepted payment or not !");
            }


            if (flag)
            {
                DBAccess objdBAccess = new DBAccess();
                DataTable dtUsers = new DataTable();

                string cmd = "UPDATE TOP (1) rooms SET  isTaken = 'TRUE', isBooked = 'TRUE' WHERE Ruserid = @cidnum AND isBooked = 'TRUE';";

                SqlCommand updatecmd = new SqlCommand(cmd);
                updatecmd.Parameters.AddWithValue("@cidnum", cidnum);

                int row = objdBAccess.executeQuery(updatecmd);
                if (row > 0)
                {
                    DBAccess objdBAccess1 = new DBAccess();

                    string cmd1 = "Update useracc set status='active' where userid = @cidnum; ";
                    SqlCommand updatecmd1 = new SqlCommand(cmd1);
                    updatecmd1.Parameters.AddWithValue("@cidnum", cidnum);
                    int row1 = objdBAccess1.executeQuery(updatecmd1);
                    if (row1 > 0)
                    {
                        MessageBox.Show("Room assigned sucessfully", "success", MessageBoxButtons.OK);
                        int TotalAmountDue = 0;
                        string cmd2 = "Update usersinfo set totalAmountDue=@TotalAmountDue where accid = @cidnum; ";
                        SqlCommand updatecmd2 = new SqlCommand(cmd2);
                        updatecmd2.Parameters.AddWithValue("@cidnum", cidnum);
                        updatecmd2.Parameters.AddWithValue("@TotalAmountDue", TotalAmountDue);

                        objdBAccess1.executeQuery(updatecmd2);
                        totalCkinPay = 0;
                        txtCheckInSCustomer.Clear();
                        rbcCheckInNO.Checked = false;
                        rbcCheckInYES.Checked = false;
                        pnlCheckInPayment.Visible = false;
                        lblCheckINaskPAYMENT.Text = "";
                        rbcCheckInUNAME.Checked = false;
                        rbcCheckInUID.Checked = false;
                        txtCheckInSCustomer.ReadOnly = false;
                        rbcCheckInUNAME.Visible = true;
                        rbcCheckInUID.Visible = true;
                        label19.Visible = true;

                        txtCheckInSCustomer.Text = "";
                        txtCheckInSCustomer.Visible = false;
                        txtCheckInSCustomer.ReadOnly = true;
                        txtCheckInSCustomer.BorderStyle = BorderStyle.None;

                    }
                    else
                    {
                        MessageBox.Show("error in user-account table");
                    }

                }
                else
                {
                    MessageBox.Show("error in rooms table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- View/Available/Room ----###########/////////////////
        /// //////////////############not booked or checked-in###############/////////////////
        /// </summary>

        private void btnViewAvailableRoom_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = false;
            pnlViewAvailableR.Visible = true;

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
            pnlAdminMenu.Visible = true;
            pnlViewAvailableR.Visible = false;
        }

        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- Search/Customers ----###########/////////////////
        /// //////////////##############)#############/////////////////
        /// </summary>

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {


            pnlAdminMenu.Visible = false;
            pnlSearchCust.Visible = true;
            pnlSCtoOP.Visible = false;

            txtSCsearchtextbox.Clear();

            txtSCsearchtextbox.Text = "";
            txtSCsearchtextbox.Visible = false;
            txtSCsearchtextbox.ReadOnly = true;
            txtSCsearchtextbox.BorderStyle = BorderStyle.None;

            txtSCsearchtextbox.Clear(); // Clear the textbox
            txtSCsearchtextbox.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                              // Set event handler to allow any input (no validation)
            txtSCsearchtextbox.KeyPress += (s, ev) => { };


            rbSCuserid.Checked = false;
            rbSCusername.Checked = false;
            txtSCsearchtextbox.ReadOnly = false;
            rbSCusername.Visible = true;
            rbSCuserid.Visible = true;
            label24.Visible = true;
            txtHistorySummary.Visible = false;
            lblHistorySummary.Visible = false;

        }

        private void rbSCuserid_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSCuserid.Checked)
            {
                txtSCsearchtextbox.Visible = true;
                txtSCsearchtextbox.ReadOnly = false;
                txtSCsearchtextbox.BorderStyle = BorderStyle.Fixed3D;
                txtSCsearchtextbox.Clear(); // Clear the textbox


                txtSCsearchtextbox.Clear(); // Clear the textbox
                                            //txtSearchAccAssignR.KeyPress -= AllowNonNumericInput; // Remove any existing event handler
                txtSCsearchtextbox.KeyPress -= (s, ev) => { };
                txtSCsearchtextbox.KeyPress += AllowNumericInput; // Set event handler to allow only numeric input
            }

        }

        private void rbSCusername_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSCusername.Checked)
            {
                txtSCsearchtextbox.Visible = true;
                txtSCsearchtextbox.ReadOnly = false;
                txtSCsearchtextbox.BorderStyle = BorderStyle.Fixed3D;
                txtSCsearchtextbox.Clear(); // Clear the textbox


                txtSCsearchtextbox.Clear(); // Clear the textbox
                txtSCsearchtextbox.KeyPress -= AllowNumericInput; // Remove any existing event handler
                // Set event handler to allow any input (no validation)
                txtSCsearchtextbox.KeyPress += (s, ev) => { };
            }

        }


        private void btnSCcheck_Click(object sender, EventArgs e)
        {

            string userAcc = txtSCsearchtextbox.Text;
            string searchchoice = "";
            bool flag = false;
            if (rbSCuserid.Checked)
            {
                searchchoice = "userid";
                flag = true;
            }
            else if (rbSCusername.Checked)
            {
                searchchoice = "username";
                flag = true;
            }
            else
            {
                MessageBox.Show("please choose search type first");
            }

            if (flag)
            {
                flag = true;

                if (userAcc == "")
                {
                    MessageBox.Show("Please enter your account info.");
                    flag = false;
                }
                if (flag)
                {

                    DataTable dt = new DataTable();
                    SqlCommand lOGINcmd = new SqlCommand();
                    lOGINcmd.CommandText = "select * from useracc where " + searchchoice + "= @userAcc;";
                    lOGINcmd.Parameters.AddWithValue("@userAcc", userAcc);
                    objdBAccess.readDatathroughAdapterSql(lOGINcmd, dt);

                    if (dt.Rows.Count == 1)
                    {

                        if (flag)
                        {
                            cidnum = Convert.ToInt32(dt.Rows[0]["userid"]);
                            DBAccess dBAccess = new DBAccess();
                            DataTable dtt = new DataTable();
                            SqlCommand llOGINcmd = new SqlCommand();
                            llOGINcmd.CommandText = "select * from usersinfo where accid= @cidnum ;";
                            llOGINcmd.Parameters.AddWithValue("@cidnum", cidnum);
                            dBAccess.readDatathroughAdapterSql(llOGINcmd, dtt);

                            pnlSCtoOP.Visible = true;
                            ////////filling the OP///////
                            DBAccess objdBAccess = new DBAccess();

                            DataTable dtusersSC = new DataTable();
                            string query1 = "select * from useracc, usersinfo,rooms where useracc.userid=usersinfo.accid and usersinfo.accid=rooms.Ruserid AND accid=" + cidnum + ";";
                            objdBAccess.readDatathroughAdapter(query1, dtusersSC);
                            string textHistorySummary = "";
                            if (dtusersSC.Rows.Count == 0)
                            {
                                DataTable dtusersSC1 = new DataTable();
                                string query2 = "select username,userid,password,status,fname,lname,age,phone,gender,HistorySummary,whoDeactivatedAccount,deactivatedReason,created_at from useracc, usersinfo where useracc.userid=usersinfo.accid AND accid=" + cidnum + ";";
                                objdBAccess.readDatathroughAdapter(query2, dtusersSC1);

                                dgvSC.DataSource = dtusersSC1;
                                textHistorySummary = dtusersSC1.Rows[0]["HistorySummary"].ToString();
                            }
                            else
                            {
                                dgvSC.DataSource = dtusersSC;
                                textHistorySummary = dtusersSC.Rows[0]["HistorySummary"].ToString();
                            }

                            if (textHistorySummary != "")
                            {
                                txtHistorySummary.Visible = true;
                                lblHistorySummary.Visible = true;
                                txtHistorySummary.Text = textHistorySummary;
                            }
                            else if (textHistorySummary == "")
                            {
                                txtHistorySummary.Visible = false;
                                lblHistorySummary.Visible = false;
                                // txtHistorySummary.Text = textHistorySummary;
                            }

                            txtHistorySummary.Text = textHistorySummary;
                            textHistorySummary = "";

                            dgvSC.ReadOnly = true;
                            dgvSC.AllowUserToAddRows = false;
                            dgvSC.AllowUserToDeleteRows = false;
                            objdBAccess.closeConn();
                            //////////////
                            txtSCsearchtextbox.ReadOnly = true;
                            rbSCuserid.Visible = false;
                            rbSCusername.Visible = false;
                            label24.Visible = false;

                            if (dgvSC.Columns["HistorySummary"] != null)
                            {
                                dgvSC.Columns.Remove("HistorySummary");
                            }

                            if (dtt.Rows.Count == 0)
                            {
                                MessageBox.Show("error in user-account table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("No record avaliable in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }


        }

        private void btnBacktoMMSC_Click(object sender, EventArgs e)
        {

            pnlAdminMenu.Visible = true;
            pnlSearchCust.Visible = false;
            pnlSCtoOP.Visible = false;

            txtHistorySummary.Visible = false;
            lblHistorySummary.Visible = false;

            txtSCsearchtextbox.Clear();

            txtSCsearchtextbox.Text = "";
            txtSCsearchtextbox.Visible = false;
            txtSCsearchtextbox.ReadOnly = true;
            txtSCsearchtextbox.BorderStyle = BorderStyle.None;

            txtSCsearchtextbox.Clear(); // Clear the textbox
            txtSCsearchtextbox.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                              // Set event handler to allow any input (no validation)
            txtSCsearchtextbox.KeyPress += (s, ev) => { };


            rbSCuserid.Checked = false;
            rbSCusername.Checked = false;
            txtSCsearchtextbox.ReadOnly = false;
            rbSCusername.Visible = true;
            rbSCuserid.Visible = true;
            label24.Visible = true;
        }
        private void btnSCnewSearch_Click(object sender, EventArgs e)
        {
            pnlSCtoOP.Visible = false;


            txtSCsearchtextbox.Clear();

            txtSCsearchtextbox.Text = "";
            txtSCsearchtextbox.Visible = false;
            txtSCsearchtextbox.ReadOnly = true;
            txtSCsearchtextbox.BorderStyle = BorderStyle.None;

            txtSCsearchtextbox.Clear(); // Clear the textbox
            txtSCsearchtextbox.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                              // Set event handler to allow any input (no validation)
            txtSCsearchtextbox.KeyPress += (s, ev) => { };

            txtHistorySummary.Visible = false;
            lblHistorySummary.Visible = false;

            rbSCuserid.Checked = false;
            rbSCusername.Checked = false;
            txtSCsearchtextbox.ReadOnly = false;
            rbSCusername.Visible = true;
            rbSCuserid.Visible = true;
            label24.Visible = true;
        }


        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- CHECK/OUT ----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>
        /// 
        private void btnCheckOUT_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = false;
            pnlCheckOut.Visible = true;

            txtCheckOutSCustomer.Text = "";
            txtCheckOutSCustomer.Visible = false;
            txtCheckOutSCustomer.ReadOnly = true;
            txtCheckOutSCustomer.BorderStyle = BorderStyle.None;

            txtCheckOutSCustomer.Clear(); // Clear the textbox
            txtCheckOutSCustomer.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                                // Set event handler to allow any input (no validation)
            txtCheckOutSCustomer.KeyPress += (s, ev) => { };

        }

        private void rbcCheckOutUID_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcCheckOutUID.Checked)
            {
                txtCheckOutSCustomer.Visible = true;
                txtCheckOutSCustomer.ReadOnly = false;
                txtCheckOutSCustomer.BorderStyle = BorderStyle.Fixed3D;
                txtCheckOutSCustomer.Clear(); // Clear the textbox



                txtCheckOutSCustomer.Clear(); // Clear the textbox
                                              //txtSearchAccAssignR.KeyPress -= AllowNonNumericInput; // Remove any existing event handler
                txtCheckOutSCustomer.KeyPress -= (s, ev) => { };
                txtCheckOutSCustomer.KeyPress += AllowNumericInput; // Set event handler to allow only numeric input
            }
        }

        private void rbcCheckOutUNAME_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcCheckOutUNAME.Checked)
            {
                txtCheckOutSCustomer.Visible = true;
                txtCheckOutSCustomer.ReadOnly = false;
                txtCheckOutSCustomer.BorderStyle = BorderStyle.Fixed3D;
                txtCheckOutSCustomer.Clear(); // Clear the textbox



                txtCheckOutSCustomer.Clear(); // Clear the textbox
                txtCheckOutSCustomer.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                                    // Set event handler to allow any input (no validation)
                txtCheckOutSCustomer.KeyPress += (s, ev) => { };
            }
        }
        private int totalCkPayOut;

        int cidnumOut = 0;
        string KeepDeactivated;
        private void btnCoutSearchCustomr_Click(object sender, EventArgs e)
        {
            string userAcc = txtCheckOutSCustomer.Text;
            string searchchoice = "";
            bool flag = false;
            if (rbcCheckOutUID.Checked)
            {
                searchchoice = "userid";
                flag = true;
            }
            else if (rbcCheckOutUNAME.Checked)
            {
                searchchoice = "username";
                flag = true;
            }
            else
            {
                MessageBox.Show("please choose search type first");
            }

            if (flag)
            {
                flag = true;

                if (userAcc == "")
                {
                    MessageBox.Show("Please enter your account info.");
                    flag = false;
                }
                if (flag)
                {

                    DataTable dt = new DataTable();
                    SqlCommand lOGINcmd = new SqlCommand();
                    lOGINcmd.CommandText = "select * from useracc where " + searchchoice + "= @userAcc and (status='active' or status='deactivated');";
                    lOGINcmd.Parameters.AddWithValue("@userAcc", userAcc);
                    objdBAccess.readDatathroughAdapterSql(lOGINcmd, dt);

                    if (dt.Rows.Count == 1)
                    {

                        if (flag)
                        {
                            cidnum = Convert.ToInt32(dt.Rows[0]["userid"]);
                            KeepDeactivated = dt.Rows[0]["status"].ToString();
                            DBAccess dBAccess = new DBAccess();
                            DataTable dtt = new DataTable();
                            SqlCommand llOGINcmd = new SqlCommand();
                            llOGINcmd.CommandText = "select * from usersinfo where accid= @cidnum ;";
                            llOGINcmd.Parameters.AddWithValue("@cidnum", cidnum);
                            dBAccess.readDatathroughAdapterSql(llOGINcmd, dtt);
                            totalCkPayOut = Convert.ToInt32(dtt.Rows[0]["totalAmountDue"]);

                            if (totalCkPayOut == 0)
                            {

                                DialogResult dialog = MessageBox.Show($"Do you want to check-out the customer with userid:{cidnum}?", "Account sucessfully Found(Check-In) ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dialog == DialogResult.Yes)
                                {
                                    DBAccess objdBAccess = new DBAccess();
                                    DataTable dtUsers = new DataTable();

                                    string cmd = "UPDATE TOP (1) rooms SET  isTaken = 'FALSE', isBooked = 'FALSE' WHERE Ruserid = @cidnum and isTaken = 'TRUE';";

                                    SqlCommand updatecmd = new SqlCommand(cmd);
                                    updatecmd.Parameters.AddWithValue("@cidnum", cidnum);

                                    int row = objdBAccess.executeQuery(updatecmd);
                                    if (row > 0)
                                    {
                                        DBAccess objdBAccess1 = new DBAccess();
                                        //AFTER TRIGGER IS CREATED AND LOGGED TO HISTORY SUMMARY , THEN WE REMOOVE ROOMS THE Ruserid
                                        string cmd11 = "UPDATE TOP (1) rooms SET  Ruserid=null WHERE Ruserid = @cidnum;";
                                        SqlCommand updatecmd11 = new SqlCommand(cmd11);
                                        updatecmd11.Parameters.AddWithValue("@cidnum", cidnum);
                                        objdBAccess.executeQuery(updatecmd11);
                                        ///////////end
                                        string cmd1 = "";
                                        if (KeepDeactivated == "deactivated")
                                        {
                                            cmd1 = "Update useracc set status='deactivated' where userid = @cidnum; ";
                                        }
                                        else
                                        {
                                            cmd1 = "Update useracc set status='exited' where userid = @cidnum; ";
                                        }

                                        SqlCommand updatecmd1 = new SqlCommand(cmd1);
                                        updatecmd1.Parameters.AddWithValue("@cidnum", cidnum);
                                        int row1 = objdBAccess1.executeQuery(updatecmd1);
                                        if (row1 > 0)
                                        {
                                            MessageBox.Show("Sucessfully check-out the customer", "success", MessageBoxButtons.OK);
                                            int TotalAmountDue = 0;
                                            string cmd2 = "Update usersinfo set totalAmountDue=@TotalAmountDue,numOfDaysToStay=0  where accid = @cidnum; ";
                                            SqlCommand updatecmd2 = new SqlCommand(cmd2);
                                            updatecmd2.Parameters.AddWithValue("@cidnum", cidnum);
                                            updatecmd2.Parameters.AddWithValue("@TotalAmountDue", TotalAmountDue);

                                            objdBAccess1.executeQuery(updatecmd2);


                                            txtCheckOutSCustomer.Clear();

                                            rbcCheckOutUNAME.Checked = false;
                                            rbcCheckOutUID.Checked = false;
                                            txtCheckOutSCustomer.ReadOnly = false;
                                            rbcCheckOutUNAME.Visible = true;
                                            rbcCheckOutUID.Visible = true;
                                            label26.Visible = true;
                                            txtCheckOutSCustomer.Text = "";
                                            txtCheckOutSCustomer.Visible = false;
                                            txtCheckOutSCustomer.ReadOnly = true;
                                            txtCheckOutSCustomer.BorderStyle = BorderStyle.None;

                                            txtCheckOutSCustomer.Clear(); // Clear the textbox
                                            txtCheckOutSCustomer.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                                                                // Set event handler to allow any input (no validation)
                                            txtCheckOutSCustomer.KeyPress += (s, ev) => { };


                                        }
                                        else
                                        {
                                            MessageBox.Show("error in user-account table");
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("error in rooms table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    }
                                }
                                else
                                {
                                    txtCheckOutSCustomer.Clear(); // Clear the textbox
                                    txtCheckOutSCustomer.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                                                        // Set event handler to allow any input (no validation)
                                    txtCheckOutSCustomer.KeyPress += (s, ev) => { };



                                    txtCheckOutSCustomer.Clear();

                                    rbcCheckOutUNAME.Checked = false;
                                    rbcCheckOutUID.Checked = false;
                                    txtCheckOutSCustomer.ReadOnly = false;
                                    rbcCheckOutUNAME.Visible = true;
                                    rbcCheckOutUID.Visible = true;
                                    label26.Visible = true;
                                }

                            }
                            else
                            {
                                txtCheckOutSCustomer.ReadOnly = true;
                                rbcCheckOutUNAME.Visible = false;
                                rbcCheckOutUID.Visible = false;
                                label26.Visible = false;
                            }

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("error in user-account table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Not inside the guest house or account deactivated!! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }

            }


        }



        private void backToMMfCheckOut_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = true;
            pnlCheckOut.Visible = false;
            txtCheckOutSCustomer.Clear(); // Clear the textbox
            txtCheckOutSCustomer.KeyPress -= AllowNumericInput; // Remove any existing event handler
                                                                // Set event handler to allow any input (no validation)
            txtCheckOutSCustomer.KeyPress += (s, ev) => { };




            txtCheckOutSCustomer.Clear();

            rbcCheckOutUNAME.Checked = false;
            rbcCheckOutUID.Checked = false;
            txtCheckOutSCustomer.ReadOnly = false;
            rbcCheckOutUNAME.Visible = true;
            rbcCheckOutUID.Visible = true;
            label26.Visible = true;

        }

        /// 
        /// //////////////###########################/////////////////
        /// //////////////#####----- View/All/Room ----###########/////////////////
        /// //////////////###########################/////////////////
        ///
        private void dvgViewAllRLoad()
        {
            DBAccess objdBAccess = new DBAccess();
            DataTable dtusers = new DataTable();
            
            string query = "select roomNumber,roomType,pricePerNight,Ruserid,isBooked,isTaken from rooms order by Ruserid DESC;";
            objdBAccess.readDatathroughAdapter(query, dtusers);

            dgvViewAllR.DataSource = dtusers;
            dgvViewAllR.ReadOnly = true;
            dgvViewAllR.AllowUserToAddRows = false;
            dgvViewAllR.AllowUserToDeleteRows = false;

            /*  // Add a Button Column
               DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
               buttonColumn.HeaderText = "Customer Info";
               buttonColumn.Name = "btnRuserid";
               buttonColumn.Text = "View Details";
               buttonColumn.UseColumnTextForButtonValue = true;
               dgvViewAllR.Columns.Add(buttonColumn);*/

            bool columnExists = false;
            foreach (DataGridViewColumn column in dgvViewAllR.Columns)
            {
                if (column.HeaderText == "Customer Info")
                {
                    columnExists = true;
                    break;
                }
            }

            // Add a Button Column if it doesn't already exist
            if (!columnExists)
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.HeaderText = "Customer Info";
                buttonColumn.Name = "btnRuserid";
                buttonColumn.Text = "View Details";
                buttonColumn.UseColumnTextForButtonValue = true;

                // Insert the column at the beginning (index 0)
                dgvViewAllR.Columns.Insert(4, buttonColumn);
            }

            

            objdBAccess.closeConn();
        }

        private void dgvViewAllR_CellContentClick1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvViewAllR.Columns["btnRuserid"].Index)
            {
                // Check if the Ruserid cell value is not DBNull
                if (dgvViewAllR.Rows[e.RowIndex].Cells["Ruserid"].Value != DBNull.Value)
                {
                    int username = Convert.ToInt32(dgvViewAllR.Rows[e.RowIndex].Cells["Ruserid"].Value);

                    DBAccess objdBAccess = new DBAccess();
                    DataTable dtusersSC1 = new DataTable();
                    string query2 = "select fname,lname,status,phone,totalAmountDue,numOfDaysToStay,gender from useracc, usersinfo,rooms where useracc.userid=usersinfo.accid and usersinfo.accid=rooms.Ruserid and userid=" + username + ";";
                    objdBAccess.readDatathroughAdapter(query2, dtusersSC1);

                    if (dtusersSC1.Rows.Count == 1)
                    {
                        string msg = "";
                        msg += "FirstName: " + dtusersSC1.Rows[0]["fname"].ToString();
                        msg += "\nLastName: " + dtusersSC1.Rows[0]["lname"].ToString();
                        msg += "\nStatus: " + dtusersSC1.Rows[0]["status"].ToString();
                        msg += "\nPhone: " + dtusersSC1.Rows[0]["phone"].ToString();
                        msg += "\nGender: " + dtusersSC1.Rows[0]["gender"].ToString();
                        msg += "\nNumber of Stay Days: " + dtusersSC1.Rows[0]["numOfDaysToStay"].ToString();
                        msg += "\nTotal Amount Due: " + dtusersSC1.Rows[0]["totalAmountDue"].ToString();


                        MessageBox.Show($"{msg}");
                    }
                    else
                    {
                        MessageBox.Show("Error accessing database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnViewAllRoomStatus_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = false;
            pnlViewAllR.Visible = true;
            dvgViewAllRLoad();
        }


        private void btnBacktoMMviewAllR_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = true;
            pnlViewAllR.Visible = false;
        }

        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- View/All/Customers ----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>
        private void btnViewAllCustomers_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = false;
            pnlViewAllCustomers.Visible = true;

            DBAccess objdBAccess = new DBAccess();
            DataTable dtusers1 = new DataTable();
            DataTable dtusers2 = new DataTable();
            string query1 = "select * from useracc, usersinfo,rooms where useracc.userid=usersinfo.accid and usersinfo.accid=rooms.Ruserid;";
            objdBAccess.readDatathroughAdapter(query1, dtusers1);
            dgvViewActiveBCustomer.DataSource = dtusers1;
            dgvViewActiveBCustomer.ReadOnly = true;
            dgvViewActiveBCustomer.AllowUserToAddRows = false;
            dgvViewActiveBCustomer.AllowUserToDeleteRows = false;
            string query2 = "select username,userid,password,status,fname,lname,age,phone,gender,whoDeactivatedAccount,deactivatedReason,created_at from useracc, usersinfo where useracc.userid=usersinfo.accid ;";
            objdBAccess.readDatathroughAdapter(query2, dtusers2);

            dgvViewOtherCustomer.DataSource = dtusers2;
            dgvViewOtherCustomer.ReadOnly = true;
            dgvViewOtherCustomer.AllowUserToAddRows = false;
            dgvViewOtherCustomer.AllowUserToDeleteRows = false;

            objdBAccess.closeConn();

        }

        private void btnBacktoMMviewAllCustomer_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = true;
            pnlViewAllCustomers.Visible = false;
        }

        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- Guest/Summary/Report ----###########/////////////////
        /// //////////////##############History of customers or already booked before()#############/////////////////
        /// </summary>
        private void btnGuestSReoport_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = false;
            pnlGuestSummary.Visible = true;

            DBAccess objdBAccess = new DBAccess();
            DataTable dtusers1 = new DataTable();

            string query1 = "select accid,fname,status,usersinfo.HistorySummary   from useracc, usersinfo where useracc.userid=usersinfo.accid and HistorySummary is not Null ;";
            objdBAccess.readDatathroughAdapter(query1, dtusers1);
            dgvGuestSummary.AutoGenerateColumns = false;
            dgvGuestSummary.DataSource = dtusers1;
            dgvGuestSummary.ReadOnly = true;
            dgvGuestSummary.AllowUserToAddRows = false;
            dgvGuestSummary.AllowUserToDeleteRows = false;

            objdBAccess.closeConn();

        }

        private void btnBackToMMGuestSummary_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = true;
            pnlGuestSummary.Visible = false;
        }
        /// <summary>
        /// //////////////###########################/////////////////
        /// //////////////#####----- Deactivate/Activate//Customer ----###########/////////////////
        /// //////////////###########################/////////////////
        /// </summary>
        private void btnDRactivateCA_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = false;
            pnlActDeaCus.Visible = true;


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

            string query1 = "select userid,fname,status from useracc, usersinfo where useracc.userid=usersinfo.accid ;";
            objdBAccess.readDatathroughAdapter(query1, dtusers1);
            dgvActivateDeactivate.AutoGenerateColumns = false;
            dgvActivateDeactivate.DataSource = dtusers1;
        }

        private void btnBacktoMMActivateDeactivate_Click(object sender, EventArgs e)
        {
            pnlAdminMenu.Visible = true;
            pnlActDeaCus.Visible = false;
        }

        private void dgvActivateDeactivate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

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
                            string who = "admin";
                            string reason = Microsoft.VisualBasic.Interaction.InputBox("Reason for Deactivation:", "Input", "");
                            string AdminReason = "";
                            if (reason != "")
                            {
                                AdminReason = " deactivatedReason = @reason + ';  ' + ISNULL(deactivatedReason, '')";
                            }
                            else
                            {

                                AdminReason = "deactivatedReason = @reason + ISNULL(deactivatedReason, '')";
                            }



                            string cmd21 = "Update usersinfo set whoDeactivatedAccount=@who," + AdminReason + "  where accid = @cidnum; ";
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
                            if (removeBookingifOnHold == "active")
                            {
                                objdBAccess = new DBAccess();
                                DataTable dtUsers = new DataTable();

                                string cmd = "UPDATE TOP (1) rooms SET  isTaken = 'FALSE', isBooked = 'FALSE' WHERE Ruserid = @cidnum and isTaken = 'TRUE';";

                                SqlCommand updatecmd = new SqlCommand(cmd);
                                updatecmd.Parameters.AddWithValue("@cidnum", username);

                                int row = objdBAccess.executeQuery(updatecmd);
                                if (row > 0)
                                {
                                    objdBAccess1 = new DBAccess();
                                    //AFTER TRIGGER IS CREATED AND LOGGED TO HISTORY SUMMARY , THEN WE REMOOVE ROOMS THE Ruserid
                                    string cmd11 = "UPDATE TOP (1) rooms SET  Ruserid=null WHERE Ruserid = @cidnum;";
                                    SqlCommand updatecmd11 = new SqlCommand(cmd11);
                                    updatecmd11.Parameters.AddWithValue("@cidnum", username);
                                    objdBAccess.executeQuery(updatecmd11);
                                    ///////////end

                                    int TotalAmountDue = 0;
                                    string cmd2 = "Update usersinfo set totalAmountDue=@TotalAmountDue,numOfDaysToStay=0  where accid = @cidnum; ";
                                    SqlCommand updatecmd2 = new SqlCommand(cmd2);
                                    updatecmd2.Parameters.AddWithValue("@cidnum", username);
                                    updatecmd2.Parameters.AddWithValue("@TotalAmountDue", TotalAmountDue);

                                    objdBAccess1.executeQuery(updatecmd2);
                                }
                                else
                                {
                                    MessageBox.Show("error in rooms table", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                }

                                msg = ".Check-out has also been processed for customer.";

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
                    string query2 = "select * from useracc where userid=" + username + " and status='deactivated';";
                    objdBAccess.readDatathroughAdapter(query2, dtusersSC1);

                    if (dtusersSC1.Rows.Count == 1)
                    {

                        if (MessageBox.Show("Are You Sure You Want To Activate This Account?", "Change Account Status",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DBAccess objdBAccess1 = new DBAccess();
                            string cmd2 = "Update usersinfo set whoDeactivatedAccount='' where accid = @cidnum; ";
                            SqlCommand updatecmd2 = new SqlCommand(cmd2);
                            updatecmd2.Parameters.AddWithValue("@cidnum", username);
                            objdBAccess1.executeQuery(updatecmd2);

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
        //mistakely added
        private void dgvViewAvailableR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}



