using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net6_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoesController : ControllerBase
    {
        private DataContext _dataContext;

        public CryptoesController(DataContext dataContext)
        {
            _dataContext = dataContext; 
        }
        [HttpGet]
        public IEnumerable<Crypto> GetAll()
        {
            return _dataContext.Crytos.ToList();
        }
    }
}
