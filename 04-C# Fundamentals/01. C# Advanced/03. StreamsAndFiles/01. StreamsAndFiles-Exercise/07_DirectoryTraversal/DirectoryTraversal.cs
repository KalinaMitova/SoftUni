namespace _07_DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public class DirectoryTraversal
    {
        public static void Main()
        {
            string desktop = Environment
                .GetFolderPath(Environment.SpecialFolder.Desktop);
            
            string filePath = Console.ReadLine();

            DirectoryInfo directory = new DirectoryInfo(filePath);
            FileInfo[] files = directory.GetFiles();

            Dictionary<string, List<FileInfo>> filesByExtension = 
                new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                string extension = file.Extension;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension[extension] = new List<FileInfo>();
                }

                filesByExtension[extension].Add(file);
            }

            var orderedFiles = filesByExtension
                .OrderByDescending(ef => ef.Value.Count())
                .ThenBy(ef => ef.Key);

            using (var writer = new StreamWriter(desktop + @"\report.txt"))
            {
                foreach (var ex in orderedFiles)
                {
                    writer.WriteLine(ex.Key);
                    foreach (var file in ex.Value.OrderBy(f => f.Length))
                    {
                        double size = file.Length / 1024d;
                        writer.WriteLine($"--{file.Name} - {size:F3}kb");
                    }
                }
            }            
        }
    }
}
