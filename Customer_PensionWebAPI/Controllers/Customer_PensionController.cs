using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;


namespace Customer_PensionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customer_PensionController : ControllerBase
    {
        private readonly string connectionString = "Data Source=SL-INF-L7NJ-IMA\\SQLEXPRESS;Initial Catalog=PensionAmountDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Get All pension details
        [HttpGet]
        public async Task<IEnumerable<Models.Customer>> GetCustomers()
        {
            IEnumerable<Models.Customer> customers;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From CustomerPension";
                customers = await connection.QueryAsync<Models.Customer>(sqlQuery);
            }
            return customers;
        }

        //Get Pension details using Id
        [HttpGet("{id}")]
        public async Task<Models.Customer> GetCustomerById(int id)
        {
            Models.Customer customer = new Models.Customer();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From CustomerPension Where ID=@Id";
                customer = await connection.QuerySingleAsync<Models.Customer>(sqlQuery, new { Id = id });
            }
            return customer;
        }

        //Add new Pension details
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Insert Into CustomerPension (Id,Name,Date_Of_Birth,Account_Open_Date,Expected_Retirement_Age,Payment_Frequency,Contribution,Interested_Rate,Retirement_Benefits_Period,Retirement_Benefits_Interest) Values(@Id,@Name,@Date_Of_Birth,@Account_Open_Date,@Expected_Retirement_Age,@Payment_Frequency,@Contribution,@Interested_Rate,@Retirement_Benefits_Period,@Retirement_Benefits_Interest)";
                await connection.ExecuteAsync(sqlQuery, customer);
            }
            return Ok("!!! Your Pension Plan is cretaed successfully !!! ");
        }

        //Update Pension details using Id
       [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Models.Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Update CustomerPension SET  Id=@Id, Name=@Name,Date_Of_Birth=@Date_Of_Birth, Account_Open_Date=@Account_Open_Date, Expected_Retirement_Age=@Expected_Retirement_Age, Payment_Frequency=@Payment_Frequency, Contribution=@Contribution, Interested_Rate=@Interested_Rate, Retirement_Benefits_Period=@Retirement_Benefits_Period, Retirement_Benefits_Interest=@Retirement_Benefits_Interest";
                await connection.ExecuteAsync(sqlQuery, customer);
            }
            return Ok("Pension Plan Updated successfully !!! ");
        }

        //Delete pension details using Id
        // DELETE api/<CustomerPensionController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Delete CustomerPension Where Id = @Id";
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
            }
            return Ok("Successfully deleted your pension plan !!! ");
        }
    }
}
