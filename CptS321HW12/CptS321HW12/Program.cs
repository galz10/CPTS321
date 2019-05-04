namespace Gal_Zahavi_11573719_CptS321HW12
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
