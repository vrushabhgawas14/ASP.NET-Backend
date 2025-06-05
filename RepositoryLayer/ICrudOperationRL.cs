using ReactApp.CommonLayer.Models;

namespace ReactApp.RepositoryLayer
{
    public interface ICrudOperationRL
    {
        public Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request);

        public Task<ReadRecordResponse> ReadRecord();

        public Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request);
    }
}
