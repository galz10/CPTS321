// <copyright file="Form1.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW3
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Windows.Forms;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// creates a class for form1
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Name:openfiledialog
        /// Description:open the openfiledialog so you can open files from computer
        /// </summary>
        private static OpenFileDialog openFileDialog = new OpenFileDialog();

        /// <summary>
        /// Name:savefiledialog
        /// Description:open the savefiledialog so you can save files from computer
        /// </summary>
        private static SaveFileDialog saveFileDialog = new SaveFileDialog();

        /// <summary>
        /// Name:Form1
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Name:textbox1_textchanged
        /// Description:a function for the textbox thats on form1
        /// </summary>
        /// <param name="sender">Object Sencder</param>
        /// <param name="e">Event Argument e</param>
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Name:LoadText
        /// Description:loads the text into the textbox
        /// </summary>
        /// <param name="str">Textreader str</param>
        private void LoadText(TextReader str)
        {
            this.textBox1.Text = str.ReadToEnd();
        }

        /// <summary>
        /// Name:MenuToolStripMenuItem_Click
        /// Description:loads the function for the menu click so there's a dropdown menu
        /// </summary>
        /// <param name="sender">Object Sencder</param>
        /// <param name="e">Event Argument e</param>
        private void MenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Name:LoadFileToolStripMenuItem_Click
        /// Description:This load a txt file and loads it into the textbox 
        /// </summary>
        /// <param name="sender">Object Sencder</param>
        /// <param name="e">Event Argument e</param>
        private void LoadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Text Files | *.txt";
            openFileDialog.DefaultExt = "txt";
            openFileDialog.Title = "Open File";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader openFile = new StreamReader(openFileDialog.OpenFile()))
                {
                    this.LoadText(openFile);
                }
            }
        }

        /// <summary>
        /// Name:SaveToFileToolStripMenuItem_Click
        /// Description:This saves a txt file from the textbox to the computer
        /// </summary>
        /// <param name="sender">Object Sencder</param>
        /// <param name="e">Event Argument e</param>
        private void SaveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Text Files | *.txt";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Title = "Save File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter saveFile = new StreamWriter(saveFileDialog.OpenFile()))
                {
                    saveFile.Write(this.textBox1.Text);
                }
            }
        }

        /// <summary>
        /// Name:LoadFibonacciNumbersfirst100ToolStripMenuItem_Click
        /// Description:loads fibionacci first 100 numbers
        /// </summary>
        /// <param name="sender">Object Sencder</param>
        /// <param name="e">Event Argument e</param>
        private void LoadFibonacciNumbersfirst100ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fibonacci newFib = new Fibonacci(100);
            this.LoadText(newFib);
        }

        /// <summary>
        /// Name:loadFibinachiToolStripMenuItem_Click
        /// Description:loads fibionacci first 50 numbers
        /// </summary>
        /// <param name="sender"> Object Sencder </param>
        /// <param name="e">Event Argument e</param>
        private void LoadFibinachiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Fibonacci newFib = new Fibonacci(50);
            this.LoadText(newFib);
        }
    }
}
