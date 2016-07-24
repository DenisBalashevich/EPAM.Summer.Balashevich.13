using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    /// <summary>
    /// Data for elems change
    /// </summary>
    public sealed class MatrixChangeEventArgs : EventArgs
    {
        #region ctor

        public MatrixChangeEventArgs() { }

        public MatrixChangeEventArgs(string message)
        {
            Message = message;
        }
        #endregion
        #region properties

        public string Message { get; }
        #endregion
    }
}
