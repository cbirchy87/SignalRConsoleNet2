namespace SN2UI
{
    partial class Form1
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
            this.connect_Btn = new System.Windows.Forms.Button();
            this.connect_Sub = new System.Windows.Forms.Button();
            this.event_tb = new System.Windows.Forms.TextBox();
            this.login_gb = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username_tb = new System.Windows.Forms.TextBox();
            this.password_tb = new System.Windows.Forms.TextBox();
            this.clientID_tb = new System.Windows.Forms.TextBox();
            this.validTokens_lb = new System.Windows.Forms.ListBox();
            this.tokenNumber_tb = new System.Windows.Forms.TextBox();
            this.addValidToken_btn = new System.Windows.Forms.Button();
            this.vaildTokens_gb = new System.Windows.Forms.GroupBox();
            this.login_gb.SuspendLayout();
            this.vaildTokens_gb.SuspendLayout();
            this.SuspendLayout();
            // 
            // connect_Btn
            // 
            this.connect_Btn.Location = new System.Drawing.Point(81, 146);
            this.connect_Btn.Name = "connect_Btn";
            this.connect_Btn.Size = new System.Drawing.Size(87, 31);
            this.connect_Btn.TabIndex = 0;
            this.connect_Btn.Text = "Connect";
            this.connect_Btn.UseVisualStyleBackColor = true;
            this.connect_Btn.Click += new System.EventHandler(this.connect_Btn_Click);
            // 
            // connect_Sub
            // 
            this.connect_Sub.Enabled = false;
            this.connect_Sub.Location = new System.Drawing.Point(314, 146);
            this.connect_Sub.Name = "connect_Sub";
            this.connect_Sub.Size = new System.Drawing.Size(87, 31);
            this.connect_Sub.TabIndex = 0;
            this.connect_Sub.Text = "Subscribe";
            this.connect_Sub.UseVisualStyleBackColor = true;
            this.connect_Sub.Click += new System.EventHandler(this.connect_Sub_Click);
            // 
            // event_tb
            // 
            this.event_tb.Location = new System.Drawing.Point(12, 217);
            this.event_tb.Multiline = true;
            this.event_tb.Name = "event_tb";
            this.event_tb.Size = new System.Drawing.Size(412, 206);
            this.event_tb.TabIndex = 1;
            // 
            // login_gb
            // 
            this.login_gb.Controls.Add(this.label1);
            this.login_gb.Controls.Add(this.Username);
            this.login_gb.Controls.Add(this.connect_Sub);
            this.login_gb.Controls.Add(this.label2);
            this.login_gb.Controls.Add(this.connect_Btn);
            this.login_gb.Controls.Add(this.username_tb);
            this.login_gb.Controls.Add(this.password_tb);
            this.login_gb.Controls.Add(this.clientID_tb);
            this.login_gb.Location = new System.Drawing.Point(12, 12);
            this.login_gb.Name = "login_gb";
            this.login_gb.Size = new System.Drawing.Size(412, 199);
            this.login_gb.TabIndex = 2;
            this.login_gb.TabStop = false;
            this.login_gb.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Client ID";
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(15, 42);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(60, 15);
            this.Username.TabIndex = 4;
            this.Username.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // username_tb
            // 
            this.username_tb.Location = new System.Drawing.Point(81, 39);
            this.username_tb.Name = "username_tb";
            this.username_tb.Size = new System.Drawing.Size(320, 23);
            this.username_tb.TabIndex = 3;
            this.username_tb.Text = "System engineer";
            // 
            // password_tb
            // 
            this.password_tb.Location = new System.Drawing.Point(81, 68);
            this.password_tb.Name = "password_tb";
            this.password_tb.Size = new System.Drawing.Size(320, 23);
            this.password_tb.TabIndex = 3;
            this.password_tb.TabStop = false;
            this.password_tb.Text = "admin";
            // 
            // clientID_tb
            // 
            this.clientID_tb.Location = new System.Drawing.Point(81, 97);
            this.clientID_tb.Multiline = true;
            this.clientID_tb.Name = "clientID_tb";
            this.clientID_tb.Size = new System.Drawing.Size(320, 43);
            this.clientID_tb.TabIndex = 3;
            // 
            // validTokens_lb
            // 
            this.validTokens_lb.FormattingEnabled = true;
            this.validTokens_lb.ItemHeight = 15;
            this.validTokens_lb.Location = new System.Drawing.Point(6, 39);
            this.validTokens_lb.Name = "validTokens_lb";
            this.validTokens_lb.Size = new System.Drawing.Size(248, 94);
            this.validTokens_lb.TabIndex = 3;
            // 
            // tokenNumber_tb
            // 
            this.tokenNumber_tb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tokenNumber_tb.Location = new System.Drawing.Point(6, 139);
            this.tokenNumber_tb.MaxLength = 8;
            this.tokenNumber_tb.Name = "tokenNumber_tb";
            this.tokenNumber_tb.Size = new System.Drawing.Size(167, 23);
            this.tokenNumber_tb.TabIndex = 4;
            // 
            // addValidToken_btn
            // 
            this.addValidToken_btn.Location = new System.Drawing.Point(179, 139);
            this.addValidToken_btn.Name = "addValidToken_btn";
            this.addValidToken_btn.Size = new System.Drawing.Size(75, 23);
            this.addValidToken_btn.TabIndex = 5;
            this.addValidToken_btn.Text = "Add";
            this.addValidToken_btn.UseVisualStyleBackColor = true;
            this.addValidToken_btn.Click += new System.EventHandler(this.addValidToken_btn_Click);
            // 
            // vaildTokens_gb
            // 
            this.vaildTokens_gb.Controls.Add(this.validTokens_lb);
            this.vaildTokens_gb.Controls.Add(this.addValidToken_btn);
            this.vaildTokens_gb.Controls.Add(this.tokenNumber_tb);
            this.vaildTokens_gb.Location = new System.Drawing.Point(430, 12);
            this.vaildTokens_gb.Name = "vaildTokens_gb";
            this.vaildTokens_gb.Size = new System.Drawing.Size(274, 199);
            this.vaildTokens_gb.TabIndex = 6;
            this.vaildTokens_gb.TabStop = false;
            this.vaildTokens_gb.Text = "ValidTokens";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 446);
            this.Controls.Add(this.vaildTokens_gb);
            this.Controls.Add(this.login_gb);
            this.Controls.Add(this.event_tb);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.login_gb.ResumeLayout(false);
            this.login_gb.PerformLayout();
            this.vaildTokens_gb.ResumeLayout(false);
            this.vaildTokens_gb.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connect_Btn;
        private System.Windows.Forms.Button connect_Sub;
        private System.Windows.Forms.TextBox event_tb;
        private System.Windows.Forms.GroupBox login_gb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox username_tb;
        private System.Windows.Forms.TextBox password_tb;
        private System.Windows.Forms.TextBox clientID_tb;
        private System.Windows.Forms.ListBox validTokens_lb;
        private System.Windows.Forms.TextBox tokenNumber_tb;
        private System.Windows.Forms.Button addValidToken_btn;
        private System.Windows.Forms.GroupBox vaildTokens_gb;
    }
}
