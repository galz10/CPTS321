// <copyright file="SpreadSheetClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SpreadSheetEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using CPTS321;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed.")]

    /// <summary>
    /// spreadsheet class
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// Name:refrenceDictionary
        /// Description:this is where the refrences are stored
        /// </summary>
        private Dictionary<string, HashSet<string>> refrenceDictionary;

        /// <summary>
        /// Name:cells
        /// Description:sets up a 2d aray
        /// </summary>
        private Cell[,] cells;

        /// <summary>
        /// Name:Cell Property Changed
        /// </summary>
        public event PropertyChangedEventHandler CellPropertyChanged;

        /// <summary>
        /// Name:columnCount and rowCount
        /// Description:the count of rows and columns
        /// </summary>
        private int colCount, rowCount;

        /// <summary>
        /// Gets or sets the column count
        /// </summary>
        public int ColCount
        {
            get { return this.colCount; }
            set { this.colCount = value; }
        }

        /// <summary>
        /// Gets or sets row count
        /// </summary>
        public int RowCount
        {
            get { return this.rowCount; }
            set { this.rowCount = value; }
        }

        /// <summary>
        /// Name:GetCell
        /// Description:returns the cell if it is occupied or returns null
        /// </summary>
        /// <param name="rowIndex">rowIndex index</param>
        /// <param name="colIndex">column index</param>
        /// <returns>returns a cell</returns>
        public Cell GetCell(int rowIndex, int colIndex)
        {
            if (this.cells[rowIndex, colIndex] == null)
            {
                return null;
            }
            else
            {
                return this.cells[rowIndex, colIndex];
            }
        }

        /// <summary>
        /// Name:GetCell
        /// Description:gets the cell wiht a name inputed
        /// </summary>
        /// <param name="name">name of the cell</param>
        /// <returns>returns the cell</returns>
        public Cell GetCell(string name)
        {
            char column = name[0];
            int row;
            Cell cell;

            if (!char.IsLetter(column) || !int.TryParse(name.Substring(1), out row))
            {
                return null;
            }

            cell = this.GetCell(row - 1, column - 64);
            return cell;
        }

        /// <summary>
        /// Name:PropertyChanged
        /// Description:property changed function checks if the cell is = or not and if its = 'it knows that its pointing to something else
        /// </summary>
        /// <param name="sender">object( the cell)</param>
        /// <param name="e">event argument</param>
        public void PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Text Property Changed")
            {
                BaseCell baseCell = sender as BaseCell;
                string name = baseCell.ColIndex.ToString() + baseCell.RowIndex.ToString();

                this.DeleteRefrence(name);

                if (baseCell.Text != string.Empty && baseCell.Text[0] == '=' && baseCell.Text.Length > 1)
                {
                    ExpressionTree tree = new ExpressionTree(baseCell.Text.Substring(1));
                    this.SetRefrence(name, tree.GetVariable());
                }

                this.DetermineCellValue(sender as Cell);
            }
        }

        /// <summary>
        /// Name:BaseCell
        /// Description:sets up the base cell and has a inside functuon to set a different internal value
        /// </summary>
        private class BaseCell : Cell
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="BaseCell"/> class.
            /// </summary>
            /// <param name="rowIndex">rowIndex index</param>
            /// <param name="colIndex">colIndex index</param>
            public BaseCell(int rowIndex, char colIndex) : base(rowIndex, colIndex)
            {
            }

            /// <summary>
            /// Name:SetVal
            /// Description:sets value to new value
            /// </summary>
            /// <param name="newValue">new value</param>
            public void SetVal(string newValue)
            {
                this.value = newValue;
                this.PropertyChanged("Value Property Changed");
            }
        }

        /// <summary>
        /// Name:DetermineCellValue
        /// Description:Determines if the text written in the cell is a formula or if its just a text
        /// </summary>
        /// <param name="cell">the cell that you inputed text in</param>
        private void DetermineCellValue(Cell cell)
        {
            BaseCell determineCell = cell as BaseCell;
            string cellName = determineCell.ColIndex.ToString() + determineCell.RowIndex.ToString();

            if (determineCell.Text[0] == '=' && determineCell.Text.Length > 1)
            {
                double varValue;
                string text = determineCell.Text.Substring(1);
                ExpressionTree determineTree = new ExpressionTree(text);
                string[] variables = determineTree.GetVariable();
                foreach (string name in variables)
                {
                    Cell varCell = this.GetCell(name);
                    if (name == cellName)
                    {
                        determineCell.SetVal("ERROR: REFRENCING SELF");
                        this.CellPropertyChanged(cell, new PropertyChangedEventArgs("Value Property Changed"));
                        return;
                    }
                    else if (double.TryParse(varCell.Value, out varValue))
                    {
                        determineTree.SetVariable(name, varValue);
                    }
                    else
                    {
                        determineTree.SetVariable(name, 0);
                    }
                }

                determineCell.SetVal(determineTree.Evaluate().ToString());
                this.CellPropertyChanged(cell, new PropertyChangedEventArgs("Value Property Changed"));
            }
            else if (!string.IsNullOrWhiteSpace(determineCell.Text))
            {
                determineCell.SetVal(determineCell.Text);
                this.CellPropertyChanged(cell, new PropertyChangedEventArgs("Value Property Changed"));
            }
            else
            {
                determineCell.SetVal(string.Empty);
                this.CellPropertyChanged(cell, new PropertyChangedEventArgs("Value Property Changed"));
            }

            if (this.refrenceDictionary.ContainsKey(cellName))
            {
                foreach (string cells in this.refrenceDictionary[cellName])
                {
                    this.DetermineCellValue(this.GetCell(cells));
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Spreadsheet"/> class.
        /// </summary>
        /// <param name="numRows">rowIndex numbers</param>
        /// <param name="numColumns">colIndex numbers</param>
        public Spreadsheet(int numRows, int numColumns)
        {
            this.cells = new Cell[numRows, numColumns];
            this.refrenceDictionary = new Dictionary<string, HashSet<string>>();
            for (int i = 0; numRows > i; i++)
            {
                for (int x = 0; x < numColumns; x++)
                {
                    this.cells[i, x] = new BaseCell(i + 1, (char)(x + 64));
                    this.cells[i, x].CPropertyChanged += this.PropertyChanged;
                }
            }

            this.rowCount = numRows;
            this.colCount = numColumns;
        }

        /// <summary>
        /// Name:SetRefrence
        /// Description:Sets the refrence between two cells
        /// </summary>
        /// <param name="cellName">is the cell that you want to set a refrence to</param>
        /// <param name="variables">is the base cell that you want to get the text from</param>
        private void SetRefrence(string cellName, string[] variables)
        {
            foreach (string variableName in variables)
            {
                if (!this.refrenceDictionary.ContainsKey(variableName))
                {
                    this.refrenceDictionary[variableName] = new HashSet<string>();
                }

                this.refrenceDictionary[variableName].Add(cellName);
            }
        }

        /// <summary>
        /// Name:DeleteRefrence
        /// Description:Deletes the refrence between two cells
        /// </summary>
        /// <param name="cellName">is the cell that has a refrence</param>
        private void DeleteRefrence(string cellName)
        {
            List<string> dictionaryList = new List<string>();

            foreach (string key in this.refrenceDictionary.Keys)
            {
                if (this.refrenceDictionary[key].Contains(cellName))
                {
                    dictionaryList.Add(key);
                }
            }

            foreach (string item in dictionaryList)
            { 
                HashSet<string> set = this.refrenceDictionary[item];
                if (set.Contains(cellName))
                {
                    set.Remove(cellName);
                }
            }
        }
    }
}