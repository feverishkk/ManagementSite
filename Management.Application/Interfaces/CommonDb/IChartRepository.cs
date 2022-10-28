using CommonDatabase.Models.Customers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Management.Application.Interfaces.CommonDb
{
    public interface IChartRepository
    {
        Task<double[]> GetUserClassChart();
        Task<double[]> GetUserGenderChart();
        Task<double[]> GetWhoIsTheHighPaidCash();
        Task<double[]> GetActiveUsers();
    }
}