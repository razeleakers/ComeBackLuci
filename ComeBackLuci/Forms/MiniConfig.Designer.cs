namespace ComeBackLuci
{
    partial class MiniConfig
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
            this.TB_URL = new System.Windows.Forms.TextBox();
            this.BTN_Save = new System.Windows.Forms.Button();
            this.BTN_Check = new System.Windows.Forms.Button();
            this.errorProviderConfig = new System.Windows.Forms.ErrorProvider(this.components);
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(60, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(128, 19);
            label1.TabIndex = 2;
            label1.Text = "WebHook URL:";
            // 
            // TB_URL
            // 
            this.TB_URL.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_URL.Location = new System.Drawing.Point(12, 61);
            this.TB_URL.Name = "TB_URL";
            this.TB_URL.Size = new System.Drawing.Size(219, 20);
            this.TB_URL.TabIndex = 0;
            // 
            // BTN_Save
            // 
            this.BTN_Save.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BTN_Save.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Save.Location = new System.Drawing.Point(131, 96);
            this.BTN_Save.Name = "BTN_Save";
            this.BTN_Save.Size = new System.Drawing.Size(100, 45);
            this.BTN_Save.TabIndex = 4;
            this.BTN_Save.Text = "Save and close";
            this.BTN_Save.UseVisualStyleBackColor = true;
            this.BTN_Save.Click += new System.EventHandler(this.BTN_Save_Click);
            // 
            // BTN_Check
            // 
            this.BTN_Check.Cursor = System.Windows.Forms.Cursors.Cross;
            this.BTN_Check.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Check.Location = new System.Drawing.Point(12, 96);
            this.BTN_Check.Name = "BTN_Check";
            this.BTN_Check.Size = new System.Drawing.Size(100, 45);
            this.BTN_Check.TabIndex = 5;
            this.BTN_Check.Text = "Check";
            this.BTN_Check.UseVisualStyleBackColor = true;
            this.BTN_Check.Click += new System.EventHandler(this.BTN_Check_Click);
            // 
            // errorProviderConfig
            // 
            this.errorProviderConfig.ContainerControl = this;
            // 
            // MiniConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(254, 162);
            this.Controls.Add(this.BTN_Check);
            this.Controls.Add(this.BTN_Save);
            this.Controls.Add(label1);
            this.Controls.Add(this.TB_URL);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "MiniConfig";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConfig)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_URL;
        private System.Windows.Forms.Button BTN_Save;
        private System.Windows.Forms.Button BTN_Check;
        private System.Windows.Forms.ErrorProvider errorProviderConfig;
    }
}