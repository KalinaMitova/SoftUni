namespace _06_ZippingSlicedFiles
{
    using System.IO;
    using System.Collections.Generic;
    using System.IO.Compression;

    public class ZippingSlicedFiles
    {
        public static void Main()
        {
            string sourceFile = @"..\00_Resources\sliceMe.mp4";
            string destinationDirectory = $@"..\00_OutputFiles\SliceZip\";
            int parts = 5;

            List<string> files = new List<string>();

            Slice(sourceFile, destinationDirectory, parts, files);

            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

            Assemble(files, destinationDirectory + "Assembled." + extension);
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts, List<string> files)
        {
            if (destinationDirectory == string.Empty)
            {
                destinationDirectory = @".\";
            }

            string extension = sourceFile.Substring(sourceFile.LastIndexOf('.') + 1);

            using (var reader = new FileStream(sourceFile, FileMode.Open))
            {
                long onePart = reader.Length / parts;
                byte[] buffer = new byte[4096];

                for (int i = 1; i <= parts; i++)
                {
                    string fullFilePath = destinationDirectory + $"part{i}." + extension + ".gz";

                    files.Add(fullFilePath);

                    using (var writer = new GZipStream(new FileStream(fullFilePath, FileMode.Create), CompressionLevel.Optimal))
                    {
                        long totalReadedBytes = 0;

                        int readedBytes;
                        while ((readedBytes = reader.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            totalReadedBytes += readedBytes;
                            writer.Write(buffer, 0, readedBytes);
                            if (totalReadedBytes >= onePart)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            byte[] buffer = new byte[4096];

            using (var writer = new FileStream(destinationDirectory, FileMode.Create))
            {
                foreach (var file in files)
                {
                    using (var reader = new GZipStream(new FileStream(file, FileMode.Open), CompressionMode.Decompress))
                    {
                        int readedBytes;
                        while ((readedBytes = reader.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            writer.Write(buffer, 0, readedBytes);
                        }
                    }
                }
            }
        }
    }
}
