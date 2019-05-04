// <copyright file="SpreadSheetClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SpreadSheetEngine
{
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]

    /// <summary>
    /// spreadsheet class
    /// </summary>
    public class Spreadsheet
    {
        /// <summary>
        /// Name:cells
        /// Description:sets up a 2d aray
        /// </summary>
        public Cell[,] cells;

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
        /// Name:ColCount
        /// Gets: colcount
        /// Set: colcount
        /// </summary>
        public int ColCount
        {
            get { return this.colCount; }
            set { this.colCount = value; }
        }

        /// <summary>
        /// Name:RowCount
        /// Gets: rowlcount
        /// Set: rowcount
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

                if (baseCell.CellText[0] == '=')
                {
                    string text = baseCell.CellText.Substring(1);
                    int tempCol, tempRow;

                    if (text.Length > 2)
                    {
                        tempCol = text[0] - 65;
                        text = text.Substring(1);
                        int.TryParse(text, out tempRow);
                        tempRow--;
                    }
                    else if (text.Length == 2)
                    {
                        tempCol = text[0] - 65;
                        tempRow = text[1] - 49;
                    }
                    else
                    {
                        tempCol = -1;
                        tempRow = -1;
                    }

                    Cell tempCell = this.GetCell(tempRow, tempCol);

                    if (sender != null)
                    {
                        baseCell.SetVal(tempCell.CellText);
                        this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value Property Changed"));  
                    }
                    else
                    {
                        baseCell.SetVal("null");
                        this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value Property Changed"));
                    }
                }
                else if (string.IsNullOrWhiteSpace(baseCell.CellText))
                {
                    baseCell.SetVal(string.Empty);
                    this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value Property Changed"));
                }
                else
                {
                    baseCell.SetVal(baseCell.CellText);
                    this.CellPropertyChanged(sender, new PropertyChangedEventArgs("Value Property Changed"));
                }
            }
        }

        /// <summary>
        /// Name:BaseCell
        /// Description:sets up the base cell and has a inside functuon to set a different internal value
        /// </summary>
        private class BaseCell : Cell
        {
            /// <summary>
            /// Name:BaseCell
            /// Description:sets up a basic cell with a character for columns and integer for rows and <see cref="BaseCell"/>
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
        /// sets up the spreadsheet with the inputed number of columns and rows and initliezes <see cref="Spreadsheet"/> class
        /// </summary>
        /// <param name="numRows">rowIndex numbers</param>
        /// <param name="numColumns">colIndex numbers</param>
        public Spreadsheet(int numRows, int numColumns)
        {
            this.cells = new Cell[numRows, numColumns];
            for (int i = 0;numRows > i; i++)
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
    }
}
