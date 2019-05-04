// <copyright file="CellClass.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SpreadSheetEngine
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Name:Cell class
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// Name:cellText , value
        /// </summary>
        protected string cellText, value;

        /// <summary>
        /// Name:row Index
        /// </summary>
        private readonly int rowIndex;

        /// <summary>
        /// Name:col Index
        /// </summary>
        private readonly char colIndex;

        /// <summary>
        /// Name:CProperty Changed
        /// </summary>
        public event PropertyChangedEventHandler CPropertyChanged;

        /// <summary>
        /// sets up a cell and <see cref="Cell"/>
        /// </summary>
        /// <param name="row">inputed row</param>
        /// <param name="col">inputed columns</param>
        public Cell(int row, char col)
        {
            this.rowIndex = row;
            this.colIndex = col;
        }

        /// <summary>
        /// Name:RowIndex
        /// Description:returns row index
        /// </summary>
        public int RowIndex
        {
            get { return this.rowIndex; }
        }

        /// <summary>
        /// Name:ColIndex
        /// Description: returns column index
        /// </summary>
        public char ColIndex
        {
            get { return this.colIndex; }
        }

        /// <summary>
        /// Name:Value
        /// Description:gets value
        /// </summary>
        public string Value
        {
            get { return this.value; }
        }

        /// <summary>
        /// Gets:cell text
        /// Sets: cell text
        /// </summary>sets and gets the celltext
        public string CellText
        {
            get
            {
                return this.cellText;
            }

            set
            {
                if (this.cellText != value)
                {
                    this.cellText = value;
                    this.PropertyChanged("Text Property Changed");
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// Name:Property Changed
        /// </summary>
        /// <param name="propertyName">property Name</param>
        public void PropertyChanged(string propertyName)
        {
            this.CPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Name:Property Changed
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
    }
}