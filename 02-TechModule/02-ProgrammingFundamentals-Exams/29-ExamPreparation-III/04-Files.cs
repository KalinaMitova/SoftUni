using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04_Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePathFile = new Dictionary<string, File>();

            string pattern = @"^(?<fullPath>(?<root>.+?)\\(?<folders>.+\\)(?<filename>.+)\.(?<extension>[a-z]+));(?<filesize>\d+)$";
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string file = Console.ReadLine();

                Match fileMatch = Regex.Match(file, pattern);

                if (fileMatch.Success)
                {
                    File currentFile = new File
                    {
                        FullPath = fileMatch.Groups["fullPath"].Value,
                        Root = fileMatch.Groups["root"].Value,
                        FileName = fileMatch.Groups["filename"].Value,
                        Extension = fileMatch.Groups["extension"].Value,
                        FileSizeInKB = ulong.Parse(fileMatch.Groups["filesize"].Value)
                    };
                    
                    filePathFile[currentFile.FullPath] = currentFile;
                }                
            }

            string[] query = Console.ReadLine().Split(new string[] { " in " }, StringSplitOptions.RemoveEmptyEntries);

            var extension = query[0];
            var root = query[1];

            var filteredFiles = filePathFile
                .Where(f => f.Value.Extension == extension && f.Value.Root == root)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

            if (filteredFiles.Count == 0)
            {
                Console.WriteLine("No");
                return;
            }

            foreach (var file in filteredFiles
                .OrderByDescending(f => f.Value.FileSizeInKB)
                .ThenBy(f => f.Value.FileName))
            {
                Console.WriteLine($"{file.Value.FileName}.{file.Value.Extension} - {file.Value.FileSizeInKB} KB");
            }
        }
    }

    class File
    {
        public string FullPath { get; set; }

        public string Root { get; set; }
        
        public string FileName { get; set; }

        public string Extension { get; set; }

        public ulong FileSizeInKB { get; set; }
    }
}
