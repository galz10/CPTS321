// <copyright file="UndoRedo.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SpreadSheetEngine
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// Name:UndoRedoI class
    /// </summary>
    public class UndoRedoI
    {
        /// <summary>
        /// Name:objects interface
        /// </summary>
        private UndoRedoInterface[] objects;

        /// <summary>
        /// Name:text string
        /// </summary>
        public string text;

        /// <summary>
        /// Initializes a new instance of the <see cref="UndoRedoI"/> class.
        /// </summary>
        public UndoRedoI()
        {
        }

        /// <summary>
        /// Name:UndoRedoI
        /// Description:Initializes a new instance of the <see cref="UndoRedoI"/> class.
        /// </summary>
        /// <param name="inputedText">inputed text</param>
        /// <param name="inputedAction">inputed action</param>
        public UndoRedoI(string inputedText, List<UndoRedoInterface> inputedAction)
        {
            this.text = inputedText;
            this.objects = inputedAction.ToArray();
        }

        /// <summary>
        /// Name:UndoRedoI
        /// Description:Initializes a new instance of the <see cref="UndoRedoI"/> class.
        /// </summary>
        /// <param name="inputedText">inputed text</param>
        /// <param name="inputedAction">inputed action</param>
        public UndoRedoI(string inputedText, UndoRedoInterface[] inputedAction)
        {
            this.text = inputedText;
            this.objects = inputedAction;
        }
        
        /// <summary>
        /// Name:Undo
        /// Description: sets up an undo
        /// </summary>
        /// <param name="inputedSpreadsheet">inputed spreadsheet</param>
        /// <returns>undo Redo</returns>
        public UndoRedoI Undo(Spreadsheet inputedSpreadsheet)
        {
            List<UndoRedoInterface> list = new List<UndoRedoInterface>();
            foreach (UndoRedoInterface action in this.objects)
            {
                list.Add(action.Execute(inputedSpreadsheet));
            }

            return new UndoRedoI(this.text, list.ToArray());
        }
    }
}