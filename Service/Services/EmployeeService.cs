using AutoMapper;
using Domain.Models;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using Service.DTOs.Employee;
using Service.Helpers.Responses;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(EmployeeCreateDto request)
        {
            await _employeeRepo.CreateAsync(_mapper.Map<Employee>(request));
        }

        public async Task<BaseResponse> DeleteAsync(int? id)
        {
            try
            {
                ArgumentNullException.ThrowIfNull(id);
                var data = await _employeeRepo.GetAsync(id);
                await _employeeRepo.DeleteAsync(data);
                return new BaseResponse { IsSuccess = true, ErrorMessage = null };
            }
            catch (Exception ex)
            {
               return new BaseResponse { IsSuccess = false, ErrorMessage = ex.Message };
            }
        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            return _mapper.Map<List<EmployeeDto>>(await _employeeRepo.GetAllAsync());
        }
    }
}
