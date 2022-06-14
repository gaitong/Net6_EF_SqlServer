using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet()]
        public IEnumerable<Crypto> GetAll()
        {
            return _dataContext.Crypto.ToList();
        }

        [HttpGet("{id}")]
        public Crypto? GetById(int id)
        {
            return _dataContext.Crypto.Find(id);
        }

        [HttpPost]
        public void Add(Crypto crypto)
        {
            _dataContext.Add(crypto);
            _dataContext.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Update(int id ,Crypto crypto)
        {
            _dataContext.Entry(crypto).State = EntityState.Modified;
            _dataContext.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Crypto crypto = _dataContext.Crypto.Find(id);
            _dataContext.Crypto.Remove(crypto);
            _dataContext.SaveChanges();
        }
    }
}
