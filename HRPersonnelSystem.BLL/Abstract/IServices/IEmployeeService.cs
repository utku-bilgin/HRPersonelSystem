using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.Employees;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
	public interface IEmployeeService
    {
        Task<Employee> GetEmployeeIsActiveAsync(Guid id);
        Task<Employee> UpdateEmployeeAsync(EmployeeUptadeDTO employeeUptadeDTO);
        Task<List<EmployeeSummaryDTO>> GetAllEmployeIsActiveAsync();
        Task<Employee> CreateEmployeeAsync(CreateEmployeeDTO createEmployeeDTO);

       
    }
}
