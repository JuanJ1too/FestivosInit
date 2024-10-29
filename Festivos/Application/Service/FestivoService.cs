
using Application.DTO;
using Domain.Repository;

namespace Application.Service
{
    public class FestivoService
    {
        private readonly IHoliDays _holiDayRepository;
        public FestivoService(IHoliDays holiDayRepository)
        {
            _holiDayRepository = holiDayRepository;
        }

        public async Task<LinkedList<FestivoDTO>> GetHolyDaysAsync(int year)
        {
            var holidayList = await _holiDayRepository.GetHolyDaysAsync(year);
            LinkedList<FestivoDTO> holidayDTOList = new LinkedList<FestivoDTO>();
            foreach(var holiday in holidayList)
            {
                var holidayDTO = new FestivoDTO 
                {
                    Id = holiday.Id,
                    Nombre = holiday.Nombre,
                    Dia = holiday.Dia,
                    Mes = holiday.Mes,
                    IdTipo = holiday.IdTipo,    
                };
                holidayDTOList.AddLast(holidayDTO);
            }
            return holidayDTOList;
        }

        public async Task<bool> IsHolyDay(DateTime date)
        {
            return await _holiDayRepository.IsHolyDay(date);
        }
    }
}
