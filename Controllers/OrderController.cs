using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using techwork_after_america_return.Data;
using techwork_after_america_return.Data.Entities;
using techwork_after_america_return.ViewModels;

namespace techwork_after_america_return.Controllers
{
    [Route("api/[Controller]")]
    public class OrderController : Controller
    {
        private readonly ITechworkRepository _repository;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        
     

        public OrderController(ITechworkRepository repository, ILogger<OrderController> logger,IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(bool includeItems = true)
        {
            try
            {
                var result = _repository.GetAllOrders(includeItems);
                return Ok(_mapper.Map<IEnumerable<OrderViewModel>>(result));//we can make even icollection insted of ienumerable
               // return Ok(_repository.GetAllOrders());
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to retrieve: {ex}");
                return BadRequest("Failed to get orders");

            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                if (order != null) return Ok(_mapper.Map<Order, OrderViewModel>(order));
                else return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to retrieve:{ex}");
                return BadRequest("Failed");
            }
        }

        [HttpPost]

        public IActionResult Post([FromBody] OrderViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /*  var newOrder = new Order()
                      {
                          OrderDate = model.OrderDate,
                          OrderNumber = model.OrderNumber,
                          Id = model.OrderId
                      }; change to automapper==>var newOrder = _mapper.Map<OrderViewModel, Order>(model);*/
                    var newOrder = _mapper.Map<OrderViewModel, Order>(model);
                    if(newOrder.OrderDate == DateTime.MinValue)
                    {
                        newOrder.OrderDate = DateTime.Now;
                    }
                    _repository.AddEntity(newOrder);
                    if (_repository.SaveAll())
                    {
                       /*var vm = new OrderViewModel() removed since automapper used if no automapper use this way
                        {
                            OrderId = newOrder.Id,
                            OrderDate = newOrder.OrderDate,
                            OrderNumber = newOrder.OrderNumber
                        };
                       return Created($"/api/order/{vm.OrderId}",vm);*/
                        return Created($"/api/order/{newOrder.Id}", _mapper.Map<Order,OrderViewModel>(newOrder)); //for post we have to show created
                    }

                }
                else
                {
                    return BadRequest(model);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"failed to post: {ex}");
            }
            return BadRequest("Failed to save new orders");
        }
        }
        }



       /*frombody is controller
        * 
        * [HttpPost]
        public IActionResult Post(Object model)
            {
            try {
                _repository.AddEntity(model);
                if (_repository.SaveAll())
                {
                    return Created($"/api/order/{model}", model);
                }
            }

            catch (Exception ex)
            {
                _logger.LogError($"failed to retrieve:{ex}");

            }

return BadRequest("Failed");

         }*/



