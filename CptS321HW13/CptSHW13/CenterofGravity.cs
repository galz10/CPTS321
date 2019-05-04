// <copyright file="CenterofGravity.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptSHW13
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// COG class
    /// </summary>
    public class COG
    {
        /// <summary>
        /// cog location
        /// </summary>
        private Point cogLocation;

        /// <summary>
        /// radius integer
        /// </summary>
        private int radius;

        /// <summary>
        /// Initlializes a new instance of the <see cref="COG"/> class.
        /// </summary>
        public COG()
        {
        }

        /// <summary>
        /// Initlializes a new instance of the <see cref="COG"/> class.
        /// </summary>
        /// <param name="inputedLocation">inputed location</param>
        /// <param name="inputedRadius">inputed radius</param>
        public COG(Point inputedLocation, int inputedRadius)
        {
            this.cogLocation = inputedLocation;
            this.radius = inputedRadius;
        }

        /// <summary>
        /// Gets or sets location variable
        /// </summary>
        public Point Location
        {
            get
            {
                return this.cogLocation;
            }

            set
            {
                if (this.cogLocation == value)
                {
                    return;
                }
                else
                {
                    this.cogLocation = value;
                }
            }
        }

        /// <summary>
        /// Get or sets radius variable 
        /// </summary>
        public int Radius
        {
            get
            {
                return this.radius;
            }

            set
            {
                if (this.radius == value)
                {
                    return;
                }
                else
                {
                    this.radius = value;
                }
            }
        }
    }
}