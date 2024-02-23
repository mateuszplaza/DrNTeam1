using Initial_Consonant_Choice.Utilities;
using System.Media;
using System;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Devices;
using System.Reflection.Metadata;
using System.Speech.Recognition;

namespace Initial_Consonant_Choice
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            AudioManager testAudio = new AudioManager(@"..\..\..\..\..\audio_files");
            testAudio.PlaySound(1, 0);
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            Application.Run(new PracticeEndScreen(10));
        }
    }
}