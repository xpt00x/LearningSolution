using Practice.DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Practice.DataAccess.Repositories
{
    public class CalculatorRepository : ICalculatorRepository
    {
        private readonly string _spName = "sp_insertlogintodb";
        private readonly string _connectionString;
        public CalculatorRepository(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("ExampleDb") ?? string.Empty;
        }
        public void InsertLogInDb(int a, int b, string operation, int result)
        {
            //criar a connection à db
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                using (var sqlCommand = new SqlCommand(_spName, conn)
                            { CommandType = CommandType.StoredProcedure })
                {
                    //correr o sql à campeao (numa transaction)
                    sqlCommand.Parameters.Add(new SqlParameter("a", a));
                    sqlCommand.Parameters.Add(new SqlParameter("b", b));
                    sqlCommand.Parameters.Add(new SqlParameter("operation", operation));
                    sqlCommand.Parameters.Add(new SqlParameter("result", result));
                    sqlCommand.Parameters.Add(new SqlParameter("createdAt", DateTime.UtcNow));

                    sqlCommand.ExecuteNonQuery();

                }
                conn.Close();
                //fechar a connection à db
            }


        }
    }

    public class Calculation
    {
        public int Id { get; set; }
        public string FirstNumber{ get; set; }
        public string SecondNumber { get; set; }
            

    }

    
}
