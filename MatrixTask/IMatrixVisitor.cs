using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    /// <summary>
    /// Methods for visitor
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMatrixVisitor<T>
    {
        void Visit(SquareMatrixAbstract<T> first, SquareMatrixAbstract<T> second);
    }
}
