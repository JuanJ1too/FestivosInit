using Application.DTO;
using Application.Service;
using HoliDays.Models;
using Microsoft.AspNetCore.Mvc;

namespace HoliDays.Controllers
{
    [ApiController]
    [Route("Api/")]
    public class DatosFestivosController : ControllerBase
    {
        private readonly FestivoService _festivoService;
        public DatosFestivosController(FestivoService festivoService) 
        {
            _festivoService = festivoService;
        }
        //Obtener los festivos por año
        [HttpGet("ObtenerFestivosPorAño/{year}")]
        public async Task<IActionResult> GetHolyDaysAsync(int year)
        {
            LinkedList<FestivoDTO> holidayList = await _festivoService.GetHolyDaysAsync(year);
            if (holidayList == null || holidayList.Count <= 0)
            {
                return NotFound();
            }
            return Ok(holidayList);
        }
        //Obtener festivo por fecha
        [HttpGet("FestivoPorFecha/{date}")]
        public async Task<IActionResult> IsHolyDay(DateTime date)
        {
            bool isHoliday = await _festivoService.IsHolyDay(date);
            if (isHoliday) 
            {
                return Ok(new {response = "Es festivo :p!" });
            }
            else 
            {
                return Ok(new {response = "No es festivo :(" });
            }
        }
    }
}
