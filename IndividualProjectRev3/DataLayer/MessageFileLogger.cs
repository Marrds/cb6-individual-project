using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IndividualProjectRev3
{
    public class MessageFileLogger
    {
        string path = @"MessageLogFile.txt";
        //Create a file if it does not exist
        public MessageFileLogger()
        {
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();

                MessageBox.Show("Created a new file at \n" + @"C:\Users\margi\OneDrive\Desktop\C#\MEGA\IndividualProjectRev3\IndividualProjectRev3\bin\Debug");

                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine("This is a Files that logs all messages! Created at  " + DateTime.Now);
                }
            }
        }
        // append the file with a message info
        public void LogAMessage(string sender, string receiver, DateTime time, string text)
        {

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(path), true))
            {
                outputFile.WriteLine(sender+" to "+receiver+" at " +time+ " Message:  "+text);
            }

        }
    }
}
