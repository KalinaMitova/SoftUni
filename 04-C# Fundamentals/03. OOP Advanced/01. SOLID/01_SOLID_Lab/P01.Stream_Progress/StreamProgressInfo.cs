using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamProgress streamProgress;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamProgress streamProgress)
        {
            this.streamProgress = streamProgress;
        }

        public int CalculateCurrentPercent()
        {
            return (this.streamProgress.BytesSent * 100) / this.streamProgress.Length;
        }
    }
}
