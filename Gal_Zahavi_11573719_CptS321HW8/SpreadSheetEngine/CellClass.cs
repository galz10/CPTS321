// <copyright file="CellClass.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace SpreadSheetEngine
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using CPTS321;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1401:FieldsMustBePrivate", Justification = "Reviewed.")]

    /// <summary>
    /// Name:Cell class
    /// </summary>
    public abstract class Cell : INotifyPropertyChanged
    {
        /// <summary>
        /// value of the cell
        /// </summary>
        protected string value;

        /// <summary>
        /// text of the cell
        /// </summary>
        protected string text = string.Empty;

        /// <summary>
        /// Name:row Index
        /// </summary>
        private readonly int rowIndex;

        /// <summary>
        /// Name:col Index
        /// </summary>
        private readonly char colIndex;
       
        /// <summary>
        /// background color set to white
        /// </summary>
        private uint backgroundColor = 4294967295;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="row">inputed row</param>
        /// <param name="col">inputed columns</param>
        public Cell(int row, char col)
        {
            this.rowIndex = row;
            this.colIndex = col;
        }

        /// <summary>
        /// Gets or sets the text of the cell
        /// </summary>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (this.text == value)
                {
                    return;
                }

                this.text = value;
                this.PropertyChanged("Text Property Changed");
            }
        }

        /// <summary>
        /// Gets the value of the cell
        /// </summary>
        public string Value
        {
            get
            {
                return this.value;
            }
        }

        /// <summary>
        /// Gets the row index
        /// </summary>
        public int RowIndex
        {
            get
            {
                return this.rowIndex;
            }
        }

        /// <summary>
        /// Gets the column index
        /// </summary>
        public char ColIndex
        {
            get
            {
                return this.colIndex;
            }
        }

        /// <summary>
        /// Gets or sets the background color
        /// </summary>
        public uint Color
        {
            get
            {
                return this.backgroundColor;
            }

            set
            {
                if (this.backgroundColor == value)
                {
                    return;
                }
                else
                {
                    this.backgroundColor = value;
                    this.PropertyChanged("Background Property Changed");
                }
            }
        }

        /// <summary>
        /// Name:CProperty Changed
        /// </summary>
        public event PropertyChangedEventHandler CPropertyChanged;

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

        /// <summary>
        /// Name:Property Changed
        /// </summary>
        /// <param name="propertyName">property Name</param>
        public void PropertyChanged(string propertyName)
        {
            this.CPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}