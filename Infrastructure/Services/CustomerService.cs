using Dapper;
using Domain.Dto;
using Npgsql;
public class CustomerService
{
    string connString = $"Server=localhost;Port=5432;User id=postgres;Database=ex_1;Password=01062007";
    public CustomerService()
    {

    }
    // Add
    public int Add(string firstname, string lastname, string email)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"insert into students(first_name, last_name, email_address) " +
                        $"values('{firstname}', '{lastname}', '{email}')";
            var result = conn.Execute(sql);
            return result;
        }
    }
    //Get list
    public List<CustomerDto> GetCustomers()
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var result = conn.Query<CustomerDto>("select first_name as FirstName, last_name as LastName, email_address as Email from students");
            return result.ToList();
        }
    }
    //Get by Id 
    public CustomerDto GetCustomerById(int id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"select first_name as FirstName, last_name as LastName, email_address as Email from students where customer_id = {id}";
            var result = conn.QuerySingle<CustomerDto>(sql);
            return result;
        }
    }
    //Delete by ID
    public int DeleteById(int id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"delete from students where student_id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    //Update All
    public int UpdateAll(int id, string FirstName, string LastName, string Email, int phone, int code, string CountryName)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"update students set first_name = '{FirstName}', last_name = '{LastName}', email_address = '{Email}' where customer_id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    //Update FirstName
    public int UpdateFirstName(string NewName, int id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"update students set first_name = '{NewName}' where student_id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
}
