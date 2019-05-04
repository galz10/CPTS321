// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW4
{
    using System;
    using SpreadSheetEngine;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Reviewed.")]

    /// <summary>
    /// Name:Form1
    /// Description: Partial class for the windos form
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Name: undoRedo
        /// Description: sets up initialization of undoredo class
        /// </summary>
        public UndoRedo undoRedo = new UndoRedo();

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
            this.updateMenu();
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
            this.dataGridView1.CellEndEdit += this.dataGridView1_CellEndEdit;
            this.dataGridView1.CellBeginEdit += this.dataGridView1_CellBeginEdit;
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
                if (cellCol == 0)
                {
                    this.dataGridView1.Rows[updatedCell.RowIndex - 1].Cells[cellCol].Value = updatedCell.Value;
                }
                else
                {
                    this.dataGridView1.Rows[updatedCell.RowIndex - 1].Cells[cellCol - 1].Value = updatedCell.Value;
                }
            }

            if (e.PropertyName == "Background Property Change" && updatedCell != null)
            {
                this.dataGridView1.Rows[updatedCell.RowIndex - 1].Cells[cellCol - 1].Style.BackColor = Color.FromArgb((int)updatedCell.Color);
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
            Cell selectedCell = this.sheet.GetCell(row, column);    
            this.dataGridView1.Rows[row].Cells[column].Value = selectedCell.Text;
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
            Cell editedCell = this.sheet.GetCell(row, column);
            UndoRedoInterface[] actions = new UndoRedoInterface[1];
            actions[0] = new undoText(editedCell.Text, editedCell);
            if (this.dataGridView1.Rows[row].Cells[column].Value != null)
            {
                text = this.dataGridView1.Rows[row].Cells[column].Value.ToString();
            }
            else
            {
                text = " ";
            }

            editedCell.Text = text;
            this.undoRedo.AddUndo(new UndoRedoI("Text Property Changed", actions));
            this.dataGridView1.Rows[row].Cells[column].Value = editedCell.Value;
            this.updateMenu();
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

        /// <summary>
        /// Name:changeBackgroundColorToolStripMenuItem_Click
        /// Description:sets up the colordialog so you can change the background color
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void changeBackgroundColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            uint newcolor = 0;
            ColorDialog colorDialog = new ColorDialog();
            List<UndoRedoInterface> undo = new List<UndoRedoInterface>();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                newcolor = (uint)colorDialog.Color.ToArgb();
                foreach (DataGridViewCell cell in this.dataGridView1.SelectedCells)
                {
                    Cell sheetCell = this.sheet.GetCell(cell.RowIndex, cell.ColumnIndex);
                    undo.Add(new BackgroundColor(sheetCell.Color, sheetCell));
                    sheetCell.Color = newcolor;
                }

                this.undoRedo.AddUndo(new UndoRedoI("Background Property Change", undo));
                this.updateMenu();
            }
        }

        /// <summary>
        /// Name:undoToolStripMenuItem_Click
        /// Description undo action
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.undoRedo.Undo(this.sheet);
            this.updateMenu();
        }

        /// <summary>
        /// Name:redoToolStripMenuItem_Click
        /// Description: redo action
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.undoRedo.Redo(this.sheet);
            this.updateMenu();
        }

        /// <summary>
        /// Name:updateMenu
        /// Description: sets up the menu for edit item
        /// </summary>
        private void updateMenu()
        {
            ToolStripMenuItem menuitems = this.menuStrip1.Items[1] as ToolStripMenuItem;
            foreach (ToolStripItem item in menuitems.DropDownItems)
            {
                if (item.Text.Contains("Redo"))
                {
                    item.Enabled = this.undoRedo.isNotEmptyRedo;
                }
                else if (item.Text.Contains("Undo"))
                {
                    item.Enabled = this.undoRedo.isNotEmptyUndo;
                }
            }
        }

        /// <summary>
        /// Name:loadToolStripMenuItem_Click
        /// Description:loads the xml file
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileD = new OpenFileDialog();
            openFileD.Filter = "XML Files (*.xml)|*.xml";
            openFileD.DefaultExt = "xml";
            openFileD.AddExtension = true;

            if (openFileD.ShowDialog() == DialogResult.OK)
            {
                this.dataGridView1.ClearSelection();
                Stream savedFile = openFileD.OpenFile();
                this.sheet.LoadXML(savedFile);
            }
        }

        /// <summary>
        /// Name:saveToolStripMenuItem_Click
        /// Description:saves the spreadsheet into an xml file
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var savedFileD = new SaveFileDialog();
            savedFileD.Filter = "XML Files (*.xml)|*.xml";
            savedFileD.DefaultExt = "xml";
            savedFileD.AddExtension = true;

            if (savedFileD.ShowDialog() == DialogResult.OK)
            { 
                Stream savedFile = savedFileD.OpenFile();
                this.sheet.SaveXML(savedFile);
            }
        }
    }
}