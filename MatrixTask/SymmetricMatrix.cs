using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MatrixTask
{
    /// <summary>
    /// Symmetric Matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class SymmetricMatrix<T> : SquareMatrixAbstract<T>, IEnumerable<T>
    {
        private readonly T[] _coeff;

        public SymmetricMatrix() : this(new T[1, 1]) { }

        public SymmetricMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException();
            if (!IsSymmetric(matrix))
                throw new ArithmeticException();
            _coeff = new T[DimentionMatrix(matrix.GetLength(0))];
            InitMatrix(matrix);
            Dimention = matrix.GetLength(0);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Dimention; i++)
            {
                for (int j = 0; j < i + 1; j++)
                    yield return _coeff[DimentionMatrix(i) + j];
                for (int j = i + 1; j < Dimention; j++)
                    yield return _coeff[DimentionMatrix(j) + i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected override T GetIndex(int i, int j)
        {
            if (j > i)
                Swap(ref j, ref i);

            return _coeff[DimentionMatrix(i) + j];
        }

        protected override void SetIndex(int i, int j, T val)
        {
            if (j > i)
                Swap(ref j, ref i);

            _coeff[DimentionMatrix(i) + j] = val;
        }

        private static bool IsSymmetric(T[,] coefficients)
        {
            for (int i = 0; i < coefficients.GetLength(0); i++)
                for (int j = 0; j < coefficients.GetLength(1); j++)
                    if (!Equals(coefficients[i, j], coefficients[j, i]))
                        return false;
            return true;
        }

        private void InitMatrix(T[,] matrix)
        {
            for (int i = 0, k = 0; i < matrix.GetLength(0); i++)
                for (var j = 0; j < i + 1; j++, k++)
                    _coeff[k] = matrix[i, j];
        }

        private static int DimentionMatrix(int num)
        {
            int n = 0;
            for (var i = num; i > 0; i--)
                n += i;
            return n;
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
