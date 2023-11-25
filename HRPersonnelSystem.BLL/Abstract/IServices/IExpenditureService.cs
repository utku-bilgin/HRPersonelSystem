using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.ExpenditureDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface IExpenditureService
    {
        Task<List<Expenditure>> GetAllExpenditureAsync();
        Task<Expenditure> GetExpenditureAsync(Guid id);
        Task<Expenditure> DeleteExpenditureAsync(Guid id);
        Task<Expenditure> CreateExpenditureAsync(EmployeeExpenditureDTO createExpenditureDTO);
        Task<Expenditure> UpdateExpenditureAsync(EmployeeExpenditureDTO updateExpenditureDTO);
    }
}
