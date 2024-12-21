using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Techwork.Data.Entities;
using techwork_after_america_return.Data;
using techwork_after_america_return.ViewModels;

namespace techwork_after_america_return.Controllers
{
    [Route("api/Orders/{Orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly ITechworkRepository _repository;
        private readonly ILogger<OrderController> _logger;
        private readonly IMapper _mapper;
        public OrderItemsController(ITechworkRepository repository, ILogger<OrderController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _repository.GetOrderById(orderId);
            if (order != null) return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var order = _repository.GetOrderById(orderId);
            if (order != null)
            {
                var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
                if (item != null)
                {
                    return Ok(_mapper.Map<OrderItemViewModel>(item));

                }
            }
            return NotFound();

        }

    }

    }
