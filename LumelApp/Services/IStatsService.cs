namespace LumelApp.Services
{
    public interface IStatsService
    {
        Task<long> GetTotalNoOfCustomersWithinDate(DateTime fromDate, DateTime toDate);
        Task<long> GetTotalNoOfOrdersWithinDate(DateTime fromDate, DateTime toDate);

        Task<double> GetAvgOrderValueWithinDate(DateTime fromDate, DateTime toDate);
    }
}
