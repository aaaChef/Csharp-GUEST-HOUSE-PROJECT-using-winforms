namespace GUIOpenGuestHouse
{
    partial class CustomerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlCustomerMenu = new Panel();
            label1 = new Label();
            btnGuestSReoport = new Button();
            btnADroomExtend = new Button();
            btnViewAvailableRoom = new Button();
            btnMakeReservation = new Button();
            btnUpdateInfo = new Button();
            linklblBacktoLogin = new LinkLabel();
            pnlUpdateInfo = new Panel();
            btnBackToMRA = new Button();
            dgvBookingInfo = new DataGridView();
            btnCancelRoomUpdate = new Button();
            label12 = new Label();
            txtUuserPassword = new TextBox();
            label11 = new Label();
            txtUusername = new TextBox();
            label9 = new Label();
            label10 = new Label();
            txtUuserStatus = new TextBox();
            label6 = new Label();
            txtUuserid = new TextBox();
            label5 = new Label();
            lblnotifySignUP = new Label();
            label3 = new Label();
            txtMPhone = new TextBox();
            label13 = new Label();
            txtMLastName = new TextBox();
            txtMAge = new TextBox();
            combMGender = new ComboBox();
            dtpicker = new DateTimePicker();
            txtMFirstName = new TextBox();
            btnMSave = new Button();
            label14 = new Label();
            label15 = new Label();
            label16 = new Label();
            label17 = new Label();
            pnlMakeReservation = new Panel();
            btnBacktoMMCAmenu = new Button();
            nudNumberOfDays = new NumericUpDown();
            label23 = new Label();
            btnSaveAssignR = new Button();
            groupBox2 = new GroupBox();
            rbTypePAssignR = new RadioButton();
            rbTypeLAssignR = new RadioButton();
            rbTypeSAssignR = new RadioButton();
            label4 = new Label();
            pnlViewAvailableRooms = new Panel();
            btnBacktoMMviewAvailableR = new Button();
            dgvViewAvailableR = new DataGridView();
            pnlChangeAccountStatusAD = new Panel();
            btnBacktoMMActivateDeactivate = new Button();
            dgvActivateDeactivate = new DataGridView();
            ADFirstName = new DataGridViewTextBoxColumn();
            ADUserId = new DataGridViewTextBoxColumn();
            ADStatus = new DataGridViewTextBoxColumn();
            pnlViewOwnSummaryReport = new Panel();
            btnBackToMMGuestSummary = new Button();
            txtVOSstatus = new TextBox();
            txtVOSfname = new TextBox();
            txtVOSid = new TextBox();
            label8 = new Label();
            label7 = new Label();
            label2 = new Label();
            lblHistorySummary = new Label();
            txtHistorySummary = new TextBox();
            pnlCustomerMenu.SuspendLayout();
            pnlUpdateInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookingInfo).BeginInit();
            pnlMakeReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfDays).BeginInit();
            groupBox2.SuspendLayout();
            pnlViewAvailableRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvViewAvailableR).BeginInit();
            pnlChangeAccountStatusAD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActivateDeactivate).BeginInit();
            pnlViewOwnSummaryReport.SuspendLayout();
            SuspendLayout();
            // 
            // pnlCustomerMenu
            // 
            pnlCustomerMenu.Controls.Add(label1);
            pnlCustomerMenu.Controls.Add(btnGuestSReoport);
            pnlCustomerMenu.Controls.Add(btnADroomExtend);
            pnlCustomerMenu.Controls.Add(btnViewAvailableRoom);
            pnlCustomerMenu.Controls.Add(btnMakeReservation);
            pnlCustomerMenu.Controls.Add(btnUpdateInfo);
            pnlCustomerMenu.Location = new Point(12, 39);
            pnlCustomerMenu.Name = "pnlCustomerMenu";
            pnlCustomerMenu.Size = new Size(521, 283);
            pnlCustomerMenu.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Aqua;
            label1.Location = new Point(22, 78);
            label1.Name = "label1";
            label1.Size = new Size(298, 23);
            label1.TabIndex = 35;
            label1.Text = "Welcome to Customer Menu:";
            // 
            // btnGuestSReoport
            // 
            btnGuestSReoport.BackColor = Color.Gold;
            btnGuestSReoport.ForeColor = Color.Black;
            btnGuestSReoport.Location = new Point(130, 185);
            btnGuestSReoport.Name = "btnGuestSReoport";
            btnGuestSReoport.Size = new Size(285, 23);
            btnGuestSReoport.TabIndex = 34;
            btnGuestSReoport.Text = "View Own Summary Report";
            btnGuestSReoport.UseVisualStyleBackColor = false;
            btnGuestSReoport.Click += btnGuestSReoport_Click;
            // 
            // btnADroomExtend
            // 
            btnADroomExtend.BackColor = Color.Gold;
            btnADroomExtend.ForeColor = Color.Black;
            btnADroomExtend.Location = new Point(130, 166);
            btnADroomExtend.Name = "btnADroomExtend";
            btnADroomExtend.Size = new Size(285, 23);
            btnADroomExtend.TabIndex = 31;
            btnADroomExtend.Text = "Change Account Status (Activate/Deactivate)";
            btnADroomExtend.UseVisualStyleBackColor = false;
            btnADroomExtend.Click += btnDRactivateCA_Click;
            // 
            // btnViewAvailableRoom
            // 
            btnViewAvailableRoom.BackColor = Color.Gold;
            btnViewAvailableRoom.ForeColor = Color.Black;
            btnViewAvailableRoom.Location = new Point(130, 146);
            btnViewAvailableRoom.Name = "btnViewAvailableRoom";
            btnViewAvailableRoom.Size = new Size(285, 23);
            btnViewAvailableRoom.TabIndex = 28;
            btnViewAvailableRoom.Text = "View Available Rooms";
            btnViewAvailableRoom.UseVisualStyleBackColor = false;
            btnViewAvailableRoom.Click += btnViewAvailableRoom_Click;
            // 
            // btnMakeReservation
            // 
            btnMakeReservation.BackColor = Color.Gold;
            btnMakeReservation.ForeColor = Color.Black;
            btnMakeReservation.Location = new Point(130, 126);
            btnMakeReservation.Name = "btnMakeReservation";
            btnMakeReservation.Size = new Size(285, 23);
            btnMakeReservation.TabIndex = 26;
            btnMakeReservation.Text = "Make Reservation";
            btnMakeReservation.UseVisualStyleBackColor = false;
            btnMakeReservation.Click += btnMakeReservation_Click;
            // 
            // btnUpdateInfo
            // 
            btnUpdateInfo.BackColor = Color.Gold;
            btnUpdateInfo.ForeColor = Color.Black;
            btnUpdateInfo.Location = new Point(130, 107);
            btnUpdateInfo.Name = "btnUpdateInfo";
            btnUpdateInfo.Size = new Size(285, 23);
            btnUpdateInfo.TabIndex = 25;
            btnUpdateInfo.Text = "Update Info";
            btnUpdateInfo.UseVisualStyleBackColor = false;
            btnUpdateInfo.Click += btnUpdateInfo_Click;
            // 
            // linklblBacktoLogin
            // 
            linklblBacktoLogin.AutoSize = true;
            linklblBacktoLogin.BackColor = Color.MistyRose;
            linklblBacktoLogin.LinkColor = Color.FromArgb(192, 0, 0);
            linklblBacktoLogin.Location = new Point(435, 9);
            linklblBacktoLogin.Name = "linklblBacktoLogin";
            linklblBacktoLogin.Size = new Size(45, 15);
            linklblBacktoLogin.TabIndex = 12;
            linklblBacktoLogin.TabStop = true;
            linklblBacktoLogin.Text = "Logout";
            linklblBacktoLogin.LinkClicked += linklblBacktoLogin_LinkClicked;
            // 
            // pnlUpdateInfo
            // 
            pnlUpdateInfo.Controls.Add(btnBackToMRA);
            pnlUpdateInfo.Controls.Add(dgvBookingInfo);
            pnlUpdateInfo.Controls.Add(btnCancelRoomUpdate);
            pnlUpdateInfo.Controls.Add(label12);
            pnlUpdateInfo.Controls.Add(txtUuserPassword);
            pnlUpdateInfo.Controls.Add(label11);
            pnlUpdateInfo.Controls.Add(txtUusername);
            pnlUpdateInfo.Controls.Add(label9);
            pnlUpdateInfo.Controls.Add(label10);
            pnlUpdateInfo.Controls.Add(txtUuserStatus);
            pnlUpdateInfo.Controls.Add(label6);
            pnlUpdateInfo.Controls.Add(txtUuserid);
            pnlUpdateInfo.Controls.Add(label5);
            pnlUpdateInfo.Controls.Add(lblnotifySignUP);
            pnlUpdateInfo.Controls.Add(label3);
            pnlUpdateInfo.Controls.Add(txtMPhone);
            pnlUpdateInfo.Controls.Add(label13);
            pnlUpdateInfo.Controls.Add(txtMLastName);
            pnlUpdateInfo.Controls.Add(txtMAge);
            pnlUpdateInfo.Controls.Add(combMGender);
            pnlUpdateInfo.Controls.Add(dtpicker);
            pnlUpdateInfo.Controls.Add(txtMFirstName);
            pnlUpdateInfo.Controls.Add(btnMSave);
            pnlUpdateInfo.Controls.Add(label14);
            pnlUpdateInfo.Controls.Add(label15);
            pnlUpdateInfo.Controls.Add(label16);
            pnlUpdateInfo.Controls.Add(label17);
            pnlUpdateInfo.ForeColor = Color.Black;
            pnlUpdateInfo.Location = new Point(6, 34);
            pnlUpdateInfo.Name = "pnlUpdateInfo";
            pnlUpdateInfo.Size = new Size(593, 291);
            pnlUpdateInfo.TabIndex = 14;
            // 
            // btnBackToMRA
            // 
            btnBackToMRA.FlatStyle = FlatStyle.Popup;
            btnBackToMRA.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackToMRA.ForeColor = Color.Magenta;
            btnBackToMRA.ImageAlign = ContentAlignment.TopCenter;
            btnBackToMRA.Location = new Point(9, 3);
            btnBackToMRA.Name = "btnBackToMRA";
            btnBackToMRA.Size = new Size(51, 39);
            btnBackToMRA.TabIndex = 73;
            btnBackToMRA.Text = "🔙";
            btnBackToMRA.TextAlign = ContentAlignment.TopCenter;
            btnBackToMRA.UseVisualStyleBackColor = true;
            btnBackToMRA.Click += btnBackToMRA_Click;
            // 
            // dgvBookingInfo
            // 
            dgvBookingInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookingInfo.Location = new Point(373, 105);
            dgvBookingInfo.Name = "dgvBookingInfo";
            dgvBookingInfo.Size = new Size(207, 73);
            dgvBookingInfo.TabIndex = 72;
            // 
            // btnCancelRoomUpdate
            // 
            btnCancelRoomUpdate.BackColor = Color.DeepPink;
            btnCancelRoomUpdate.ForeColor = SystemColors.InfoText;
            btnCancelRoomUpdate.Location = new Point(445, 180);
            btnCancelRoomUpdate.Name = "btnCancelRoomUpdate";
            btnCancelRoomUpdate.Size = new Size(76, 38);
            btnCancelRoomUpdate.TabIndex = 71;
            btnCancelRoomUpdate.Text = "Cancel Reservation";
            btnCancelRoomUpdate.UseVisualStyleBackColor = false;
            btnCancelRoomUpdate.Click += btnCancelRoomUpdate_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.ForeColor = SystemColors.Info;
            label12.Location = new Point(429, 87);
            label12.Name = "label12";
            label12.Size = new Size(75, 15);
            label12.TabIndex = 69;
            label12.Text = "Booking info";
            // 
            // txtUuserPassword
            // 
            txtUuserPassword.Location = new Point(102, 166);
            txtUuserPassword.Name = "txtUuserPassword";
            txtUuserPassword.Size = new Size(266, 23);
            txtUuserPassword.TabIndex = 68;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.ForeColor = SystemColors.Info;
            label11.Location = new Point(32, 172);
            label11.Name = "label11";
            label11.Size = new Size(60, 15);
            label11.TabIndex = 67;
            label11.Text = "Password:";
            // 
            // txtUusername
            // 
            txtUusername.Enabled = false;
            txtUusername.Location = new Point(311, 42);
            txtUusername.Name = "txtUusername";
            txtUusername.Size = new Size(232, 23);
            txtUusername.TabIndex = 66;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = SystemColors.Info;
            label9.Location = new Point(250, 49);
            label9.Name = "label9";
            label9.Size = new Size(62, 15);
            label9.TabIndex = 65;
            label9.Text = "username:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.Red;
            label10.Location = new Point(254, 25);
            label10.Name = "label10";
            label10.Size = new Size(0, 15);
            label10.TabIndex = 64;
            // 
            // txtUuserStatus
            // 
            txtUuserStatus.Enabled = false;
            txtUuserStatus.Location = new Point(136, 43);
            txtUuserStatus.Name = "txtUuserStatus";
            txtUuserStatus.Size = new Size(108, 23);
            txtUuserStatus.TabIndex = 63;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.Info;
            label6.Location = new Point(88, 50);
            label6.Name = "label6";
            label6.Size = new Size(42, 15);
            label6.TabIndex = 62;
            label6.Text = "Status:";
            // 
            // txtUuserid
            // 
            txtUuserid.Enabled = false;
            txtUuserid.Location = new Point(28, 44);
            txtUuserid.Name = "txtUuserid";
            txtUuserid.Size = new Size(39, 23);
            txtUuserid.TabIndex = 61;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Info;
            label5.Location = new Point(8, 51);
            label5.Name = "label5";
            label5.Size = new Size(21, 15);
            label5.TabIndex = 60;
            label5.Text = "ID:";
            // 
            // lblnotifySignUP
            // 
            lblnotifySignUP.AutoSize = true;
            lblnotifySignUP.ForeColor = Color.Red;
            lblnotifySignUP.Location = new Point(161, 26);
            lblnotifySignUP.Name = "lblnotifySignUP";
            lblnotifySignUP.Size = new Size(0, 15);
            lblnotifySignUP.TabIndex = 59;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(136, 5);
            label3.Name = "label3";
            label3.Size = new Size(245, 23);
            label3.TabIndex = 58;
            label3.Text = "Update your account !";
            // 
            // txtMPhone
            // 
            txtMPhone.Location = new Point(101, 133);
            txtMPhone.Name = "txtMPhone";
            txtMPhone.Size = new Size(266, 23);
            txtMPhone.TabIndex = 57;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.ForeColor = SystemColors.Info;
            label13.Location = new Point(8, 139);
            label13.Name = "label13";
            label13.Size = new Size(91, 15);
            label13.TabIndex = 56;
            label13.Text = "Phone Number:";
            // 
            // txtMLastName
            // 
            txtMLastName.Location = new Point(101, 103);
            txtMLastName.Name = "txtMLastName";
            txtMLastName.Size = new Size(266, 23);
            txtMLastName.TabIndex = 55;
            // 
            // txtMAge
            // 
            txtMAge.Location = new Point(320, 195);
            txtMAge.Name = "txtMAge";
            txtMAge.ReadOnly = true;
            txtMAge.Size = new Size(47, 23);
            txtMAge.TabIndex = 54;
            // 
            // combMGender
            // 
            combMGender.DropDownStyle = ComboBoxStyle.DropDownList;
            combMGender.FormattingEnabled = true;
            combMGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            combMGender.Location = new Point(102, 220);
            combMGender.Name = "combMGender";
            combMGender.Size = new Size(121, 23);
            combMGender.TabIndex = 53;
            // 
            // dtpicker
            // 
            dtpicker.Location = new Point(101, 195);
            dtpicker.Name = "dtpicker";
            dtpicker.Size = new Size(211, 23);
            dtpicker.TabIndex = 52;
            dtpicker.ValueChanged += dtpicker_ValueChanged;
            // 
            // txtMFirstName
            // 
            txtMFirstName.Location = new Point(101, 74);
            txtMFirstName.Name = "txtMFirstName";
            txtMFirstName.Size = new Size(266, 23);
            txtMFirstName.TabIndex = 51;
            // 
            // btnMSave
            // 
            btnMSave.BackColor = Color.Lime;
            btnMSave.ForeColor = SystemColors.InfoText;
            btnMSave.Location = new Point(148, 254);
            btnMSave.Name = "btnMSave";
            btnMSave.Size = new Size(75, 23);
            btnMSave.TabIndex = 50;
            btnMSave.Text = "Update";
            btnMSave.UseVisualStyleBackColor = false;
            btnMSave.Click += btnMSave_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = SystemColors.Info;
            label14.Location = new Point(45, 227);
            label14.Name = "label14";
            label14.Size = new Size(48, 15);
            label14.TabIndex = 49;
            label14.Text = "Gender:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = SystemColors.Info;
            label15.Location = new Point(44, 204);
            label15.Name = "label15";
            label15.Size = new Size(31, 15);
            label15.TabIndex = 48;
            label15.Text = "Age:";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.ForeColor = SystemColors.Info;
            label16.Location = new Point(9, 111);
            label16.Name = "label16";
            label16.Size = new Size(66, 15);
            label16.TabIndex = 47;
            label16.Text = "Last Name:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.ForeColor = SystemColors.Info;
            label17.Location = new Point(12, 82);
            label17.Name = "label17";
            label17.Size = new Size(67, 15);
            label17.TabIndex = 46;
            label17.Text = "First Name:";
            // 
            // pnlMakeReservation
            // 
            pnlMakeReservation.Controls.Add(btnBacktoMMCAmenu);
            pnlMakeReservation.Controls.Add(nudNumberOfDays);
            pnlMakeReservation.Controls.Add(label23);
            pnlMakeReservation.Controls.Add(btnSaveAssignR);
            pnlMakeReservation.Controls.Add(groupBox2);
            pnlMakeReservation.Controls.Add(label4);
            pnlMakeReservation.Location = new Point(6, 33);
            pnlMakeReservation.Name = "pnlMakeReservation";
            pnlMakeReservation.Size = new Size(537, 292);
            pnlMakeReservation.TabIndex = 15;
            // 
            // btnBacktoMMCAmenu
            // 
            btnBacktoMMCAmenu.FlatStyle = FlatStyle.Popup;
            btnBacktoMMCAmenu.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBacktoMMCAmenu.ForeColor = Color.Magenta;
            btnBacktoMMCAmenu.ImageAlign = ContentAlignment.TopCenter;
            btnBacktoMMCAmenu.Location = new Point(8, 4);
            btnBacktoMMCAmenu.Name = "btnBacktoMMCAmenu";
            btnBacktoMMCAmenu.Size = new Size(51, 39);
            btnBacktoMMCAmenu.TabIndex = 74;
            btnBacktoMMCAmenu.Text = "🔙";
            btnBacktoMMCAmenu.TextAlign = ContentAlignment.TopCenter;
            btnBacktoMMCAmenu.UseVisualStyleBackColor = true;
            btnBacktoMMCAmenu.Click += btnBacktoMMCAmenu_Click;
            // 
            // nudNumberOfDays
            // 
            nudNumberOfDays.Location = new Point(282, 79);
            nudNumberOfDays.Maximum = new decimal(new int[] { 365, 0, 0, 0 });
            nudNumberOfDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudNumberOfDays.Name = "nudNumberOfDays";
            nudNumberOfDays.Size = new Size(89, 23);
            nudNumberOfDays.TabIndex = 41;
            nudNumberOfDays.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(147, 83);
            label23.Name = "label23";
            label23.Size = new Size(133, 15);
            label23.TabIndex = 40;
            label23.Text = "Number of days to stay:";
            // 
            // btnSaveAssignR
            // 
            btnSaveAssignR.BackColor = Color.Lime;
            btnSaveAssignR.ForeColor = SystemColors.InfoText;
            btnSaveAssignR.Location = new Point(253, 211);
            btnSaveAssignR.Name = "btnSaveAssignR";
            btnSaveAssignR.Size = new Size(113, 23);
            btnSaveAssignR.TabIndex = 39;
            btnSaveAssignR.Text = "Book Room";
            btnSaveAssignR.UseVisualStyleBackColor = false;
            btnSaveAssignR.Click += btnSaveAssignR_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbTypePAssignR);
            groupBox2.Controls.Add(rbTypeLAssignR);
            groupBox2.Controls.Add(rbTypeSAssignR);
            groupBox2.ForeColor = SystemColors.HighlightText;
            groupBox2.Location = new Point(141, 111);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(317, 101);
            groupBox2.TabIndex = 37;
            groupBox2.TabStop = false;
            groupBox2.Text = "Choose Room Type:";
            // 
            // rbTypePAssignR
            // 
            rbTypePAssignR.AutoSize = true;
            rbTypePAssignR.ForeColor = SystemColors.Info;
            rbTypePAssignR.Location = new Point(42, 77);
            rbTypePAssignR.Name = "rbTypePAssignR";
            rbTypePAssignR.Size = new Size(121, 19);
            rbTypePAssignR.TabIndex = 2;
            rbTypePAssignR.TabStop = true;
            rbTypePAssignR.Text = "Presidential (299$)";
            rbTypePAssignR.UseVisualStyleBackColor = true;
            // 
            // rbTypeLAssignR
            // 
            rbTypeLAssignR.AutoSize = true;
            rbTypeLAssignR.ForeColor = SystemColors.Info;
            rbTypeLAssignR.Location = new Point(42, 54);
            rbTypeLAssignR.Name = "rbTypeLAssignR";
            rbTypeLAssignR.Size = new Size(89, 19);
            rbTypeLAssignR.TabIndex = 1;
            rbTypeLAssignR.TabStop = true;
            rbTypeLAssignR.Text = "Lexury (49$)";
            rbTypeLAssignR.UseVisualStyleBackColor = true;
            // 
            // rbTypeSAssignR
            // 
            rbTypeSAssignR.AutoSize = true;
            rbTypeSAssignR.ForeColor = SystemColors.Info;
            rbTypeSAssignR.Location = new Point(42, 30);
            rbTypeSAssignR.Name = "rbTypeSAssignR";
            rbTypeSAssignR.Size = new Size(101, 19);
            rbTypeSAssignR.TabIndex = 0;
            rbTypeSAssignR.TabStop = true;
            rbTypeSAssignR.Text = "Standard (19$)";
            rbTypeSAssignR.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(202, 48);
            label4.Name = "label4";
            label4.Size = new Size(200, 23);
            label4.TabIndex = 35;
            label4.Text = "Make Reservation:";
            // 
            // pnlViewAvailableRooms
            // 
            pnlViewAvailableRooms.Controls.Add(btnBacktoMMviewAvailableR);
            pnlViewAvailableRooms.Controls.Add(dgvViewAvailableR);
            pnlViewAvailableRooms.ForeColor = Color.Black;
            pnlViewAvailableRooms.Location = new Point(17, 29);
            pnlViewAvailableRooms.Name = "pnlViewAvailableRooms";
            pnlViewAvailableRooms.Size = new Size(513, 296);
            pnlViewAvailableRooms.TabIndex = 16;
            // 
            // btnBacktoMMviewAvailableR
            // 
            btnBacktoMMviewAvailableR.FlatStyle = FlatStyle.Popup;
            btnBacktoMMviewAvailableR.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBacktoMMviewAvailableR.ForeColor = Color.Magenta;
            btnBacktoMMviewAvailableR.ImageAlign = ContentAlignment.TopCenter;
            btnBacktoMMviewAvailableR.Location = new Point(3, 7);
            btnBacktoMMviewAvailableR.Name = "btnBacktoMMviewAvailableR";
            btnBacktoMMviewAvailableR.Size = new Size(51, 39);
            btnBacktoMMviewAvailableR.TabIndex = 74;
            btnBacktoMMviewAvailableR.Text = "🔙";
            btnBacktoMMviewAvailableR.TextAlign = ContentAlignment.TopCenter;
            btnBacktoMMviewAvailableR.UseVisualStyleBackColor = true;
            btnBacktoMMviewAvailableR.Click += btnBacktoMMviewAvailableR_Click;
            // 
            // dgvViewAvailableR
            // 
            dgvViewAvailableR.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvViewAvailableR.Location = new Point(93, 23);
            dgvViewAvailableR.Name = "dgvViewAvailableR";
            dgvViewAvailableR.Size = new Size(404, 253);
            dgvViewAvailableR.TabIndex = 16;
            // 
            // pnlChangeAccountStatusAD
            // 
            pnlChangeAccountStatusAD.Controls.Add(btnBacktoMMActivateDeactivate);
            pnlChangeAccountStatusAD.Controls.Add(dgvActivateDeactivate);
            pnlChangeAccountStatusAD.ForeColor = Color.Black;
            pnlChangeAccountStatusAD.Location = new Point(6, 30);
            pnlChangeAccountStatusAD.Name = "pnlChangeAccountStatusAD";
            pnlChangeAccountStatusAD.Size = new Size(596, 303);
            pnlChangeAccountStatusAD.TabIndex = 17;
            // 
            // btnBacktoMMActivateDeactivate
            // 
            btnBacktoMMActivateDeactivate.FlatStyle = FlatStyle.Popup;
            btnBacktoMMActivateDeactivate.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBacktoMMActivateDeactivate.ForeColor = Color.Magenta;
            btnBacktoMMActivateDeactivate.ImageAlign = ContentAlignment.TopCenter;
            btnBacktoMMActivateDeactivate.Location = new Point(12, 12);
            btnBacktoMMActivateDeactivate.Name = "btnBacktoMMActivateDeactivate";
            btnBacktoMMActivateDeactivate.Size = new Size(51, 39);
            btnBacktoMMActivateDeactivate.TabIndex = 74;
            btnBacktoMMActivateDeactivate.Text = "🔙";
            btnBacktoMMActivateDeactivate.TextAlign = ContentAlignment.TopCenter;
            btnBacktoMMActivateDeactivate.UseVisualStyleBackColor = true;
            btnBacktoMMActivateDeactivate.Click += btnBacktoMMActivateDeactivate_Click;
            // 
            // dgvActivateDeactivate
            // 
            dgvActivateDeactivate.AllowUserToAddRows = false;
            dgvActivateDeactivate.AllowUserToDeleteRows = false;
            dgvActivateDeactivate.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActivateDeactivate.Columns.AddRange(new DataGridViewColumn[] { ADFirstName, ADUserId, ADStatus });
            dgvActivateDeactivate.Location = new Point(16, 59);
            dgvActivateDeactivate.Name = "dgvActivateDeactivate";
            dgvActivateDeactivate.ReadOnly = true;
            dgvActivateDeactivate.Size = new Size(564, 236);
            dgvActivateDeactivate.TabIndex = 17;
            dgvActivateDeactivate.CellContentClick += dgvActivateDeactivate_CellContentClick;
            // 
            // ADFirstName
            // 
            ADFirstName.DataPropertyName = "fname";
            ADFirstName.HeaderText = "FirstName";
            ADFirstName.Name = "ADFirstName";
            ADFirstName.ReadOnly = true;
            // 
            // ADUserId
            // 
            ADUserId.DataPropertyName = "userid";
            ADUserId.HeaderText = "UserId";
            ADUserId.Name = "ADUserId";
            ADUserId.ReadOnly = true;
            // 
            // ADStatus
            // 
            ADStatus.DataPropertyName = "status";
            ADStatus.HeaderText = "Status";
            ADStatus.Name = "ADStatus";
            ADStatus.ReadOnly = true;
            // 
            // pnlViewOwnSummaryReport
            // 
            pnlViewOwnSummaryReport.Controls.Add(btnBackToMMGuestSummary);
            pnlViewOwnSummaryReport.Controls.Add(txtVOSstatus);
            pnlViewOwnSummaryReport.Controls.Add(txtVOSfname);
            pnlViewOwnSummaryReport.Controls.Add(txtVOSid);
            pnlViewOwnSummaryReport.Controls.Add(label8);
            pnlViewOwnSummaryReport.Controls.Add(label7);
            pnlViewOwnSummaryReport.Controls.Add(label2);
            pnlViewOwnSummaryReport.Controls.Add(lblHistorySummary);
            pnlViewOwnSummaryReport.Controls.Add(txtHistorySummary);
            pnlViewOwnSummaryReport.ForeColor = Color.Black;
            pnlViewOwnSummaryReport.Location = new Point(3, 27);
            pnlViewOwnSummaryReport.Name = "pnlViewOwnSummaryReport";
            pnlViewOwnSummaryReport.Size = new Size(602, 292);
            pnlViewOwnSummaryReport.TabIndex = 18;
            // 
            // btnBackToMMGuestSummary
            // 
            btnBackToMMGuestSummary.FlatStyle = FlatStyle.Popup;
            btnBackToMMGuestSummary.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackToMMGuestSummary.ForeColor = Color.Magenta;
            btnBackToMMGuestSummary.ImageAlign = ContentAlignment.TopCenter;
            btnBackToMMGuestSummary.Location = new Point(9, 6);
            btnBackToMMGuestSummary.Name = "btnBackToMMGuestSummary";
            btnBackToMMGuestSummary.Size = new Size(51, 39);
            btnBackToMMGuestSummary.TabIndex = 74;
            btnBackToMMGuestSummary.Text = "🔙";
            btnBackToMMGuestSummary.TextAlign = ContentAlignment.TopCenter;
            btnBackToMMGuestSummary.UseVisualStyleBackColor = true;
            btnBackToMMGuestSummary.Click += btnBackToMMGuestSummary_Click_1;
            // 
            // txtVOSstatus
            // 
            txtVOSstatus.Enabled = false;
            txtVOSstatus.Location = new Point(244, 136);
            txtVOSstatus.Name = "txtVOSstatus";
            txtVOSstatus.Size = new Size(131, 23);
            txtVOSstatus.TabIndex = 39;
            // 
            // txtVOSfname
            // 
            txtVOSfname.Enabled = false;
            txtVOSfname.Location = new Point(243, 98);
            txtVOSfname.Name = "txtVOSfname";
            txtVOSfname.Size = new Size(195, 23);
            txtVOSfname.TabIndex = 38;
            // 
            // txtVOSid
            // 
            txtVOSid.Enabled = false;
            txtVOSid.Location = new Point(243, 64);
            txtVOSid.Name = "txtVOSid";
            txtVOSid.Size = new Size(70, 23);
            txtVOSid.TabIndex = 37;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.Info;
            label8.Location = new Point(180, 140);
            label8.Name = "label8";
            label8.Size = new Size(42, 15);
            label8.TabIndex = 35;
            label8.Text = "Status:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.Info;
            label7.Location = new Point(170, 104);
            label7.Name = "label7";
            label7.Size = new Size(67, 15);
            label7.TabIndex = 34;
            label7.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Info;
            label2.Location = new Point(190, 72);
            label2.Name = "label2";
            label2.Size = new Size(20, 15);
            label2.TabIndex = 33;
            label2.Text = "Id:";
            // 
            // lblHistorySummary
            // 
            lblHistorySummary.AutoSize = true;
            lblHistorySummary.ForeColor = SystemColors.Info;
            lblHistorySummary.Location = new Point(184, 173);
            lblHistorySummary.Name = "lblHistorySummary";
            lblHistorySummary.Size = new Size(223, 30);
            lblHistorySummary.TabIndex = 32;
            lblHistorySummary.Text = "                   History Summary:\r\n(roomType-NoOfDaysStayed-ExitedDate)";
            // 
            // txtHistorySummary
            // 
            txtHistorySummary.Location = new Point(184, 203);
            txtHistorySummary.Multiline = true;
            txtHistorySummary.Name = "txtHistorySummary";
            txtHistorySummary.ScrollBars = ScrollBars.Vertical;
            txtHistorySummary.Size = new Size(235, 24);
            txtHistorySummary.TabIndex = 31;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(617, 334);
            ControlBox = false;
            Controls.Add(pnlUpdateInfo);
            Controls.Add(pnlViewOwnSummaryReport);
            Controls.Add(pnlChangeAccountStatusAD);
            Controls.Add(pnlMakeReservation);
            Controls.Add(pnlViewAvailableRooms);
            Controls.Add(pnlCustomerMenu);
            Controls.Add(linklblBacktoLogin);
            ForeColor = SystemColors.MenuHighlight;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            pnlCustomerMenu.ResumeLayout(false);
            pnlCustomerMenu.PerformLayout();
            pnlUpdateInfo.ResumeLayout(false);
            pnlUpdateInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookingInfo).EndInit();
            pnlMakeReservation.ResumeLayout(false);
            pnlMakeReservation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNumberOfDays).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            pnlViewAvailableRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvViewAvailableR).EndInit();
            pnlChangeAccountStatusAD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActivateDeactivate).EndInit();
            pnlViewOwnSummaryReport.ResumeLayout(false);
            pnlViewOwnSummaryReport.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlCustomerMenu;
        private Label label1;
        private Button btnGuestSReoport;
        private Button btnDRactivateCA;
        private Button btnADroomExtend;
        private Button btnViewAvailableRoom;
        private Button btnMakeReservation;
        private Button btnUpdateInfo;
        private LinkLabel linklblBacktoLogin;
        private Panel panel1;
        private Button btnBacktoMMActivateDeactivate;
        private Button btnBacktoMMCAmenu;
        private Button btnBackToMMGuestSummary;
        private Button button4;
        private Button button5;
        private Button button6;
        private Panel pnlUpdateInfo;
        private Panel pnlMakeReservation;
        private Label label4;
        private Panel pnlViewAvailableRooms;
        private Panel pnlChangeAccountStatusAD;
        private Panel pnlViewOwnSummaryReport;
        private DataGridView dgvGuestSummary1;
        private DataGridView dataGridView1;
        private Label lblHistorySummary;
        private TextBox txtHistorySummary;
        private Label label8;
        private Label label7;
        private Label label2;
        private TextBox txtVOSstatus;
        private TextBox txtVOSfname;
        private TextBox txtVOSid;
        private NumericUpDown nudNumberOfDays;
        private Label label23;
        private Button btnSaveAssignR;
        private GroupBox groupBox2;
        private RadioButton rbTypePAssignR;
        private RadioButton rbTypeLAssignR;
        private RadioButton rbTypeSAssignR;
        private DataGridView dgvViewAvailableR;
        private DataGridView dgvActivateDeactivate;
        private DataGridViewTextBoxColumn ADFirstName;
        private DataGridViewTextBoxColumn ADUserId;
        private DataGridViewTextBoxColumn ADStatus;
        private Label lblnotifySignUP;
        private Label label3;
        private TextBox txtMPhone;
        private Label label13;
        private TextBox txtMLastName;
        private TextBox txtMAge;
        private ComboBox combMGender;
        private DateTimePicker dtpicker;
        private TextBox txtMFirstName;
        private Button btnMSave;
        private Label label14;
        private Label label15;
        private Label label16;
        private Label label17;
        private TextBox txtUuserStatus;
        private Label label6;
        private TextBox txtUuserid;
        private Label label5;
        private TextBox txtUusername;
        private Label label9;
        private Label label10;
        private TextBox txtUuserPassword;
        private Label label11;
        private Label label12;
        private Button btnCancelRoomUpdate;
        private DataGridView dgvBookingInfo;
        private Button btnBackToMRA;
        private Button btnBacktoMMviewAvailableR;
    }
}