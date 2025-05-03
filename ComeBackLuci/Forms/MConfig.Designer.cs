namespace ComeBackLuci
{
    partial class MConfig
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label2;
            System.Windows.Forms.GroupBox GB_Server;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Panel panel1;
            System.Windows.Forms.Panel panel3;
            System.Windows.Forms.Panel panel4;
            System.Windows.Forms.Panel panel5;
            System.Windows.Forms.Panel panel2;
            this.BTN_Show = new System.Windows.Forms.Button();
            this.TB_Password = new System.Windows.Forms.TextBox();
            this.TB_Email = new System.Windows.Forms.TextBox();
            this.BTN_Send = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.EP_Form = new System.Windows.Forms.ErrorProvider(this.components);
            label2 = new System.Windows.Forms.Label();
            GB_Server = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            panel5 = new System.Windows.Forms.Panel();
            panel2 = new System.Windows.Forms.Panel();
            GB_Server.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EP_Form)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(23, 34);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 18);
            label2.TabIndex = 1;
            label2.Text = "Email:";
            // 
            // GB_Server
            // 
            GB_Server.BackColor = System.Drawing.Color.Transparent;
            GB_Server.Controls.Add(this.BTN_Show);
            GB_Server.Controls.Add(this.TB_Password);
            GB_Server.Controls.Add(label3);
            GB_Server.Controls.Add(this.TB_Email);
            GB_Server.Controls.Add(label2);
            GB_Server.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            GB_Server.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            GB_Server.Location = new System.Drawing.Point(20, 16);
            GB_Server.Name = "GB_Server";
            GB_Server.Size = new System.Drawing.Size(383, 121);
            GB_Server.TabIndex = 3;
            GB_Server.TabStop = false;
            GB_Server.Text = "Server";
            // 
            // BTN_Show
            // 
            this.BTN_Show.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.BTN_Show.Cursor = System.Windows.Forms.Cursors.Default;
            this.BTN_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Show.Font = new System.Drawing.Font("Bahnschrift", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Show.Location = new System.Drawing.Point(318, 73);
            this.BTN_Show.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Show.Name = "BTN_Show";
            this.BTN_Show.Size = new System.Drawing.Size(45, 23);
            this.BTN_Show.TabIndex = 3;
            this.BTN_Show.Text = "Show";
            this.BTN_Show.UseVisualStyleBackColor = false;
            this.BTN_Show.Click += new System.EventHandler(this.BTN_Show_Click);
            // 
            // TB_Password
            // 
            this.TB_Password.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Password.Location = new System.Drawing.Point(124, 73);
            this.TB_Password.Name = "TB_Password";
            this.TB_Password.PasswordChar = '*';
            this.TB_Password.Size = new System.Drawing.Size(173, 22);
            this.TB_Password.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Bahnschrift", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(23, 74);
            label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(78, 18);
            label3.TabIndex = 3;
            label3.Text = "Password:";
            // 
            // TB_Email
            // 
            this.TB_Email.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Email.Location = new System.Drawing.Point(124, 34);
            this.TB_Email.Name = "TB_Email";
            this.TB_Email.Size = new System.Drawing.Size(239, 22);
            this.TB_Email.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(this.BTN_Send);
            panel1.Location = new System.Drawing.Point(20, 15);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(176, 38);
            panel1.TabIndex = 8;
            // 
            // BTN_Send
            // 
            this.BTN_Send.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.BTN_Send.Cursor = System.Windows.Forms.Cursors.Default;
            this.BTN_Send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Send.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Send.Location = new System.Drawing.Point(3, 3);
            this.BTN_Send.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Send.Name = "BTN_Send";
            this.BTN_Send.Size = new System.Drawing.Size(167, 29);
            this.BTN_Send.TabIndex = 4;
            this.BTN_Send.Text = "Send Message";
            this.BTN_Send.UseVisualStyleBackColor = false;
            this.BTN_Send.Click += new System.EventHandler(this.BTN_Send_Click);
            // 
            // panel3
            // 
            panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel3.Controls.Add(GB_Server);
            panel3.Location = new System.Drawing.Point(5, 8);
            panel3.Margin = new System.Windows.Forms.Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(426, 159);
            panel3.TabIndex = 10;
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel4.Controls.Add(panel5);
            panel4.Controls.Add(panel3);
            panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            panel4.Location = new System.Drawing.Point(0, 0);
            panel4.Margin = new System.Windows.Forms.Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(438, 253);
            panel4.TabIndex = 11;
            // 
            // panel5
            // 
            panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel5.Controls.Add(panel2);
            panel5.Controls.Add(panel1);
            panel5.Location = new System.Drawing.Point(5, 172);
            panel5.Margin = new System.Windows.Forms.Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(426, 71);
            panel5.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel2.Controls.Add(this.BTN_Save);
            panel2.Location = new System.Drawing.Point(227, 15);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(176, 38);
            panel2.TabIndex = 9;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.BTN_Save.Cursor = System.Windows.Forms.Cursors.Default;
            this.BTN_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Save.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Save.Location = new System.Drawing.Point(3, 3);
            this.BTN_Save.Margin = new System.Windows.Forms.Padding(0);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(167, 29);
            this.BTN_Save.TabIndex = 5;
            this.BTN_Save.Text = "Save and Close";
            this.BTN_Save.UseVisualStyleBackColor = false;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // EP_Form
            // 
            this.EP_Form.ContainerControl = this;
            // 
            // MConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(438, 253);
            this.Controls.Add(panel4);
            this.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "MConfig";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ComeBackLuci | M3RFR3T & RESTART2LIFE";
            GB_Server.ResumeLayout(false);
            GB_Server.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EP_Form)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Email;
        private System.Windows.Forms.TextBox TB_Password;
        private System.Windows.Forms.Button BTN_Send;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_Show;
        private System.Windows.Forms.ErrorProvider EP_Form;
    }
}