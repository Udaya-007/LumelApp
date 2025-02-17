using LumelApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LumelApp.Services
{
    public class StatsService : IStatsService
    {
        private readonly LumelDbContext _context;

        public StatsService(LumelDbContext context)
        {
            _context = context;
        }

        public async Task<long> GetTotalNoOfCutomersWithinDate(DateTime fromDate, DateTime toDate)
        {
            var orders = await (from o in _context.Orders
                                where o.DateOfSale >= fromDate && o.DateOfSale <= toDate
                                select o.CustomerId).Distinct().CountAsync();

            return orders;
        }

        public async Task<long> GetTotalNoOfOrdersWithinDate(DateTime fromDate, DateTime toDate)
        {
            var orders = await (from o in _context.Orders
                                where o.DateOfSale >= fromDate && o.DateOfSale <= toDate
                                select o).CountAsync();

            return orders;
        }

        public async Task<double> GetAvgOrderValueWithinDate(DateTime fromDate, DateTime toDate)
        {
            var orders = await (from o in _context.Orders
                                where o.DateOfSale >= fromDate && o.DateOfSale <= toDate
                                select o.Value).AverageAsync();

            return orders;
        }
    }
}
