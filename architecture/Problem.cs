using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public abstract class Problem
{
    protected virtual async Task<string> ReadInputDataAsync()
    {
        var input = await File.ReadAllTextAsync(EntryPoint.InputFilePath);
        return input;
    }

    protected virtual async Task WriteOutputDataAsync(string data)
    {
        await File.WriteAllTextAsync(EntryPoint.OutputFilePath, data);
    }

    protected abstract string Solve(string input);

    public void Solve()
    {
        var input = Task.Run(async () => { return await ReadInputDataAsync(); }).GetAwaiter().GetResult();
        var output = Solve(input);
        WriteOutputDataAsync(output).Wait();
    }
}