namespace _04_CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        public static void Main()
        {
            string filePath = @"..\00_Resources\copyMe.png";
            string filePathCopy = @"..\00_OutputFiles\copyMe-copy.png";

            using (var reader = new FileStream(filePath, FileMode.Open))
            {
                using (var writer = new FileStream(filePathCopy, FileMode.Create))
                {
                    byte[] readerBuffer = new byte[4096];

                    int readedBytes;
                    while ((readedBytes = reader.Read(readerBuffer, 0, readerBuffer.Length)) > 0)
                    {
                        writer.Write(readerBuffer, 0, readedBytes);
                    }
                }
            }
        }
    }
}
