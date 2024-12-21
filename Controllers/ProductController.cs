using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techwork.Data.Entities;
using techwork_after_america_return.Data;

namespace techwork_after_america_return.Controllers
{
    [Route("api/[Controller]")]
     [ApiController]
    [Produces("application/json")]
    public class ProductController : Controller
    {
        private readonly ITechworkRepository _repository;
        private readonly ILogger<ProductController> _logger;
       public ProductController(ITechworkRepository repository,ILogger<ProductController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

          [HttpGet] 
            [ProducesResponseType(200)]
            [ProducesResponseType(400)]
            public ActionResult<IEnumerable<Product>> Get()
            {        // actionresult-it create one type for another we cant do this in interface so we need ok

                try
                { 
                return Ok(_repository.GetAllProducts());
                }
                catch (Exception ex)
                {
                    _logger.LogError($"failed to log:{ex}");
                    return BadRequest("Failed to get product");
                }
            }

        /*  [HttpGet]
         public IEnumerable<Product> Get()
         {
             return _repository.GetAllProducts();

         }*/
    }
}
/* [HttpGet]
        public IEnumerable<Product> Get()
        {
            try { 
            return _repository.GetAllProducts();
            }
            catch
            {
                _logger.LogError("failed to log:{ex}");
                return null;
            }
        }    

 we cant put code like this with json result everywhere 
we tie the code to return json results we can even have data type changes for different type of data this method bcome rigid
so we use iactionresult

 public jsonResult Get()
        {
            try { 
            return _repository.GetAllProducts();
            }
            catch
            {
                _logger.LogError("failed to log:{ex}");
                return null;
            }
        }
 
                 // return null; //we get empty result with errors

 
 
 */
