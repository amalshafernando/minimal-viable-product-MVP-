using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Dapper;

namespace PensionAmountWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionController : ControllerBase
    {
        private readonly string connectionString = "Data Source=SL-INF-L7NJ-IMA\\SQLEXPRESS;Initial Catalog=PensionAmountDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET All Pension details
        // GET: api/<PensionAmountController>
        [HttpGet]
        public async Task<IEnumerable<Models.Pension>> GetPensions()
        {
            IEnumerable<Models.Pension> pensions;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From PensionAmount";
                pensions = await connection.QueryAsync<Models.Pension>(sqlQuery);
            }
            return pensions;
        }
            
        /// Get pension amount by ID
        [HttpGet("{id}")]
        public async Task<Models.Pension> GetPensionById(int id)
        {
             Models.Pension pension = new Models.Pension();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From PensionAmount Where ID=@Id";
                pension = await connection.QuerySingleAsync<Models.Pension>(sqlQuery, new { Id = id });
            }
                return pension;
        }
    }
}
