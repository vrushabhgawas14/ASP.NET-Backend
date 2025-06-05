using ReactApp.CommonLayer.Models;

namespace ReactApp.ServiceLayer
{
    public interface ICrudOperationSL
    {
        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);
        public Task<ReadRecordResponse> ReadRecord();

        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
