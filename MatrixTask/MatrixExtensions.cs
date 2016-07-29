using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    /// <summary>
    /// Extend matrix
    /// </summary>
    public static class MatrixExtensions
    {
        public static SquareMatrixAbstract<T> GetSum<T>(this SquareMatrixAbstract<T> first, SquareMatrixAbstract<T> second)
        {
            var visitor = new ComputeSumVisitor<T>();
            first.Accept(visitor, second);
            return visitor.Result;
        }
    }
}
