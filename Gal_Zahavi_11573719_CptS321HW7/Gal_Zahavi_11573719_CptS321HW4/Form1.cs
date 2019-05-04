// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW4
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;
    using SpreadSheetEngine;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]

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
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
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
            dataGridView1.CellEndEdit += this.dataGridView1_CellEndEdit;
            dataGridView1.CellBeginEdit += this.dataGridView1_CellBeginEdit;
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
            if (e.PropertyName == "Value Property Changed" && updatedCell != null)
            {
                this.dataGridView1.Rows[updatedCell.RowIndex - 1].Cells[cellCol - 1].Value = updatedCell.Value;
            }
        }

        /// <summary>
        /// Name:dataGridView1_CellBeginEdit
        /// Description: is a function that is an event when the cell is begining to be edited 
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">the event arg</param>
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            int row = e.RowIndex, column = e.ColumnIndex;
            Cell selectedCell = this.sheet.GetCell(row, column + 1);    
            dataGridView1.Rows[row].Cells[column].Value = selectedCell.Text;
        }

        /// <summary>
        /// Name:dataGridView1_CellEndEdit
        /// Description: is a function that is an event when the cell is done being edited 
        /// </summary>
        /// <param name="sender">the object</param>
        /// <param name="e">the event arg</param>
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string text;
            int row = e.RowIndex, column = e.ColumnIndex;
            Cell editedCell = this.sheet.GetCell(row, column + 1);

            if (dataGridView1.Rows[row].Cells[column].Value != null)
            {
                text = this.dataGridView1.Rows[row].Cells[column].Value.ToString();
            }
            else
            {
                text = string.Empty;
            }

            editedCell.Text = text;
            this.dataGridView1.Rows[row].Cells[column].Value = editedCell.Value;
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