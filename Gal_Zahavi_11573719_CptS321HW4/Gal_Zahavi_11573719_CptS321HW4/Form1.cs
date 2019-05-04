// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW4
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;
    using SpreadSheetEngine;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// Name:Form1
    /// Description: Partial class for the windos form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Name:sheet 
        /// Description: sets up the spreadsheet with row of 50 and columns of 26
        /// </summary>
        private Spreadsheet sheet = new Spreadsheet(50, 26);

        /// <summary>
        /// Name:Form1
        /// Description: initializes the components and <see cref="Form1"/>
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            Debug.Write("Hi");
        }

        /// <summary>
        /// Name:Form1_Load
        /// Description:loads the spreadsheet with the A-Z in the columns and 1-50 on rows
        /// </summary>
        /// <param name="sender">the object (the cell)</param>
        /// <param name="e">the event argument</param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Columns.Clear();
            char alphabet = 'A';
            for (int x = 0; x < 26; x++, alphabet++)
            {
                this.dataGridView1.Columns.Add(alphabet.ToString(), alphabet.ToString());
            }

            this.dataGridView1.Rows.Clear();
            for (int i = 1; i <= 50; i++)
            {
                this.dataGridView1.Rows.Add();
                this.dataGridView1.Rows[i - 1].HeaderCell.Value = i.ToString();
                this.dataGridView1.AutoResizeRowHeadersWidth(0, DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            }

            this.sheet.CellPropertyChanged += this.PropertyChanged;
        }

        /// <summary>
        /// Name:PropertyChanged
        /// Description:Property Changed function
        /// </summary>
        /// <param name="sender">the object (the cell)</param>
        /// <param name="e">the event argument</param>
        private void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Cell updatedCell = sender as Cell;
            int cellCol = updatedCell.ColIndex - 64;
            if (e.PropertyName == "Value Property Changed")
            {
                this.dataGridView1.Rows[updatedCell.RowIndex - 1].Cells[cellCol].Value = updatedCell.Value;
            }
        }

        /// <summary>
        /// Name:DemoButton_Click
        /// Description:When pressed it randomly sets hello world to cells, and then sents B1-50 
        /// </summary>
        /// <param name="sender">the object (the cell)</param>
        /// <param name="e">the event argument</param>
        private void DemoButton_Click(object sender, EventArgs e)
        {
            Random randomNums = new Random();
            for (int i = 0; i < 50; i++)
            {
                int rowNum = randomNums.Next(0, 50);
                int colNum = randomNums.Next(2, 26);
                this.sheet.cells[rowNum, colNum].CellText = "Hello World!";
            }

            for (int r = 0; r < 50; r++)
            {
                this.sheet.cells[r, 1].CellText = "This is cell B" + (r + 1);
                this.sheet.cells[r, 0].CellText = "=B" + (r + 1);
            }
      }

        /// <summary>
        /// Name:dataGridView1 CellContentClick
        /// </summary>
        /// <param name="sender">object( the cell)</param>
        /// <param name="e">event argument</param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        /// <summary>
        /// Name:bindingSource1 current changed
        /// </summary>
        /// <param name="sender">object( the cell)</param>
        /// <param name="e">event argument</param>
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
        }
    }
}