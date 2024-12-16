namespace Calculator_DLL_ForTest;

public class Class1
{
    public int Add(int a, int b)
    {return a + b;}

    public int Sub(int a, int b)
    {
        if (a < b)
        throw new ArgumentException($"{a} is  <  than {b}");

        return a - b;
    }
}
