using System;
using System.Collections.Generic;
using System.Text;

namespace EQuanLyNhanSu.Untilities.Exceptions
{
    public class EQuanLyNhanSuException : Exception
    {
        public EQuanLyNhanSuException()
        {
        }
        public EQuanLyNhanSuException(string message) : base(message)
        {
        }
        public EQuanLyNhanSuException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
