namespace ProjectResources
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
            this.iconImageListBox = new System.Windows.Forms.ListBox();
            this.iconPictureBox1 = new System.Windows.Forms.PictureBox();
            this.bitMapListBox = new System.Windows.Forms.ListBox();
            this.bitMapPictureBox1 = new System.Windows.Forms.PictureBox();
            this.IconIdentifierLabel = new System.Windows.Forms.Label();
            this.Identifier = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitMapPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // iconImageListBox
            // 
            this.iconImageListBox.FormattingEnabled = true;
            this.iconImageListBox.Location = new System.Drawing.Point(12, 40);
            this.iconImageListBox.Name = "iconImageListBox";
            this.iconImageListBox.Size = new System.Drawing.Size(131, 69);
            this.iconImageListBox.TabIndex = 0;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.Location = new System.Drawing.Point(149, 40);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(100, 50);
            this.iconPictureBox1.TabIndex = 1;
            this.iconPictureBox1.TabStop = false;
            // 
            // bitMapListBox
            // 
            this.bitMapListBox.FormattingEnabled = true;
            this.bitMapListBox.Location = new System.Drawing.Point(13, 150);
            this.bitMapListBox.Name = "bitMapListBox";
            this.bitMapListBox.Size = new System.Drawing.Size(131, 69);
            this.bitMapListBox.TabIndex = 2;
            // 
            // bitMapPictureBox1
            // 
            this.bitMapPictureBox1.Location = new System.Drawing.Point(161, 150);
            this.bitMapPictureBox1.Name = "bitMapPictureBox1";
            this.bitMapPictureBox1.Size = new System.Drawing.Size(195, 94);
            this.bitMapPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.bitMapPictureBox1.TabIndex = 3;
            this.bitMapPictureBox1.TabStop = false;
            // 
            // IconIdentifierLabel
            // 
            this.IconIdentifierLabel.AutoSize = true;
            this.IconIdentifierLabel.Location = new System.Drawing.Point(12, 24);
            this.IconIdentifierLabel.Name = "IconIdentifierLabel";
            this.IconIdentifierLabel.Size = new System.Drawing.Size(35, 13);
            this.IconIdentifierLabel.TabIndex = 4;
            this.IconIdentifierLabel.Text = "label1";
            // 
            // Identifier
            // 
            this.Identifier.AutoSize = true;
            this.Identifier.Location = new System.Drawing.Point(12, 134);
            this.Identifier.Name = "Identifier";
            this.Identifier.Size = new System.Drawing.Size(35, 13);
            this.Identifier.TabIndex = 5;
            this.Identifier.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(516, 338);
            this.Controls.Add(this.Identifier);
            this.Controls.Add(this.IconIdentifierLabel);
            this.Controls.Add(this.bitMapPictureBox1);
            this.Controls.Add(this.bitMapListBox);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.iconImageListBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Singleton - get resources images by string name";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bitMapPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox iconImageListBox;
        private System.Windows.Forms.PictureBox iconPictureBox1;
        private System.Windows.Forms.ListBox bitMapListBox;
        private System.Windows.Forms.PictureBox bitMapPictureBox1;
        private System.Windows.Forms.Label IconIdentifierLabel;
        private System.Windows.Forms.Label Identifier;
    }
}

