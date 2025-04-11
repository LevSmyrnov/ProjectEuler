using System;
using System.Collections.Generic;

[ProblemId(19), ProblemTitle("Counting Sundays")]
public class Problem19 : Problem
{
    private readonly List<int> monthCodes = new() { 0, 3, 3, 6, 1, 4, 6, 2, 5, 0, 3, 5 };
    private readonly List<int> gregorianCenturyCodes = new() { 4, 2, 0, 6, 4, 2, 0 };

    protected override string Solve(string input)
    {
        var sundaysCount = 0;
        var year = 1901;
        var month = 1;
        while (year < 2001)
        {
            for (; month < 13; month++)
            {
                sundaysCount += DayOfWeek(1, month, year) == 0 ? 1 : 0;
            }

            month = 1;
            year++;
        }

        return sundaysCount.ToString();
    }

    private int DayOfWeek(int day, int month, int year)
    {
        var yearCode = (year % 100 + (year % 100) / 4) % 7;
        var leapYearCode = 
        month == 1 || month == 2 
            ? IsLeapYear(year) 
                ? -1
                : 0
            : 0;
        return (yearCode + monthCodes[month - 1] + gregorianCenturyCodes[year / 100 % 17] + day + leapYearCode) % 7;
    }

    private bool IsLeapYear(int year)
    {
        if (year % 400 == 0)
        {
            return true;
        }
        if (year % 100 == 0)
        {
            return false;
        }
        if (year % 4 == 0)
        {
            return true;
        }
        return false;
    }
}