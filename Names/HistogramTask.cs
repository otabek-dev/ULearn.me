namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var xLabels = new string[31];
            var yValues = new double[31];

            for (int i = 0; i < xLabels.Length; i++)
                xLabels[i] = (i + 1).ToString();

            foreach(var n in names)
                yValues[n.BirthDate.Day - 1] += 1;

            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                xLabels,
                yValues);
        }
    }
}