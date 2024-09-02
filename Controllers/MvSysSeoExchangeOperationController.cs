using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using oracle_backend.Models;
using oracle_backend.Repository;
using oracle_backend.Repository.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace oracle_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MvSysSeoExchangeOperationController : Controller
    {
        private readonly IMvSysSeoExchangeOperationRepository _controller;
        
        public MvSysSeoExchangeOperationController(IMvSysSeoExchangeOperationRepository controller)
        {
            _controller = controller;
        }
        [HttpGet]
        public async Task<ActionResult<List<MvSysSeoExchangeOperation>>> ListarExchangeOperation()
        {
            List<MvSysSeoExchangeOperation> Lista = await _controller.ListarExchangeOperation();
            return Ok(Lista);
        }

        [HttpGet("get/{seoCompany}/{SeoSourceHost}/{SeoSourceFtpUser}/{SeoDestHost}/{SeoDestFtpUser}/{SeoOperation}")]
        public async Task<ActionResult<MvSysSeoExchangeOperation>> SearchExchangeOperation(string seoCompany, string SeoSourceHost, string SeoSourceFtpUser, string SeoDestHost, string SeoDestFtpUser, string SeoOperation)
        {
            MvSysSeoExchangeOperation Lista = await _controller.SearchExchangeOperation(seoCompany, SeoSourceHost, SeoSourceFtpUser, SeoDestHost, SeoDestFtpUser, SeoOperation);
            return Ok(Lista);
        }

        [HttpPost]
        public async Task<ActionResult<MvSysSeoExchangeOperation>> AddExchangeOperation([FromBody] MvSysSeoExchangeOperation exchangeOperation)
        {
            try
            {
                await _controller.AddExchangeOperation(exchangeOperation);
                if (exchangeOperation == null)
                    return NotFound();
                return Ok(exchangeOperation);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut("put/{seoCompany}/{SeoSourceHost}/{SeoSourceFtpUser}/{SeoDestHost}/{SeoDestFtpUser}/{SeoOperation}")]
        public async Task<ActionResult<MvSysSeoExchangeOperation>> UpdateExchangeOperation([FromBody] MvSysSeoExchangeOperation exchangeOperation, string seoCompany, string SeoSourceHost, string SeoSourceFtpUser, string SeoDestHost, string SeoDestFtpUser, string SeoOperation)
        {
            if(exchangeOperation.SeoCompany == seoCompany &&
               exchangeOperation.SeoSourceHost == SeoSourceHost &&
               exchangeOperation.SeoSourceFtpUser == SeoSourceFtpUser &&
               exchangeOperation.SeoDestHost == SeoDestHost &&
               exchangeOperation.SeoDestFtpUser == SeoDestFtpUser &&
               exchangeOperation.SeoOperation == SeoOperation)
            {
                await _controller.UpdateExchangeOperation(exchangeOperation);
                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("delete/{seoCompany}/{SeoSourceHost}/{SeoSourceFtpUser}/{SeoDestHost}/{SeoDestFtpUser}/{SeoOperation}")]
        public async Task<ActionResult<MvSysSeoExchangeOperation>> DeleteExchangeOperation(string seoCompany, string SeoSourceHost, string SeoSourceFtpUser, string SeoDestHost, string SeoDestFtpUser, string SeoOperation)
        {
            var exchangeOperation = await _controller.SearchExchangeOperation(seoCompany, SeoSourceHost, SeoSourceFtpUser, SeoDestHost, SeoDestFtpUser, SeoOperation);
            bool Lista = await _controller.DeleteExchangeOperation(exchangeOperation);
            return Ok(Lista);
        }
    }
}
