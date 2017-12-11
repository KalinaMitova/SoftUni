namespace Stations.DataProcessor.Dto.Export
{
    using System;

    public class JsonTrainDto
    {
        public string TrainNumber { get; set; }

        public int DelayedTimes { get; set; }

        public TimeSpan? MaxDelayedTime { get; set; }
    }
}
