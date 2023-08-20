using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        IFindexService _findexService;
        public RentalsController(IRentalService rentalService, IFindexService findexService)
        {
            _rentalService = rentalService;
            _findexService = findexService;
        }

        [HttpPost("add")]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalService.Add(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalService.Update(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalService.Delete(rental);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetById(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAll();

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


        [HttpPost("rulesforadding")]
        public IActionResult RulesForAdding(Rental rental)
        {
            var result = _findexService.GetCustomerFindexScore(rental.CustomerId);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var endusukFindex = _findexService.GetCarMinFindexScore(rental.CarId);
            if (!endusukFindex.Success)
            {
                return BadRequest(result.Message);
            }

            if (result.Data < endusukFindex.Data)
            {
                return BadRequest(Messages.PuanYetersiz);
            }
            var sonuc = _rentalService.RulesForDateAdding(rental);

            if (sonuc.Success)
            {
                return Ok(sonuc);
            }
            return BadRequest(sonuc);
        }
    }
}
