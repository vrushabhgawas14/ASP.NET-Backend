using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactApp.CommonLayer.Models;
using ReactApp.ServiceLayer;

namespace ReactApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public readonly ICrudOperationSL _crudOpsSL;

        public HomeController(ICrudOperationSL crudOpsSL)
        {
            _crudOpsSL = crudOpsSL;
        }

        [HttpPost]
        [Route("CreateRecord")]

        public async Task<IActionResult> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = null;
            try
            {
                response = await _crudOpsSL.CreateRecord(request);

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpGet]
        [Route("ReadRecord")]

        public async Task<IActionResult> ReadRecord()
        {
            ReadRecordResponse response = null;
            try
            {
                response = await _crudOpsSL.ReadRecord();
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }

        [HttpDelete]
        [Route("DeleteRecord")]

        public async Task<IActionResult> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = null;
            try
            {
                response = await _crudOpsSL.DeleteRecord(request);
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }

            return Ok(response);
        }
    }
}
