using System;
using System.Linq.Expressions;


namespace MatrixTask
{
    /// <summary>
    /// Visitor pattern at work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ComputeSumVisitor<T> : IMatrixVisitor<T>
    {
        public SquareMatrixAbstract<T> Result { get; private set; }
        public void Visit(SquareMatrixAbstract<T> first, SquareMatrixAbstract<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                throw new ArgumentNullException();
            if (first.Dimention != second.Dimention)
                throw new ArgumentException();
            Result = new SquareMatrix<T>(second.Dimention);
            for (var i = 0; i < first.Dimention; i++)
            {
                for (var j = 0; j < second.Dimention; j++)
                {
                    try
                    {
                        Result[i + 1, j + 1] = (T) ((dynamic) first[i + 1, j + 1] + second[i + 1, j + 1]);
                    }
                    catch (Exception)
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }
    }
}

