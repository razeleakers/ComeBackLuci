namespace ComeBackLuci
{
    partial class ConfigDC
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
            System.Windows.Forms.Label label1;
            this.TB_Webhook = new System.Windows.Forms.TextBox();
            this.BTN_Check = new System.Windows.Forms.Button();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.errorProviderConfig = new System.Windows.Forms.ErrorProvider(this.components);
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ForeColor = System.Drawing.SystemColors.ControlText;
            label1.Location = new System.Drawing.Point(56, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(133, 24);
            label1.TabIndex = 0;
            label1.Text = "Webhook URL";
            // 
            // TB_Webhook
            // 
            this.TB_Webhook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_Webhook.Location = new System.Drawing.Point(12, 63);
            this.TB_Webhook.Name = "TB_Webhook";
            this.TB_Webhook.Size = new System.Drawing.Size(216, 22);
            this.TB_Webhook.TabIndex = 1;
            // 
            // BTN_Check
            // 
            this.BTN_Check.BackColor = System.Drawing.Color.LightGray;
            this.BTN_Check.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Check.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Check.Location = new System.Drawing.Point(12, 104);
            this.BTN_Check.Name = "BTN_Check";
            this.BTN_Check.Size = new System.Drawing.Size(89, 46);
            this.BTN_Check.TabIndex = 2;
            this.BTN_Check.Text = "Check";
            this.BTN_Check.UseVisualStyleBackColor = false;
            this.BTN_Check.Click += new System.EventHandler(this.BTN_Check_Click);
            // 
            // BTN_Save
            // 
            this.BTN_Save.BackColor = System.Drawing.Color.LightGray;
            this.BTN_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BTN_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Save.Location = new System.Drawing.Point(139, 104);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(89, 46);
            this.BTN_Save.TabIndex = 3;
            this.BTN_Save.Text = "Save and Close";
            this.BTN_Save.UseVisualStyleBackColor = false;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // errorProviderConfig
            // 
            this.errorProviderConfig.ContainerControl = this;
            // 
            // ConfigDC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ClientSize = new System.Drawing.Size(254, 162);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(this.BTN_Check);
            this.Controls.Add(this.TB_Webhook);
            this.Controls.Add(label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ConfigDC";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_Webhook;
        private System.Windows.Forms.Button BTN_Check;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.ErrorProvider errorProviderConfig;
    }
}