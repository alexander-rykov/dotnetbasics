namespace CsvParserApp.CsvModel
{
    internal class RatingRow
    {
        public int UserId { get; set; }

        public int MovieId { get; set; }

        public float RatingValue { get; set; }

        public long Timestamp { get; set; }
    }
}
