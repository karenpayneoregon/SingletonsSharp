namespace ApplicationDataConnectorRecommended
{
    partial class Form1
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
            this.ConnectUsingAppSettingButton = new System.Windows.Forms.Button();
            this.ConnectionStringFromProjectSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConnectUsingAppSettingButton
            // 
            this.ConnectUsingAppSettingButton.Location = new System.Drawing.Point(23, 12);
            this.ConnectUsingAppSettingButton.Name = "ConnectUsingAppSettingButton";
            this.ConnectUsingAppSettingButton.Size = new System.Drawing.Size(230, 23);
            this.ConnectUsingAppSettingButton.TabIndex = 0;
            this.ConnectUsingAppSettingButton.Text = "From AppSetting";
            this.ConnectUsingAppSettingButton.UseVisualStyleBackColor = true;
            this.ConnectUsingAppSettingButton.Click += new System.EventHandler(this.ConnectUsingAppSettingButton_Click);
            // 
            // ConnectionStringFromProjectSettingsButton
            // 
            this.ConnectionStringFromProjectSettingsButton.Location = new System.Drawing.Point(23, 41);
            this.ConnectionStringFromProjectSettingsButton.Name = "ConnectionStringFromProjectSettingsButton";
            this.ConnectionStringFromProjectSettingsButton.Size = new System.Drawing.Size(230, 23);
            this.ConnectionStringFromProjectSettingsButton.TabIndex = 1;
            this.ConnectionStringFromProjectSettingsButton.Text = "From project settings";
            this.ConnectionStringFromProjectSettingsButton.UseVisualStyleBackColor = true;
            this.ConnectionStringFromProjectSettingsButton.Click += new System.EventHandler(this.ConnectionStringFromProjectSettingsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 83);
            this.Controls.Add(this.ConnectionStringFromProjectSettingsButton);
            this.Controls.Add(this.ConnectUsingAppSettingButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connection string from config file";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ConnectUsingAppSettingButton;
        private System.Windows.Forms.Button ConnectionStringFromProjectSettingsButton;
    }
}

