using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Internal;

public class EntryPoint
{
    public static string InputFilePath => Path.Join(AppDomain.CurrentDomain.BaseDirectory, "data", "input.txt");
    public static string OutputFilePath => Path.Join(AppDomain.CurrentDomain.BaseDirectory, "data", "output.txt");

    static void Main(string[] args)
    {
        Problem problem;
        if (args.Length == 0)
        {
            var latestProblem = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsDefined(typeof(ProblemIdAttribute))).OrderByDescending(x => ((ProblemIdAttribute)Attribute.GetCustomAttribute(x, typeof(ProblemIdAttribute))).ProblemId).First();
            problem = (Problem)Activator.CreateInstance(latestProblem);
        }
        else
        {
            var idArg = args.SkipWhile(x => x != "--id")?.Skip(1)?.FirstOrDefault();
            if (idArg == null) return;

            var requestedId = int.Parse(idArg);
            var requestedProblem = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsDefined(typeof(ProblemIdAttribute)) && ((ProblemIdAttribute)Attribute.GetCustomAttribute(x, typeof(ProblemIdAttribute))).ProblemId == requestedId).First();
            problem = (Problem)Activator.CreateInstance(requestedProblem);
        }

        problem.Solve();
    }
}