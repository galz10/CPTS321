// <copyright file="Form1.Designer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW3
{
    /// <summary>
    /// creates a class for form1
    /// </summary>
    public partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// loads textbox
        /// </summary>
        private System.Windows.Forms.TextBox textBox1;

        /// <summary>
        /// loads menu strip 
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;

        /// <summary>
        /// sets up load file button
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem loadFileToolStripMenuItem;

        /// <summary>
        /// sets up load Fibonacci number 50
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem loadFibinachiToolStripMenuItem;

        /// <summary>
        /// sets up load Fibonacci number 100
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem loadFibonacciNumbersfirst100ToolStripMenuItem;

        /// <summary>
        /// sets up save file button
        /// </summary>
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;

        /// <summary>
        /// sets up menu strip
        /// </summary>
        private System.Windows.Forms.MenuStrip menuStrip1;

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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFibinachiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFibonacciNumbersfirst100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 40);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(513, 335);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadFileToolStripMenuItem,
            this.loadFibinachiToolStripMenuItem,
            this.loadFibonacciNumbersfirst100ToolStripMenuItem,
            this.saveToFileToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(64, 36);
            this.menuToolStripMenuItem.Text = "File";
            this.menuToolStripMenuItem.Click += new System.EventHandler(this.MenuToolStripMenuItem_Click);
            // 
            // loadFileToolStripMenuItem
            // 
            this.loadFileToolStripMenuItem.Name = "loadFileToolStripMenuItem";
            this.loadFileToolStripMenuItem.Size = new System.Drawing.Size(480, 38);
            this.loadFileToolStripMenuItem.Text = "Load from file...";
            this.loadFileToolStripMenuItem.Click += new System.EventHandler(this.LoadFileToolStripMenuItem_Click);
            // 
            // loadFibinachiToolStripMenuItem
            // 
            this.loadFibinachiToolStripMenuItem.Name = "loadFibinachiToolStripMenuItem";
            this.loadFibinachiToolStripMenuItem.Size = new System.Drawing.Size(480, 38);
            this.loadFibinachiToolStripMenuItem.Text = "Load Fibonacci numbers (first 50)";
            this.loadFibinachiToolStripMenuItem.Click += new System.EventHandler(this.LoadFibinachiToolStripMenuItem_Click);
            // 
            // loadFibonacciNumbersfirst100ToolStripMenuItem
            // 
            this.loadFibonacciNumbersfirst100ToolStripMenuItem.Name = "loadFibonacciNumbersfirst100ToolStripMenuItem";
            this.loadFibonacciNumbersfirst100ToolStripMenuItem.Size = new System.Drawing.Size(480, 38);
            this.loadFibonacciNumbersfirst100ToolStripMenuItem.Text = "Load Fibonacci numbers (first 100)";
            this.loadFibonacciNumbersfirst100ToolStripMenuItem.Click += new System.EventHandler(this.LoadFibonacciNumbersfirst100ToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(480, 38);
            this.saveToFileToolStripMenuItem.Text = "Save to file...";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.SaveToFileToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 40);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "Menu";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(513, 375);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Notepad Application";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            PerformLayout();
        }
        #endregion
    }
}
