// <copyright file="undoText.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SpreadSheetEngine
{
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// undoText class
    /// </summary>
    public class undoText : UndoRedoInterface
    {
        /// <summary>
        /// Name: cell
        /// </summary>
        private Cell cell;

        /// <summary>
        /// Name: text
        /// </summary>
        private string text;

        /// <summary>
        /// Name:undoText
        /// Description:Initializes a new instance of the <see cref="undoText"/> class.
        /// </summary>
        /// <param name="inputedText">inputed text</param>
        /// <param name="inputedCell">inputed cell</param>
        public undoText(string inputedText, Cell inputedCell)
        {
            this.text = inputedText;
            this.cell = inputedCell;
        }

        /// <summary>
        /// Name:Execute
        /// Description:executes the undotext action
        /// </summary>
        /// <param name="sheet">inputed sheet</param>
        /// <returns>undo text</returns>
        public UndoRedoInterface Execute(Spreadsheet sheet)
        {
            string name = this.cell.ColIndex.ToString() + this.cell.RowIndex.ToString();
            Cell cell = sheet.GetCell(name);
            string curText = cell.Text;
            this.cell.Text = this.text;
            return new undoText(curText, cell);
        }
    }
}