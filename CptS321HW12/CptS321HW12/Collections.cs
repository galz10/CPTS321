// <copyright file="Collections.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptS321HW12
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// collections class
    /// </summary>
    public class Collections
    {
        /// <summary>
        /// List of ints
        /// </summary>
        public List<int>[] List = new List<int>[1000000];

        /// <summary>
        /// strings of download and downloaded
        /// </summary>
        private string download, downloaded;

        /// <summary>
        /// Initializes a new instance of the <see cref="Collections"/> class.
        /// </summary>
        public Collections()
        {
            this.download = string.Empty;
        }

        /// <summary>
        /// Gets or sets the download value
        /// </summary>
        public string Download
        {
            get
            {
                return this.download;
            }

            set
            {
                if (this.download == value)
                {
                    return;
                }
                else
                {
                    this.download = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the downloaded value
        /// </summary>
        public string Downloaded
        {
            get
            {
                return this.downloaded;
            }

            set
            {
                if (this.downloaded == value)
                {
                    return;
                }
                else
                {
                    this.downloaded = value;
                }
            }
        }

        /// <summary>
        /// Name:RandomList
        /// Description: generates random list
        /// </summary>
        /// <returns>returns a random list</returns>
        private List<int> RandomList()
        {
            Random rand = new Random();
            List<int> list = new List<int>();

            for (int i = 0; i < 1000000; i++)
            {
                list.Add(rand.Next());
            }

            return list;
        }

        /// <summary>
        /// Name:Randomize
        /// Description: generates 8 lists
        /// </summary>
        public void Randomize()
        {
            for (int i = 1; i < 9; i++)
            {
                this.List[i] = this.RandomList();
            }
        }
    }
}
