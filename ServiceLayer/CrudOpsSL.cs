using ReactApp.CommonLayer.Models;
using ReactApp.RepositoryLayer;

namespace ReactApp.ServiceLayer
{
    public class CrudOpsSL : ICrudOperationSL
    {
        public readonly ICrudOperationRL _crudOpsRL;

        public CrudOpsSL(ICrudOperationRL crudOpsRL)
        {
            _crudOpsRL = crudOpsRL;
        }

        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            return await _crudOpsRL.CreateRecord(request);
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
           return await _crudOpsRL.ReadRecord();
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            return await _crudOpsRL.DeleteRecord(request);
        }
    }
}
