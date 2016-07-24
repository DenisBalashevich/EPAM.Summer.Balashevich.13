using System;


namespace MatrixTask
{
    /// <summary>
    /// Visitor pattern at work
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ComputeSumVisitor<T> : IMatrixVisitor<T>
    {
        public SquareMatrix<T> Result { get; private set; }
        public void Visit(SquareMatrix<T> first, SquareMatrix<T> second)
        {
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                throw new ArgumentNullException();
            if (first.Dimention != second.Dimention)
                throw new ArgumentException();
            Result = new SquareMatrix<T>(second.Dimention);
            for (var i = 0; i < first.Dimention; i++)
            {
                for (var j = 0; j < second.Dimention; j++)
                    Result[i + 1, j + 1] = (dynamic)first[i + 1, j + 1] + (dynamic)second[i + 1, j + 1];
            }
        }
    }
}
