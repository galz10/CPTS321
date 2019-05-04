// <copyright file="Form1.Designer.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW12
{
    /// <summary>
    /// form 1 class
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// group box
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox1;

        /// <summary>
        /// url textbox
        /// </summary>
        private System.Windows.Forms.TextBox URLTextBox;

        /// <summary>
        /// group box
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox2;

        /// <summary>
        /// download results
        /// </summary>
        private System.Windows.Forms.TextBox DownloadResult;

        /// <summary>
        /// group box
        /// </summary>
        private System.Windows.Forms.GroupBox groupBox3;

        /// <summary>
        /// sorting text
        /// </summary>
        private System.Windows.Forms.TextBox SortingText;

        /// <summary>
        /// go to url
        /// </summary>
        private System.Windows.Forms.Button GoToURL;

        /// <summary>
        /// sort text
        /// </summary>
        private System.Windows.Forms.Button SortText;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DownloadResult = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SortingText = new System.Windows.Forms.TextBox();
            this.GoToURL = new System.Windows.Forms.Button();
            this.SortText = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.URLTextBox);
            this.groupBox1.Location = new System.Drawing.Point(42, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "URL";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(21, 41);
            this.URLTextBox.Multiline = true;
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(431, 30);
            this.URLTextBox.TabIndex = 0;
            this.URLTextBox.TextChanged += new System.EventHandler(this.URLTextBox_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DownloadResult);
            this.groupBox2.Location = new System.Drawing.Point(42, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(565, 381);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Download Result";
            // 
            // DownloadResult
            // 
            this.DownloadResult.Location = new System.Drawing.Point(21, 30);
            this.DownloadResult.Multiline = true;
            this.DownloadResult.Name = "DownloadResult";
            this.DownloadResult.Size = new System.Drawing.Size(520, 331);
            this.DownloadResult.TabIndex = 0;
            this.DownloadResult.TextChanged += new System.EventHandler(this.DownloadResult_TextChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SortingText);
            this.groupBox3.Location = new System.Drawing.Point(622, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 381);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sorting";
            // 
            // SortingText
            // 
            this.SortingText.Location = new System.Drawing.Point(17, 30);
            this.SortingText.Multiline = true;
            this.SortingText.Name = "SortingText";
            this.SortingText.Size = new System.Drawing.Size(306, 331);
            this.SortingText.TabIndex = 0;
            this.SortingText.TextChanged += new System.EventHandler(this.Sorting_TextChanged);
            // 
            // GoToURL
            // 
            this.GoToURL.Location = new System.Drawing.Point(622, 39);
            this.GoToURL.Name = "GoToURL";
            this.GoToURL.Size = new System.Drawing.Size(220, 42);
            this.GoToURL.TabIndex = 3;
            this.GoToURL.Text = "Go To URL\r\n";
            this.GoToURL.UseVisualStyleBackColor = true;
            this.GoToURL.Click += new System.EventHandler(this.GoToURL_Click);
            // 
            // SortText
            // 
            this.SortText.Location = new System.Drawing.Point(622, 111);
            this.SortText.Name = "SortText";
            this.SortText.Size = new System.Drawing.Size(220, 39);
            this.SortText.TabIndex = 4;
            this.SortText.Text = "Sort Text\r\n\r\n";
            this.SortText.UseVisualStyleBackColor = true;
            this.SortText.Click += new System.EventHandler(this.SortText_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 599);
            this.Controls.Add(this.SortText);
            this.Controls.Add(this.GoToURL);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
    }
}