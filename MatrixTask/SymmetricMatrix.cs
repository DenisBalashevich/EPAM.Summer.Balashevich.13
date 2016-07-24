using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    /// <summary>
    /// Symmetric Matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix() : this(new T[1, 1]) { }

        public SymmetricMatrix(T[,] matrix) : base(matrix)
        {
            if (!IsSymmetric(matrix))
                throw new ArithmeticException();
        }

        private bool IsSymmetric(T[,] coefficients)
        {
            for (int i = 0; i < coefficients.GetLength(0); i++)
                for (int j = 0; j < coefficients.GetLength(1); j++)
                    if (!Equals(coefficients[i, j], coefficients[j, i]))
                        return false;
            return true;
        }
    }
}
