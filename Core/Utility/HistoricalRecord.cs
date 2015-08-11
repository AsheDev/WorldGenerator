namespace Core.Utility
{
    public class HistoricalRecord
    {
        public int Id { get; set; }
        public string Era { get; set; }
        public string Information { get; set; }

        /// <summary>
        /// This is populated at the last moment before being sent to TheAllObserver
        /// </summary>
        public ObjectDetails OriginatingDetails { get; set; }
    }
}
