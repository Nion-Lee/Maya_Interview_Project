using ApplicationService;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly ICrudService _crudService;

        public CrudController(ICrudService crudService)
        {
            _crudService = crudService;
        }

        [HttpGet]
        public string Test()
        {
            return "RRR";
        }

        [HttpGet]
        public async Task<IActionResult> Get(string feeNo, CancellationToken stoppingToken)
        {
            var item = await _crudService.Get(feeNo, stoppingToken);

            if (item is null)
                return NotFound();

            return Ok(item);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken stoppingToken)
        {
            var list = await _crudService.GetAll(stoppingToken);

            return Ok(list);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(FeeNoRepo dto, CancellationToken stoppingToken)
        {
            var item = await _crudService.Update(dto, stoppingToken);

            if (item is null)
                return BadRequest();

            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Create(FeeNoRepo dto, CancellationToken stoppingToken)
        {
            var item = await _crudService.Create(dto, stoppingToken);

            if (item is null)
                return BadRequest();

            return Ok(item);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string feeNo, CancellationToken stoppingToken)
        {
            var item = await _crudService.Delete(feeNo, stoppingToken);

            if (item is null)
                return BadRequest();

            return Ok(item);
        }
    }
}
