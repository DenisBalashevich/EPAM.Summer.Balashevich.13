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
    public class SquareMatrix<T> : Matrix<T>, IEnumerable<T>
    {
        private readonly T[,] coefficients;
        public int Dimention { get; } = 0;

        public event EventHandler<MatrixChangeEventArgs> ChangeElement = delegate { };

        public SquareMatrix() : this(new T[1, 1]) { }

        public SquareMatrix(int n) : this(new T[n, n]) { }

        public SquareMatrix(T[,] matrix)
        {
            if (ReferenceEquals(matrix, null))
                throw new ArgumentNullException();
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException();
            Dimention = matrix.GetLength(0);
            coefficients = matrix;
        }

        /// <summary>
        /// override indexator
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public override T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > Dimention + 1 || j > Dimention + 1)
                    throw new ArgumentException();
                return coefficients[i - 1, j - 1];
            }
            set
            {
                if (i < 0 || j < 0 || i > Dimention + 1 || j > Dimention + 1)
                    throw new ArgumentException();
                coefficients[i - 1, j - 1] = value;
                OnNewMail(new MatrixChangeEventArgs(string.Format("element i={0}, j={1}, was changed to {2}", i, j, value)));
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var a in coefficients)
            {
                yield return a;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Show matrixe
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (ReferenceEquals(coefficients, null))
                throw new ArgumentNullException();

            var result = new StringBuilder();
            for (var i = 0; i < coefficients.GetLength(0); i++)
            {
                for (var j = 0; j < coefficients.GetLength(0); j++)
                {
                    if (ReferenceEquals(coefficients[i, j], null))
                        result.Append("NaN ");
                    result.Append(coefficients[i, j] + " ");
                }
                result.Append("\n");
            }
            return result.ToString();
        }

        protected virtual void OnNewMail(MatrixChangeEventArgs e)
        {
            EventHandler<MatrixChangeEventArgs> temp = ChangeElement;

            if (temp != null)
            {
                temp(this, e);
            }
        }

    }
}
