using HoliDays.Models;

namespace Domain.Repository
{
    public interface IHoliDays
    {
        Task<Festivo[]> GetHolyDaysAsync(int year);
        Task<bool> IsHolyDay(DateTime date);

    }
}
