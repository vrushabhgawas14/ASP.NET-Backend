namespace ReactApp.CommonLayer.Models
{
    public class ReadRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<ReadRecordData> readRecordData { get; set; }
    }

    public class ReadRecordData
    {
        public int Id { get; set; }
        public string IrmFromDate { get; set; }

        public string IrmToDate { get; set; }

        public long IrmNumber { get; set; }

        public long IecCode { get; set; }
    }
}
