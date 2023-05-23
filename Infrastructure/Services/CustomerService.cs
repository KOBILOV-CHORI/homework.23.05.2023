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
    public int Add()
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"insert into customers(first_name, last_name, email, phone, country_code, country_name) " +
                        $"values('Shahrom', 'Sharipov', 'shahrom@gmail.com', 909050409, 992, 'Tajikistan')";
            var result = conn.Execute(sql);
            return result;
        }
    }
    //Get list
    public List<CustomerDto> GetCustomers()
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var result = conn.Query<CustomerDto>("select first_name as FirstName, last_name as LastName, email as Email, phone as Phone, country_name as CountryName from customers");
            return result.ToList();
        }
    }
    //Get by Id 
    public CustomerDto GetCustomerById(int id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"select first_name as FirstName, last_name as LastName, email as Email, phone as Phone, country_name as CountryName from customers where customer_id = {id}";
            var result = conn.QuerySingle<CustomerDto>(sql);
            return result;
        }
    }
    //Delete by ID
    public int DeleteById(int id)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"delete from customers where customer_id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    //Update All
    public int UpdateAll(int id, string FirstName, string LastName, string Email, int phone, int code, string CountryName)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"update customers set first_name = '{FirstName}', last_name = '{LastName}', email = '{Email}', phone = {phone}, country_code = {code}, country_name = '{CountryName}' where customer_id = {id}";
            var result = conn.Execute(sql);
            return result;
        }
    }
    //Update FirstName
    public int UpdateFirstName(string NewName)
    {
        using (var conn = new NpgsqlConnection(connString))
        {
            var sql = $"update customers set first_name = '{NewName}' where customer_id = 12";
            var result = conn.Execute(sql);
            return result;
        }
    }
}
