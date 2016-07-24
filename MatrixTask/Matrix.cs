using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTask
{
    /// <summary>
    /// Parent of all kind of matrices
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Matrix<T>
    {
        public abstract T this[int i, int j] { get; set; }

        public virtual void Accept(IMatrixVisitor<T> visitor, Matrix<T> second)
        {
            visitor.Visit((dynamic)this, (dynamic)second);
        }

    }
}

