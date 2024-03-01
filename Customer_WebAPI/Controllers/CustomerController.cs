using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Customer_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly string connectionString = "Data Source=SL-INF-L7NJ-IMA\\SQLEXPRESS;Initial Catalog=CustomerDb;Integrated Security=True;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        // GET All cutomers in Db
        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IEnumerable<Models.Customer>> GetCustomers()
        {
            IEnumerable<Models.Customer> customers;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Select * From Customer";
                customers = await connection.QueryAsync<Models.Customer>(sqlQuery);
            }
            return customers;
        }

        // GET single customer details using Id
        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<Models.Customer> GetCustomerById(int id)
        {
            Models.Customer customer = new Models.Customer();
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await  connection.OpenAsync();
                var sqlQuery = "Select * From Customer Where ID=@Id";
                customer = await connection.QuerySingleAsync<Models.Customer>(sqlQuery, new { Id = id});
            }
            return customer;
        }

        // Add new customer
        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Models.Customer customer)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Insert Into Customer (Name, Phone, Email,Password) Values(@Name, @Phone, @Email, @Password)";
                await connection.ExecuteAsync(sqlQuery, customer);
            }
            return Ok("!!! Wellcome To Our Organization !!! ");
        }

        // Update cutomer details
        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Models.Customer customer)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Update Customer SET  Phone= @Phone, Password =@Password Where Id = @Id";
                await connection.ExecuteAsync(sqlQuery, customer);
            }
            return Ok("Successfully changed your password !!! ");
        }

        // Delete customers
        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var sqlQuery = "Delete Customer Where Id = @Id";
                await connection.ExecuteAsync(sqlQuery, new { Id = id });
            }
            return Ok("Successfully deleted your account !!! ");
        }
    }
}
