using System;
using System.IO;
using System.Linq;

namespace Names
{
    public static class Program
    {
        private static readonly string dataFilePath = "names.txt";

        private static void Main(string[] args)
        {
            var namesData = ReadData();
            Charts.ShowHeatmap(HeatmapTask.GetBirthsPerDateHeatmap(namesData));
            Charts.ShowHistogram(HistogramSample.GetHistogramBirthsByYear(namesData));
            Charts.ShowHistogram(HistogramTask.GetBirthsPerDayHistogram(namesData, "юрий"));
            Charts.ShowHistogram(HistogramTask.GetBirthsPerDayHistogram(namesData, "владимир"));
            // CreativityTask.ShowYourStatistics(namesData);
            Console.WriteLine();
        }

        private static NameData[] ReadData()
        {
            return File
                .ReadLines(dataFilePath)
                .Select(NameData.ParseFrom)
                .ToArray();
        }
    }
}