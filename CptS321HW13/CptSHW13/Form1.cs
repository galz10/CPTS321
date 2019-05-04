// <copyright file="form1.cs" company="Gal Zahavi">
// Copyright (c) Gal Zahavi. All rights reserved.
// </copyright>
namespace Gal_Zahavi_11573719_CptSHW13
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;
    using System.Windows.Forms;

    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]

    /// <summary>
    /// form 1
    /// </summary>
    public partial class Form1 : Form
    {
        private List<COG> cog = new List<COG>();
        private List<Planets> planets = new List<Planets>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();
            numericUpDown1.Value = 100;
            timer1.Enabled = true;
            CenterButton.Checked = true;
        }

        /// <summary>
        /// Name:pictureBox1_Click
        /// Description: a place for all the functionalities of the picture box
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event arugment</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs clicks = e as MouseEventArgs;
            Point point = new Point(clicks.X, clicks.Y);
            Planets createdPlanet = new Planets(point);
            Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics planet = Graphics.FromImage(bitmap);
            Graphics circle = Graphics.FromImage(bitmap);

            if (createButton.Checked)
            {
                COG gravity = new COG();
                double dist = 100000.00;
                bool val = false;

                foreach (COG grav in this.cog)
                {
                    var determinedDistance = Math.Sqrt(Math.Pow(point.X - grav.Location.X, 2) + Math.Pow(point.Y - grav.Location.Y, 2));
                    var distances = Math.Abs(determinedDistance);

                    if (grav.Radius + 1 > distances)
                    {
                        val = true;
                        if (!(dist < distances))
                        {
                            dist = distances;
                            gravity.Location = grav.Location;
                            gravity.Radius = grav.Radius;
                        }
                    }
                }

                if (val != true)
                {
                    MessageBox.Show("Place planet in a center of gravity zone");
                }
                else
                {
                    createdPlanet.evaluateCOG(gravity);
                    this.planets.Add(createdPlanet);

                    foreach (Planets plan in this.planets)
                    {
                        planet.FillEllipse(new SolidBrush(Color.Red), plan.PlanetLocation.X - 5, plan.PlanetLocation.Y - 5, 15, 15);

                        foreach (COG center in this.cog)
                        {
                            planet.FillEllipse(new SolidBrush(Color.LightGray), center.Location.X - center.Radius, center.Location.Y - center.Radius, center.Radius * 2, center.Radius * 2);
                            planet.FillEllipse(new SolidBrush(Color.Black), center.Location.X, center.Location.Y, 5, 5);
                        }
                    }

                    pictureBox1.Image = bitmap;
                }
            }
            else if (CenterButton.Checked)
            {
                COG newGravity = new COG(point, (int)numericUpDown1.Value);
                this.cog.Add(newGravity);

                foreach (Planets pt in this.planets)
                {
                    circle.FillEllipse(new SolidBrush(Color.Red), pt.PlanetLocation.X, pt.PlanetLocation.Y, 15, 15);

                    foreach (COG center in this.cog)
                    {
                        circle.FillEllipse(new SolidBrush(Color.Black), center.Location.X - 3, center.Location.Y - 3, 5, 5);
                        circle.FillEllipse(new SolidBrush(Color.LightGray), center.Location.X - center.Radius, center.Location.Y - center.Radius, center.Radius * 2, center.Radius * 2);
                    }
                }

                pictureBox1.Image = bitmap;
            }
            else if (CenterButton.Checked == false && createButton.Checked == false)
            {
                MessageBox.Show("Select an option: create a center of gravity or create a planet.");
            }
            else
            {
                MessageBox.Show("Error!!!");
            }
        }

        /// <summary>
        /// Name:Form1_load
        /// Description:loads form1
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void Form1_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Name:timer1_tick
        /// Description:animates the planet , going around the gravity
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">event argument</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics graphics = Graphics.FromImage(bitmap);

            foreach (Planets planet in this.planets)
            {
                planet.rotate();
            }

            foreach (COG center in this.cog)
            { 
                graphics.FillEllipse(new SolidBrush(Color.LightGray), center.Location.X - center.Radius, center.Location.Y - center.Radius, center.Radius * 2, center.Radius * 2);
                graphics.FillEllipse(new SolidBrush(Color.Black), center.Location.X - 3, center.Location.Y - 3, 6, 6);
            }

            foreach (Planets planet in this.planets)
            {
                graphics.FillEllipse(new SolidBrush(Color.Red), planet.PlanetLocation.X - 5, planet.PlanetLocation.Y - 5, 10, 10);
            }

            pictureBox1.Image = bitmap;
        }
    }
}