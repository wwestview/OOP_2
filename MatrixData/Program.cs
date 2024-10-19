public partial class MyMatrix
{
    protected double[,] matrix;
    public int Height
    {
        get { return matrix.GetLength(0); }
    }
    public int Width
    {
        get { return matrix.GetLength(1); }
    }
    MyMatrix(MyMatrix other)
    {
        int height = other.Height;
        int width = other.Width;
        matrix = new double[height, width];
        Array.Copy(other.matrix, matrix,other.matrix.Length);
    }
    MyMatrix(double[,] matrixTwo)
    {
        int height = matrixTwo.GetLength(0);
        int width = matrixTwo.GetLength(1);
        matrix = new double[height, width];
        Array.Copy(matrixTwo, matrix, matrixTwo.Length);
    }
    MyMatrix(double[][] jaggedArray) 
    {
        int rowCount = jaggedArray.GetLength(0);
        int colCount = jaggedArray.GetLength(1);
        matrix = new double[rowCount, colCount];
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < colCount; j++)
            {
                matrix[i,j] = jaggedArray[i][j];
            }
        }
    }
    MyMatrix(string[] rows)
    {
        int rowsLength = rows.Length;
        string[][] splitRows = new string[rowsLength][];
        int colLength = 0;

    }
}