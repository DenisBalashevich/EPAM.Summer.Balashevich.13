using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MatrixTask
{
    /// <summary>
    /// Square matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SquareMatrix<T> : SquareMatrixAbstract<T>, IEnumerable<T>
    {
        private readonly T[] _coeff;

        public SquareMatrix() : this(new T[1, 1]) { }

        public SquareMatrix(int n) : this(new T[n, n]) { }

        public SquareMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException();
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException();
            Dimention = matrix.GetLength(0);
            _coeff = new T[matrix.GetLength(0) * matrix.GetLength(0)];
            InitMatrix(matrix);
        }

        protected override T GetIndex(int i, int j)
        {
            return _coeff[i * Dimention + j];
        }

        protected override void SetIndex(int i, int j, T val)
        {
            _coeff[i * Dimention + j] = val;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var a in _coeff)
            {
                yield return a;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void InitMatrix(T[,] matrix)
        {
            for (int i = 0; i < Dimention; i++)
                for (int j = 0; j < Dimention; j++)
                    _coeff[i * Dimention + j] = matrix[i, j];
        }
    }
}
