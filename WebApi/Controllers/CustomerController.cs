using Microsoft.AspNetCore.Mvc;
using Domain.Dto;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private CustomerService _customerService;
    public CustomerController()
    {
        _customerService = new CustomerService();
    }
    [HttpGet("GetStudents")]
    public List<CustomerDto> GetCustomers(int a)
    {
        return _customerService.GetCustomers();
    }
    [HttpPost("Add")]
    public int AddCustomer(string firstname, string lastname, string email)
    {
        return _customerService.Add(firstname, lastname, email);
    }
}
