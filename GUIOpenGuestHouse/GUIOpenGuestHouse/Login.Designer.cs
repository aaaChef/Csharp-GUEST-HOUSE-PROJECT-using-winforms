namespace GUIOpenGuestHouse
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlSignup = new Panel();
            linklblBLogin = new LinkLabel();
            lblnotifySignUP = new Label();
            label10 = new Label();
            txtPhone = new TextBox();
            label4 = new Label();
            txtLastName = new TextBox();
            txtAge = new TextBox();
            combGender = new ComboBox();
            dtpicker = new DateTimePicker();
            txtFirstName = new TextBox();
            btnSave = new Button();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            pnlLogin = new Panel();
            groupBox1 = new GroupBox();
            lblLNotify = new Label();
            label19 = new Label();
            rbLusername = new RadioButton();
            rbLuserid = new RadioButton();
            txtLUserName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new Button();
            txtLPassword = new TextBox();
            label3 = new Label();
            linklblSignUp = new LinkLabel();
            pnlSignup.SuspendLayout();
            pnlLogin.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSignup
            // 
            pnlSignup.Controls.Add(linklblBLogin);
            pnlSignup.Controls.Add(lblnotifySignUP);
            pnlSignup.Controls.Add(label10);
            pnlSignup.Controls.Add(txtPhone);
            pnlSignup.Controls.Add(label4);
            pnlSignup.Controls.Add(txtLastName);
            pnlSignup.Controls.Add(txtAge);
            pnlSignup.Controls.Add(combGender);
            pnlSignup.Controls.Add(dtpicker);
            pnlSignup.Controls.Add(txtFirstName);
            pnlSignup.Controls.Add(btnSave);
            pnlSignup.Controls.Add(label5);
            pnlSignup.Controls.Add(label6);
            pnlSignup.Controls.Add(label7);
            pnlSignup.Controls.Add(label8);
            pnlSignup.Location = new Point(1, 12);
            pnlSignup.Name = "pnlSignup";
            pnlSignup.Size = new Size(482, 251);
            pnlSignup.TabIndex = 7;
            // 
            // linklblBLogin
            // 
            linklblBLogin.AutoSize = true;
            linklblBLogin.BackColor = Color.Silver;
            linklblBLogin.Location = new Point(359, 227);
            linklblBLogin.Name = "linklblBLogin";
            linklblBLogin.Size = new Size(108, 15);
            linklblBLogin.TabIndex = 30;
            linklblBLogin.TabStop = true;
            linklblBLogin.Text = "Back to Login page";
            linklblBLogin.LinkClicked += linklblBLogin_LinkClicked;
            // 
            // lblnotifySignUP
            // 
            lblnotifySignUP.AutoSize = true;
            lblnotifySignUP.ForeColor = Color.Red;
            lblnotifySignUP.Location = new Point(175, 30);
            lblnotifySignUP.Name = "lblnotifySignUP";
            lblnotifySignUP.Size = new Size(0, 15);
            lblnotifySignUP.TabIndex = 29;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(102, 22);
            label10.Name = "label10";
            label10.Size = new Size(240, 23);
            label10.TabIndex = 28;
            label10.Text = "Create your account !";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(145, 107);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(266, 23);
            txtPhone.TabIndex = 24;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.Info;
            label4.Location = new Point(47, 115);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 23;
            label4.Text = "Phone Number:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(145, 77);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(266, 23);
            txtLastName.TabIndex = 22;
            // 
            // txtAge
            // 
            txtAge.Location = new Point(364, 138);
            txtAge.Name = "txtAge";
            txtAge.ReadOnly = true;
            txtAge.Size = new Size(47, 23);
            txtAge.TabIndex = 21;
            // 
            // combGender
            // 
            combGender.DropDownStyle = ComboBoxStyle.DropDownList;
            combGender.FormattingEnabled = true;
            combGender.Items.AddRange(new object[] { "Male", "Female", "Other" });
            combGender.Location = new Point(145, 170);
            combGender.Name = "combGender";
            combGender.Size = new Size(121, 23);
            combGender.TabIndex = 20;
            // 
            // dtpicker
            // 
            dtpicker.Location = new Point(145, 138);
            dtpicker.Name = "dtpicker";
            dtpicker.Size = new Size(211, 23);
            dtpicker.TabIndex = 19;
            dtpicker.ValueChanged += dtpicker_ValueChanged;
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(145, 48);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(266, 23);
            txtFirstName.TabIndex = 18;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.Black;
            btnSave.Location = new Point(191, 199);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 26);
            btnSave.TabIndex = 17;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = SystemColors.Info;
            label5.Location = new Point(85, 173);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 16;
            label5.Text = "Gender:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = SystemColors.Info;
            label6.Location = new Point(102, 144);
            label6.Name = "label6";
            label6.Size = new Size(31, 15);
            label6.TabIndex = 15;
            label6.Text = "Age:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = SystemColors.Info;
            label7.Location = new Point(73, 85);
            label7.Name = "label7";
            label7.Size = new Size(66, 15);
            label7.TabIndex = 14;
            label7.Text = "Last Name:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = SystemColors.Info;
            label8.Location = new Point(72, 56);
            label8.Name = "label8";
            label8.Size = new Size(67, 15);
            label8.TabIndex = 13;
            label8.Text = "First Name:";
            // 
            // pnlLogin
            // 
            pnlLogin.Controls.Add(groupBox1);
            pnlLogin.Controls.Add(label3);
            pnlLogin.Controls.Add(linklblSignUp);
            pnlLogin.Location = new Point(15, 12);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(456, 262);
            pnlLogin.TabIndex = 8;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblLNotify);
            groupBox1.Controls.Add(label19);
            groupBox1.Controls.Add(rbLusername);
            groupBox1.Controls.Add(rbLuserid);
            groupBox1.Controls.Add(txtLUserName);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(btnLogin);
            groupBox1.Controls.Add(txtLPassword);
            groupBox1.Location = new Point(28, 50);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(382, 150);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // lblLNotify
            // 
            lblLNotify.AutoSize = true;
            lblLNotify.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLNotify.ForeColor = Color.Red;
            lblLNotify.Location = new Point(50, 6);
            lblLNotify.Name = "lblLNotify";
            lblLNotify.Size = new Size(0, 15);
            lblLNotify.TabIndex = 15;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.ForeColor = Color.Yellow;
            label19.Location = new Point(5, 35);
            label19.Name = "label19";
            label19.Size = new Size(128, 15);
            label19.TabIndex = 14;
            label19.Text = "Choose Login Method:";
            // 
            // rbLusername
            // 
            rbLusername.AutoSize = true;
            rbLusername.ForeColor = Color.Aqua;
            rbLusername.Location = new Point(205, 33);
            rbLusername.Name = "rbLusername";
            rbLusername.Size = new Size(77, 19);
            rbLusername.TabIndex = 13;
            rbLusername.TabStop = true;
            rbLusername.Text = "username";
            rbLusername.UseVisualStyleBackColor = true;
            rbLusername.CheckedChanged += rbLusername_CheckedChanged;
            // 
            // rbLuserid
            // 
            rbLuserid.AutoSize = true;
            rbLuserid.ForeColor = Color.Aqua;
            rbLuserid.Location = new Point(140, 34);
            rbLuserid.Name = "rbLuserid";
            rbLuserid.Size = new Size(57, 19);
            rbLuserid.TabIndex = 12;
            rbLuserid.TabStop = true;
            rbLuserid.Text = "userid";
            rbLuserid.UseVisualStyleBackColor = true;
            rbLuserid.CheckedChanged += rbLuserid_CheckedChanged;
            // 
            // txtLUserName
            // 
            txtLUserName.BorderStyle = BorderStyle.None;
            txtLUserName.Location = new Point(122, 65);
            txtLUserName.Name = "txtLUserName";
            txtLUserName.ReadOnly = true;
            txtLUserName.Size = new Size(243, 16);
            txtLUserName.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.Info;
            label1.Location = new Point(23, 66);
            label1.Name = "label1";
            label1.Size = new Size(85, 15);
            label1.TabIndex = 6;
            label1.Text = "Enter Account:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.Info;
            label2.Location = new Point(42, 98);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 10;
            label2.Text = "Password:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.LawnGreen;
            btnLogin.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(163, 117);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(75, 27);
            btnLogin.TabIndex = 8;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // txtLPassword
            // 
            txtLPassword.BorderStyle = BorderStyle.None;
            txtLPassword.Location = new Point(121, 94);
            txtLPassword.Name = "txtLPassword";
            txtLPassword.PasswordChar = '*';
            txtLPassword.ReadOnly = true;
            txtLPassword.Size = new Size(244, 16);
            txtLPassword.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Showcard Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(51, 24);
            label3.Name = "label3";
            label3.Size = new Size(326, 23);
            label3.TabIndex = 12;
            label3.Text = "Welcome to Open Guest House!";
            // 
            // linklblSignUp
            // 
            linklblSignUp.AutoSize = true;
            linklblSignUp.BackColor = Color.LightGray;
            linklblSignUp.Location = new Point(177, 203);
            linklblSignUp.Name = "linklblSignUp";
            linklblSignUp.Size = new Size(112, 15);
            linklblSignUp.TabIndex = 9;
            linklblSignUp.TabStop = true;
            linklblSignUp.Text = "Create new account";
            linklblSignUp.LinkClicked += lbLinkSignUp_LinkClicked;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(486, 277);
            Controls.Add(pnlLogin);
            Controls.Add(pnlSignup);
            ForeColor = Color.IndianRed;
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OpenGuestHouse";
            Load += Login_Load;
            pnlSignup.ResumeLayout(false);
            pnlSignup.PerformLayout();
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSignup;
        private Panel pnlLogin;
        private Label label3;
        private TextBox txtLPassword;
        private Label label2;
        private LinkLabel linklblSignUp;
        private Button btnLogin;
        private TextBox txtLUserName;
        private Label label1;
        private TextBox txtLastName;
        private TextBox txtAge;
        private ComboBox combGender;
        private DateTimePicker dtpicker;
        private TextBox txtFirstName;
        private Button btnSave;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtPhone;
        private Label label4;
        private Label label10;
        private Label lblnotifySignUP;
        private LinkLabel linklblBLogin;
        private GroupBox groupBox1;
        private Label label19;
        private RadioButton rbLusername;
        private RadioButton rbLuserid;
        private Label lblLNotify;
    }
}
