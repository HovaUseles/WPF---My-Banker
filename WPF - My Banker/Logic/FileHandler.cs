using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace WPF___My_Banker
{
    internal class FileHandler
    {
        /// <summary>
        /// Path to look for files
        /// </summary>
        private string filePath;
        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        private Random random;
        public FileHandler(string path)
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + path;
            random = new Random();
        }

        public string[] GetFirstNames()
        {
            return File.ReadAllLines(FilePath + "FirstNames.txt");
        }

        public string[] GetLastNames()
        {
            return File.ReadAllLines(FilePath + "LastNames.txt");
        }

        public string GetRandomFirstName()
        {
            string[] fNames = GetFirstNames();
            return fNames[random.Next(fNames.Length)];       
        }

        public string GetRandomLastName()
        {
            string[] lNames = GetLastNames();              
            return lNames[random.Next(lNames.Length)];
        }
    }
}
