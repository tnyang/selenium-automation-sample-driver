using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Configuration;
using System.IO;

namespace Ams.Acceptance.Testing.CreateTestData
{
    public class FileHelper
    {
        private string sourceDir = ConfigurationManager.AppSettings["filePath"];
        
        public void writeToFile(string fileName, string text)
        {
            string path = sourceDir + "/" + fileName;
            string[] txtList = Directory.GetFiles(sourceDir, "*.txt");

            //delete the file if already exist
            if (File.Exists(path))
            {
                foreach (string f in txtList)
                {
                    if (Path.GetFileName(f) == fileName) File.Delete(f);
                }

            }

            //write to a file
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(text);
            }
        }

        public string readFromFile(string fileName)
        {
            return File.ReadAllText(sourceDir + "/" + fileName).Replace("\r\n","");
        }
    }
}
