
namespace Igtampe.UserTracer {
    partial class UserForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.NameBox = new System.Windows.Forms.TextBox();
            this.JoinDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ColorBox = new System.Windows.Forms.TextBox();
            this.ProfilePicturePicker = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.PFPPictureBox = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PFPPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NameBox
            // 
            this.NameBox.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameBox.Location = new System.Drawing.Point(82, 12);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(262, 39);
            this.NameBox.TabIndex = 0;
            this.NameBox.Text = "Professor Chopo";
            this.NameBox.TextChanged += new System.EventHandler(this.NameBox_TextChanged);
            // 
            // JoinDateTimePicker
            // 
            this.JoinDateTimePicker.Location = new System.Drawing.Point(140, 57);
            this.JoinDateTimePicker.Name = "JoinDateTimePicker";
            this.JoinDateTimePicker.Size = new System.Drawing.Size(204, 20);
            this.JoinDateTimePicker.TabIndex = 1;
            this.JoinDateTimePicker.ValueChanged += new System.EventHandler(this.JoinDateTimePicker_ValueChanged);
            // 
            // ColorBox
            // 
            this.ColorBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.ColorBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorBox.Location = new System.Drawing.Point(12, 83);
            this.ColorBox.Multiline = true;
            this.ColorBox.Name = "ColorBox";
            this.ColorBox.ReadOnly = true;
            this.ColorBox.Size = new System.Drawing.Size(332, 20);
            this.ColorBox.TabIndex = 3;
            this.ColorBox.Click += new System.EventHandler(this.ColorBox_Click);
            // 
            // ProfilePicturePicker
            // 
            this.ProfilePicturePicker.FileName = "Pfp.png";
            this.ProfilePicturePicker.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(82, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Joined";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(187, 416);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Font = new System.Drawing.Font("Lucida Sans Typewriter", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionBox.Location = new System.Drawing.Point(12, 109);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DescriptionBox.Size = new System.Drawing.Size(332, 133);
            this.DescriptionBox.TabIndex = 8;
            this.DescriptionBox.Text = "Description";
            this.DescriptionBox.WordWrap = false;
            this.DescriptionBox.TextChanged += new System.EventHandler(this.DescriptionBox_TextChanged);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(268, 416);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 11;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PreviewPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 162);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // PreviewPictureBox
            // 
            this.PreviewPictureBox.Location = new System.Drawing.Point(8, 19);
            this.PreviewPictureBox.Name = "PreviewPictureBox";
            this.PreviewPictureBox.Size = new System.Drawing.Size(317, 137);
            this.PreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviewPictureBox.TabIndex = 0;
            this.PreviewPictureBox.TabStop = false;
            this.PreviewPictureBox.Click += new System.EventHandler(this.PreviewBox_Click);
            // 
            // PFPPictureBox
            // 
            this.PFPPictureBox.Image = global::Igtampe.UserTracer.Properties.Resources.UnknownPerson;
            this.PFPPictureBox.Location = new System.Drawing.Point(12, 12);
            this.PFPPictureBox.Name = "PFPPictureBox";
            this.PFPPictureBox.Size = new System.Drawing.Size(64, 64);
            this.PFPPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PFPPictureBox.TabIndex = 2;
            this.PFPPictureBox.TabStop = false;
            this.PFPPictureBox.Click += new System.EventHandler(this.PFPPictureBox_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 451);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ColorBox);
            this.Controls.Add(this.PFPPictureBox);
            this.Controls.Add(this.JoinDateTimePicker);
            this.Controls.Add(this.NameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(371, 620);
            this.MinimumSize = new System.Drawing.Size(371, 320);
            this.Name = "UserForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PFPPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.DateTimePicker JoinDateTimePicker;
        private System.Windows.Forms.PictureBox PFPPictureBox;
        private System.Windows.Forms.TextBox ColorBox;
        private static System.Windows.Forms.ColorDialog CardColorPicker = new System.Windows.Forms.ColorDialog() {
            AnyColor = true,
            Color= System.Drawing.Color.DarkRed
        };
        private System.Windows.Forms.OpenFileDialog ProfilePicturePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox PreviewPictureBox;
    }
}