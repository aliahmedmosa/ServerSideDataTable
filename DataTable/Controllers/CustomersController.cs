using DataTable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace DataTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDBContext _Context;

        public CustomersController(ApplicationDBContext context)
        {
            _Context = context;
        }

        [HttpPost]
        public IActionResult GetCustomers()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[String.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];

            IQueryable<Customer> customers = _Context.Customers.Where(m=>string.IsNullOrEmpty(searchValue)
            ?true
            :m.FirstName.Contains(searchValue)|| m.LastName.Contains(searchValue) || m.Contact.Contains(searchValue)||m.Email.Contains(searchValue));

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
               customers= customers.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));

            var data = customers.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = customers.Count();
            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data = data };

            return Ok(jsonData);
        }
    }
}
