// <copyright file="Planets.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptSHW13
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// planets class
    /// </summary>
    public class Planets
    {
        /// <summary>
        /// planet location
        /// </summary>
        private Point planetLocation;

        /// <summary>
        /// center of gravity
        /// </summary>
        private COG center;

        /// <summary>
        /// distance double
        /// </summary>
        private double distance;

        /// <summary>
        /// Inilializes a new instance of the <see cref="Planets"/> class.
        /// </summary>
        /// <param name="inputedPlanet">inputed Planet</param>
        public Planets(Point inputedPlanet)
        {
            this.planetLocation = inputedPlanet;
            this.distance = 10000000;
        }

        /// <summary>
        /// Gets or sets planet location
        /// </summary>
        public Point PlanetLocation
        {
            get
            {
                return this.planetLocation;
            }

            set
            {
                if (this.planetLocation == value)
                {
                    return;
                }
                else
                {
                    this.planetLocation = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets distance
        /// </summary>
        public COG Center
        {
            get
            {
                return this.center;
            }

            set
            {
                if (this.center == value)
                {
                    return;
                }
                else
                {
                    this.center = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets distance
        /// </summary>
        public double Distance
        {
            get
            {
                return this.distance;
            }

            set
            {
                if (this.distance == value)
                {
                    return;
                }
                else
                {
                    this.distance = value;
                }
            }
        }

        /// <summary>
        /// Name:evaluateCOG
        /// Description:calculates the centure of gravity for the planet
        /// </summary>
        /// <param name="inputedCOG">inputed COG</param>
        public void evaluateCOG(COG inputedCOG)
        {
            var determinedDistance = Math.Sqrt(Math.Pow(this.planetLocation.X - inputedCOG.Location.X, 2) + Math.Pow(this.planetLocation.Y - inputedCOG.Location.Y, 2));
            var distances = Math.Abs(determinedDistance);

            if (inputedCOG.Radius + 1 > distances)
            {
                if (!(distances > this.distance))
                {
                    this.distance = distances;
                    this.center = inputedCOG;
                }
            }
        }
        
        /// <summary>
        /// Name:rotate
        /// Description: rotates the planets
        /// </summary>
        public void rotate()
        {
            int x = this.planetLocation.X - this.center.Location.X;
            int y = this.planetLocation.Y - this.center.Location.Y;
            this.planetLocation.Y = (int)(this.center.Location.Y + (this.planetLocation.Y - this.center.Location.Y) * (Math.Cos(5 * Math.PI / 180)) + x * (Math.Sin(5 * Math.PI / 180)));
            this.planetLocation.X = (int)(this.center.Location.X + (this.planetLocation.X - this.center.Location.X) * (Math.Cos(5 * Math.PI / 180)) - y * (Math.Sin(5 * Math.PI / 180)));
        }
    }
}