using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTtTrain
{
    public class LogAnalyzer
    {
        public bool WasLastFileNameValid { get; set; }

        public bool IsValidFileExt(string fileName)
        {
            WasLastFileNameValid = false;
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(
                    "File name has to be provided");
            }

            if (!fileName.EndsWith(".SLF", StringComparison.CurrentCultureIgnoreCase))
            {
                return false;
            }
            WasLastFileNameValid = true;
            return true;
        }
    }
}
