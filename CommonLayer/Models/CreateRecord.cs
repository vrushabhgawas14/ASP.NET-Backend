using Microsoft.VisualBasic;
using System.Numerics;

namespace ReactApp.CommonLayer.Models
{
    public class CreateRecordRequest
    {
        public string IrmFromDate {  get; set; }

        public string IrmToDate { get; set; }

        public long IrmNumber { get; set; }

        public long IecCode { get; set; }

    }

    public class CreateRecordResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
