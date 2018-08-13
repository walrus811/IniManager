using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ray
{
    public class IniManager
    {
        private Dictionary<string, string> data;
        private char commentChar;
        private string lastExceptionLog;

        public string IniPath { get; set; }
        public string LastExceptionLog { get { return lastExceptionLog; } }
        public char CommentChar { get { return commentChar; } }
        public Dictionary<string, string> Data{ get { return data; } }


        public IniManager(string iniPath, char commentCharacter='#')
        {
            IniPath = iniPath;
            data = new Dictionary<string, string>();
            commentChar = commentCharacter;
        }

        public bool Read()
        {
            bool result = false;

            try
            {
                List<string> lines = System.IO.File.ReadAllLines(IniPath).ToList();
                lines.RemoveAll(l => string.IsNullOrEmpty(l) || l.Trim()[0] == commentChar);

                foreach(var line in lines)
                {
                    int sepIndex = line.IndexOf('=');
                    string key = line.Substring(0, sepIndex).Trim();
                    string value = line.Substring(sepIndex + 1).Trim();
                    data.Add(key, value);
                }

                result = true;
            }
            catch(Exception ex)
            {
                lastExceptionLog = ex.Message + "\r\n" + ex.StackTrace;
            }

            return result;
        }

        public bool Write(Dictionary<string, string> data)
        {
            bool result = false;

            try
            {
                string dataResult = "";
                foreach (var line in data)
                {
                    dataResult += KeyValuePairToString(line)+Environment.NewLine;
                }
                System.IO.File.WriteAllText(IniPath, dataResult);

                result = true;
            }
            catch (Exception ex)
            {
                lastExceptionLog = ex.Message + "\r\n" + ex.StackTrace;
            }

            return result;
        }


        private string KeyValuePairToString(KeyValuePair<string,string> pair)
        {
            return pair.Key + " = " + pair.Value;
        }

        public override string ToString()
        {
            return IniPath;
        }
    }
}
