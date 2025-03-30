using System;
using System.Linq;

[ProblemId(8), ProblemTitle("Largest Product in a Series")]
public class Problem8 : Problem
{
    private const int NUMBER_OF_ADJACENT_DIGITS_TO_MULTIPLY = 13;

    protected override string Solve(string input)
    {
        long biggestProduct = 0;
        var legitSequences = input.Split('0').Where(x => x.Length >= NUMBER_OF_ADJACENT_DIGITS_TO_MULTIPLY);
        foreach (var uninterruptedSequence in legitSequences)
        {
            for (int i = 0; i <= uninterruptedSequence.Length - NUMBER_OF_ADJACENT_DIGITS_TO_MULTIPLY; i++)
            {
                long sequenceProduct = 1;
                for (int j = 0; j < NUMBER_OF_ADJACENT_DIGITS_TO_MULTIPLY; j++)
                {
                    sequenceProduct *= int.Parse($"{uninterruptedSequence[j+i]}");
                }

                if (sequenceProduct > biggestProduct)
                {
                    biggestProduct = sequenceProduct;
                }
            }
        }
        return biggestProduct.ToString();
    }
}