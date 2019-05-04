// <copyright file="EditUR.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace SpreadSheetEngine
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1122:UseStringEmptyForEmptyStrings", Justification = "Reviewed.")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// UndoRedo interface 
    /// </summary>
    public interface UndoRedoInterface
    {
        /// <summary>
        /// Execute interface
        /// </summary>
        /// <param name="sheet">inputed sheet</param>
        /// <returns>returns the output</returns>
        UndoRedoInterface Execute(Spreadsheet sheet);
    }

    /// <summary>
    /// UndoRedo class
    /// </summary>
    public class UndoRedo
    {
        /// <summary>
        /// Name: undo stack
        /// </summary>
        private Stack<UndoRedoI> undo = new Stack<UndoRedoI>();
        
        /// <summary>
        /// Name: redo stack
        /// </summary>
        private Stack<UndoRedoI> redo = new Stack<UndoRedoI>();

        /// <summary>
        /// Gets a value indicating wether undo.count is not empty
        /// </summary>
        public bool isNotEmptyUndo
        {
            get
            {
                if (this.undo.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating wether redo.count is not empty
        /// </summary>
        public bool isNotEmptyRedo
        {
            get
            {
                if (this.redo.Count == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        /// <summary>
        /// Gets undo action if its not empty
        /// </summary>
        public string getUndoAction
        {
            get
            {
                if (!this.isNotEmptyUndo)
                {
                    return string.Empty;
                }
                else
                {
                    return this.undo.Peek().text;
                }
            }
        }

        /// <summary>
        /// Gets redo action if its not empty
        /// </summary>
        public string getRedoAction
        {
            get
            {
                if (!this.isNotEmptyRedo)
                {
                    return string.Empty;
                }
                else
                {
                    return this.redo.Peek().text;
                }
            }
        }

        /// <summary>
        /// Name:Undo
        /// Description: sets up undo action into redo stack
        /// </summary>
        /// <param name="undoAction">undo action</param>
        public void Undo(Spreadsheet undoAction)
        {
            UndoRedoI actions = this.undo.Pop();
            this.redo.Push(actions.Undo(undoAction));
        }

        /// <summary>
        /// Name:AddUndo
        /// Description:adds an action into undo stack
        /// </summary>
        /// <param name="inputedAction">inputed action</param>
        public void AddUndo(UndoRedoI inputedAction)
        {
            this.undo.Push(inputedAction);
            this.redo.Clear();
        }

        /// <summary>
        /// Name:Redo
        /// Description:sets up redo action into undo stack
        /// </summary>
        /// <param name="redoAction">redo action</param>
        public void Redo(Spreadsheet redoAction)
        {
            UndoRedoI actions = this.redo.Pop();
            this.undo.Push(actions.Undo(redoAction));
        }
    }
}