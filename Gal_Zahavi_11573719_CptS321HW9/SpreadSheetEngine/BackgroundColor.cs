// <copyright file="BackgroundColor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SpreadSheetEngine
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:FileHeaderFileNameDocumentationMustMatchTypeName", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Reviewed.")]

    /// <summary>
    /// Background color class
    /// </summary>
    public class BackgroundColor : UndoRedoInterface
    {
        /// <summary>
        /// Name: cell
        /// </summary>
        private Cell cell;

        /// <summary>
        /// Name: color
        /// </summary>
        private uint color;

        /// <summary>
        /// Name:BackgroundColor
        /// Description:Initializes a new instance of the <see cref="BackgroundColor"/> class.
        /// </summary>
        /// <param name="inputedColor">inputed color</param>
        /// <param name="inputedCell">inputed cell</param>
        public BackgroundColor(uint inputedColor, Cell inputedCell)
        {
            this.color = inputedColor;
            this.cell = inputedCell;
        }

        /// <summary>
        /// Name:Execute
        /// Description:Executes the background color change
        /// </summary>
        /// <param name="sheet">the sheet</param>
        /// <returns>background color</returns>
        public UndoRedoInterface Execute(Spreadsheet sheet)
        {
            string name = this.cell.ColIndex.ToString() + this.cell.RowIndex.ToString();
            uint currentColor = this.cell.Color;
            this.cell.Color = this.color;
            return new BackgroundColor(currentColor, this.cell);
        }
    }
}