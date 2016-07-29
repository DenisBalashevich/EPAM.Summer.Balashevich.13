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
    public abstract class SquareMatrixAbstract<T>
    {
        public int Dimention { get; protected set; }

        public event EventHandler<MatrixChangeEventArgs> ChangeElement = delegate { };

        public virtual void Accept(IMatrixVisitor<T> visitor, SquareMatrixAbstract<T> second)
        {
            visitor.Visit((dynamic)this, (dynamic)second);
        }

        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || j < 0 || i > Dimention || j > Dimention)
                    throw new ArgumentException();
                return GetIndex(i, j);
            }
            set
            {
                if (i < 0 || j < 0 || i > Dimention || j > Dimention)
                    throw new ArgumentException();
                SetIndex(i, j, value);
                OnNewMail(new MatrixChangeEventArgs(string.Format("element i={0}, j={1}, was changed to {2}", i, j, value)));
            }
        }

        protected abstract T GetIndex(int i, int j);
        protected abstract void SetIndex(int i, int j, T val);

        protected virtual void OnNewMail(MatrixChangeEventArgs e)
        {
            EventHandler<MatrixChangeEventArgs> temp = ChangeElement;

            if (!ReferenceEquals(temp, null))
            {
                temp(this, e);
            }
        }

    }
}

