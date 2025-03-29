using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Internal;

public class EntryPoint
{
    public static string InputFilePath => Path.Join(AppDomain.CurrentDomain.BaseDirectory, "data", "input.txt");
    public static string OutputFilePath => Path.Join(AppDomain.CurrentDomain.BaseDirectory, "data", "output.txt");

    static void Main(string[] args)
    {
        var problem = new SampleProblem();
        problem.Solve();
    }
}