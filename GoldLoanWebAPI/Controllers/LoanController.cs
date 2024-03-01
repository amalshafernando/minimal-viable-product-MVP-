using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;

namespace GoldLoanWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly string connectionString = "Data Source=SL-INF-L7NJ-IMA\\SQLEXPRESS;Initial Catalog=GoldLoanDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET: api/<LoanController>
        //Get All Loan details
        [HttpGet]
        public async Task<IEnumerable<Models.Loan>> GetLoans()
        {
            IEnumerable<Models.Loan> loans;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From Loan";
                loans = await connection.QueryAsync<Models.Loan>(sqlQuery);
            }
            return loans;
        }

        /// Get loan details by ID 
        [HttpGet("{id}")]
        public async Task<Models.Loan> GetLoanById(int id)
        {
            Models.Loan loan = new Models.Loan();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From Loan Where ID=@Id";
                loan = await connection.QuerySingleAsync<Models.Loan>(sqlQuery, new { Id = id });
            }
            return loan;
        }
       
        /// Add loan details
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Loan loan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Insert Into Loan (Id, Name, Address, Description, Gross_Weight, Amount_Payble) Values(@Id, @Name, @Address, @Description, @Gross_Weight, @Amount_Payble)";
                await connection.ExecuteAsync(sqlQuery, loan);
            }
            return Ok("!!! Wellcome !!! ");
        }

        /// update the loan details
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Models.Loan loan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Update Loan SET Id=@Id, Name=@Name, Address=@Address, Description=@Description, Gross_Weight= @Gross_Weight,Amount_Payble = @Amount_Payble ";
                await connection.ExecuteAsync(sqlQuery, loan);
            }
            return Ok("Successfully Updated !!! ");
        }

        /// Delete the loan details with the passed ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Delete Loan Where Id = @Id";
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
            }
            return Ok("Successfully Deleted !!! ");
        }
    }
}

