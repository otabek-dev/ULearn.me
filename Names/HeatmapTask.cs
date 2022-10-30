namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var xLabels = new string[30];
            var yLabels = new string[12];
            var heat = new double[30,12];

            for (int i = 0; i < xLabels.Length; i++)
                xLabels[i] = (i+2).ToString();

            for (int i = 0; i < yLabels.Length; i++)
                yLabels[i] = (i+1).ToString();

            foreach (var name in names)
                if (!(name.BirthDate.Day == 1))
                    heat[name.BirthDate.Day - 2, name.BirthDate.Month - 1] += 1;

            return new HeatmapData(
                "Пример карты интенсивностей",
                heat, 
                xLabels, 
                yLabels);
        }
    }
}