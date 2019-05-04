// <copyright file="Form1.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW12
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Net;
    using System.Threading;
    using System.Windows.Forms;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// form 1
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/>
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// initliazies the collection
        /// </summary>
        public Collections col = new Collections();

        /// <summary>
        /// Url text 
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void URLTextBox_TextChanged(object sender, EventArgs e)
        {
            this.col.Download = URLTextBox.Text;
        }

        /// <summary>
        /// Download result text
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void DownloadResult_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// sorting text
        /// </summary>
        /// <param name="sender"object sender></param>
        /// <param name="e">event argument</param>
        private void Sorting_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// group box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Name: GoToURL
        /// Description:goes to url
        /// </summary>
        /// <param name="sender"pbject sender></param>
        /// <param name="e">event argument</param>
        private void GoToURL_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(this.DownloadString);
            thread.Start();
        }

        /// <summary>
        /// Name:SortingText
        /// Description:sorts the text
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void SortText_Click(object sender, EventArgs e)
        {
            this.col.Randomize();
            Thread sorting = new Thread(this.SortThread);
            sorting.Start();
        }

        /// <summary>
        /// Name:downloadstring
        /// Description:downloads the string
        /// </summary>
        private void DownloadString()
        {
            string String = string.Empty;
            WebClient web = new WebClient();

            if (string.IsNullOrWhiteSpace(this.col.Download) == false)
            {
                using (web)
                {
                    String = web.DownloadString(this.col.Download);
                    this.Set(String, "download");  
                }
            }
        }

        /// <summary>
        /// Name:setResults
        /// Description: sets the results
        /// </summary>
        /// <param name="text">inputed text</param>
        /// <param name="type">inputed type</param>
        public delegate void setResult(string text, string type);

        /// <summary>
        /// Name:set
        /// Description:sets the result
        /// </summary>
        /// <param name="inputedText">inputed text</param>
        /// <param name="type">inputed type</param>
        private void Set(string inputedText, string type)
        {
            if (type == "download")
            {
                if (this.DownloadResult.InvokeRequired)
                {
                    setResult down = new setResult(this.Set);
                    this.Invoke(down, new object[] { inputedText, type });
                }
                else
                {
                    this.DownloadResult.Text = inputedText;
                }
            }
            else if (type == "thread")
            {
                if (this.SortingText.InvokeRequired)
                {
                    setResult down = new setResult(this.Set);
                    this.Invoke(down, new object[] { inputedText, type });
                }
                else
                {
                    this.SortingText.Text = inputedText;
                }
            }
        }

        /// <summary>
        /// generates 8 lists
        /// </summary>
        private void Lists()
        {
            for (int i = 1; i <= 8; i++)
            {
                this.col.List[i].Sort();
            }
        }

        /// <summary>
        /// Name:list
        /// Description:generateds a different lists
        /// </summary>
        /// <param name="obj">inputed object</param>
        private void list(object obj)
        {
            List<int> l = obj as List<int>;
            l.Sort();
        }

        /// <summary>
        /// Name:Sortthread
        /// Description:sorts the thread and times the sorting
        /// </summary>
        private void SortThread()
        {
            Stopwatch timer = new Stopwatch();
            Thread sort = new Thread(this.Lists);

            timer.Start();
            sort.Start();
            timer.Stop();
            var oneThread = timer.ElapsedMilliseconds;

            timer.Reset();

            this.col.Randomize();

            Thread[] threads = new Thread[8];
            for (int i = 1; i < 8; i++)
            {
                threads[i] = new Thread(new ParameterizedThreadStart(this.list));
            }

            timer.Start();
            for (int i = 1; i < 8; i++)
            {
                threads[i].Start(this.col.List[i]);
            }

            timer.Stop();

            var multiThread = timer.ElapsedMilliseconds;
            string time = "Single Thread Time: " + oneThread + "ms     " + "Multi Thread Time: " + multiThread + "ms";
            this.Set(time, "thread");
        }

        /// <summary>
        /// loads form 1
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}