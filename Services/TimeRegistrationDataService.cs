using BethanysPieShopHRM.BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Data;

namespace BethanysPieShopHRM.Services
{
    public class TimeRegistrationService : ITimeRegistrationService
    {
        private readonly ITimeRegistrationRepository _timeRegistrationRepository;

        public TimeRegistrationService(ITimeRegistrationRepository timeRegistrationRepository)
        {
            _timeRegistrationRepository = timeRegistrationRepository;
        }

        public async Task<List<TimeRegistration>> GetPagedTimeRegistrationsForEmployee(int employeeId, int pageSize, int start)
        {
            return await _timeRegistrationRepository.GetPagedTimeRegistrationsForEmployee(employeeId, pageSize, start);
        }

        public async Task<int> GetTimeRegistrationCountForEmployeeId(int employeeId)
        {
            return await _timeRegistrationRepository.GetTimeRegistrationCountForEmployeeId(employeeId);
        }

        public async Task<List<TimeRegistration>> GetTimeRegistrationsForEmployee(int employeeId)
        {
            return await _timeRegistrationRepository.GetTimeRegistrationsForEmployee(employeeId);
        }

    }
}
