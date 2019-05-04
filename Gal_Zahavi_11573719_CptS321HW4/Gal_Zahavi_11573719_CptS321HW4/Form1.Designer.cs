// <copyright file="Form1.Designer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW4
{
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// form 1 
    /// </summary>
    public partial class Form1
    {
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1306:FieldNamesMustBeginWithLowerCaseLetter", Justification = "Reviewed.")]
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

        /// <summary>
        /// data Grid View
        /// </summary>
        private System.Windows.Forms.DataGridView dataGridView1;

        /// <summary>
        /// data grid view
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn A;

        /// <summary>
        /// data grid view
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn B;

        /// <summary>
        /// data grid view
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn C;

        /// <summary>
        /// datagrid view
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn D;

        /// <summary>
        /// data grid view
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn E;

        /// <summary>
        /// data grid view
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn F;

        /// <summary>
        /// data grid view
        /// </summary>
        private System.Windows.Forms.DataGridViewTextBoxColumn G;

        /// <summary>
        /// data grid view
        /// </summary>
        private System.Windows.Forms.BindingSource bindingSource1;

        /// <summary>
        /// data grid view
        /// </summary>
        private System.Windows.Forms.Button DemoButton;

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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.B = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.C = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.E = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.F = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.G = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.DemoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.A,
            this.B,
            this.C,
            this.D,
            this.E,
            this.F,
            this.G});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dataGridView1.RowTemplate.Height = 33;
            this.dataGridView1.Size = new System.Drawing.Size(1395, 805);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // A
            // 
            this.A.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.A.HeaderText = "A";
            this.A.Name = "A";
            this.A.Width = 71;
            // 
            // B
            // 
            this.B.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.B.HeaderText = "B";
            this.B.Name = "B";
            this.B.Width = 71;
            // 
            // C
            // 
            this.C.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.C.HeaderText = "C";
            this.C.Name = "C";
            this.C.Width = 72;
            // 
            // D
            // 
            this.D.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.D.HeaderText = "D";
            this.D.Name = "D";
            this.D.Width = 72;
            // 
            // E
            // 
            this.E.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.E.HeaderText = "E";
            this.E.Name = "E";
            this.E.Width = 71;
            // 
            // F
            // 
            this.F.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.F.HeaderText = "F";
            this.F.Name = "F";
            this.F.Width = 70;
            // 
            // G
            // 
            this.G.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.G.HeaderText = "G";
            this.G.Name = "G";
            this.G.Width = 73;
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // DemoButton
            // 
            this.DemoButton.AutoSize = true;
            this.DemoButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DemoButton.Location = new System.Drawing.Point(0, 748);
            this.DemoButton.Name = "DemoButton";
            this.DemoButton.Size = new System.Drawing.Size(1395, 57);
            this.DemoButton.TabIndex = 1;
            this.DemoButton.Text = "Start Demo";
            this.DemoButton.UseVisualStyleBackColor = true;
            this.DemoButton.Click += new System.EventHandler(this.DemoButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 805);
            this.Controls.Add(this.DemoButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}