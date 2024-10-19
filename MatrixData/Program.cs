using System.Security.Cryptography.X509Certificates;

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
        Array.Copy(other.matrix, matrix, other.matrix.Length);
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
                matrix[i, j] = jaggedArray[i][j];
            }
        }
    }
    MyMatrix(string[] rows)
    {
        int rowsLength = rows.Length;
        string[][] splitRows = new string[rowsLength][];
        int colLength = 0;
        for (int i = 0; i < rowsLength; i++)
        {
            splitRows[i] = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            if (i == 0) colLength = splitRows[i].Length;
        }
        matrix = new double[rowsLength, colLength];
        for (int i = 0; i < rowsLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                matrix[i, j] = Convert.ToDouble(splitRows[i][j]);
            }
        }
    }
    MyMatrix(string matrixSt)
    {
        string[] rows = matrixSt.Split(new[] { '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        var parsedRows = new List<string[]>();
        foreach (string row in rows)
        {
            parsedRows.Add(row.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries));
        }
        int rowLength = parsedRows.Count;
        int colLength = parsedRows[0].Length;
        matrix = new double[rowLength, colLength];
        for (int i = 0; i < rowLength; i++)
        {
            for (int j = 0; j < colLength; j++)
            {
                matrix[i, j] = double.Parse(parsedRows[i][j]);
            }
        }
    }
    int getHeight() => Height;
    int getWidth() => Width;
    public double this[int row, int col]
    {
        get => matrix[row, col];
        set => matrix[row, col] = value;
    }
    double GetElement(int row, int col) => matrix[row, col];
    double SetElement(int row, int col, double value) => matrix[row, col] = value;
    public override string ToString()
    {
        var result = new System.Text.StringBuilder();
        for (int i = 0; i < Height; i++)
        {
            for (int j = 0; j < Width; j++)
            {
                result.Append(matrix[i, j] + "\t");
            }
            result.AppendLine();
        }
        return result.ToString();

    }
}