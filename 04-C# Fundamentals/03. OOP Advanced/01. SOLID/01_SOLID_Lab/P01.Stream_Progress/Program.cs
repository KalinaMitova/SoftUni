using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            var progressInfo = new StreamProgressInfo(new File("Ime", 101, 1000));
            var progressInfo2 = new StreamProgressInfo(new Music("lili ivanova", "vetrove", 30, 3000));
        }
    }
}
