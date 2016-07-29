using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MatrixTask
{
    /// <summary>
    /// Diagonal Matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DiagonalMatrix<T> : SquareMatrixAbstract<T>, IEnumerable<T>
    {
        private readonly T[] _coeff;

        public DiagonalMatrix() : this(new T[1, 1]) { }

        public DiagonalMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException();
            if (!IsDiagonal(matrix))
                throw new ArithmeticException();

            _coeff = new T[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
                _coeff[i] = matrix[i, i];
            Dimention = matrix.GetLength(0);
        }


        public DiagonalMatrix(T[] diagonalCoefficients)
        {
            if (ReferenceEquals(diagonalCoefficients, null))
                throw new ArgumentNullException();
            _coeff = new T[diagonalCoefficients.Length];
            diagonalCoefficients.CopyTo(_coeff, 0);
            Dimention = diagonalCoefficients.GetLength(0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Dimention; i++)
            {
                yield return _coeff[i];
                for (int j = 0; j < Dimention; j++)
                    yield return default(T);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected override T GetIndex(int i, int j)
        {
            if (j != i)
                return default(T);
            return _coeff[i];
        }

        protected override void SetIndex(int i, int j, T val)
        {
            if (j != i)
            {
                throw new ArgumentException();
            }
            _coeff[i] = val;
        }

        private static bool IsDiagonal(T[,] coefficients)
        {
            for (int i = 0; i < coefficients.GetLength(0); i++)
                for (int j = i + 1; j < coefficients.GetLength(1); j++)
                    if (!Equals(coefficients[i, j], default(T)))
                        return false;
            return true;
        }
    }
}
