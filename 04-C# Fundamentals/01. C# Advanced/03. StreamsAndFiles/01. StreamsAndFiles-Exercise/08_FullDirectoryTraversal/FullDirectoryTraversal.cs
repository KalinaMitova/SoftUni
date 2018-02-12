namespace _08_FullDirectoryTraversal
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            string desktop = Environment
                            .GetFolderPath(Environment.SpecialFolder.Desktop);

            string filePath = Console.ReadLine();

            List<FileInfo> files = new List<FileInfo>();
            
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(filePath);

            while (subFolders.Count() != 0)
            {
                string currentPath = subFolders.Dequeue();

                // Get files from current directory
                DirectoryInfo directory = new DirectoryInfo(currentPath);
                files.AddRange(directory.GetFiles());

                // Get subfolders from current directory
                foreach (string directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }
            }

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
