using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    /// <summary>
    /// Diagonal Matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix() : this(new T[1, 1]) { }

        public DiagonalMatrix(T[,] matrix) : base(matrix)
        {
            if (!IsDiagonal(matrix))
                throw new ArithmeticException();
        }

        public DiagonalMatrix(T[] diagonalCoefficients) : this(new T[diagonalCoefficients.Length, diagonalCoefficients.Length])
        {
            if (ReferenceEquals(diagonalCoefficients, null))
                throw new ArgumentNullException();
            for (int i = 0; i < Dimention; i++)
                this[i, i] = diagonalCoefficients[i];
        }

        private bool IsDiagonal(T[,] coefficients)
        {
            for (int i = 0; i < coefficients.GetLength(0); i++)
                for (int j = i + 1; j < coefficients.GetLength(1); j++)
                    if (!Equals(coefficients[i, j], default(T)))
                        return false;
            return true;
        }
    }
}
