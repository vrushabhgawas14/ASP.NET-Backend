using Microsoft.VisualBasic;
using ReactApp.CommonLayer.Models;
using System.Data.SqlClient;

namespace ReactApp.RepositoryLayer
{
    public class CrudOpsRL : ICrudOperationRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;

        public CrudOpsRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration.GetConnectionString("DbConnection"));
        }

        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Created Successfully";

            try
            {
                string sqlQuery = "INSERT INTO FormsData(IrmFromDate, IrmToDate, IrmNumber, IecCode) values (@IrmFromDate, @IrmToDate, @IrmNumber, @IecCode)";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@IrmFromDate", request.IrmFromDate);
                    sqlCommand.Parameters.AddWithValue("@IrmToDate", request.IrmToDate);
                    sqlCommand.Parameters.AddWithValue("@IrmNumber", request.IrmNumber);
                    sqlCommand.Parameters.AddWithValue("@IecCode", request.IecCode);

                    _sqlConnection.Open();

                    int Status = await sqlCommand.ExecuteNonQueryAsync();

                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong!";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }

        public async Task<ReadRecordResponse> ReadRecord()
        {
            ReadRecordResponse response = new ReadRecordResponse();
            response.IsSuccess = true;
            response.Message = "Read Successfully";

            try
            {
                string sqlQuery = "SELECT ID, IrmFromDate, IrmToDate, IrmNumber, IecCode FROM FormsData";
                using(SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    _sqlConnection.Open();
                    SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

                    if (sqlDataReader.HasRows)
                    {
                        response.readRecordData = new List<ReadRecordData>();

                        while (await sqlDataReader.ReadAsync())
                        {
                            ReadRecordData readRecordData = new ReadRecordData();
                            readRecordData.Id = sqlDataReader.GetInt32(0);
                            readRecordData.IrmFromDate = sqlDataReader.GetString(1);
                            readRecordData.IrmToDate = sqlDataReader.GetString(2);
                            readRecordData.IrmNumber = sqlDataReader.GetInt64(3);
                            readRecordData.IecCode = sqlDataReader.GetInt64(4);

                            response.readRecordData.Add(readRecordData);
                        }
                    }
                }
            }catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }

        public async Task<DeleteRecordResponse> DeleteRecord(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = new DeleteRecordResponse();
            response.IsSuccess = true;
            response.Message = "Record Deleted Successfully!";

            try
            {
                string sqlQuery = "DELETE FormsData WHERE id = @ID";
                using(SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ID", request.Id);
                    _sqlConnection.Open();

                    int Status = await sqlCommand.ExecuteNonQueryAsync();

                    if(Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something Went Wrong While Deleting";
                    }
                }
            }catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }
    }
}
