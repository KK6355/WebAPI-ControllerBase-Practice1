﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_ControllerBase_Practice1.Models;
using WebAPI_ControllerBase_Practice1.Services;

namespace WebAPI_ControllerBase_Practice1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if (pizza is null)
                return NotFound();
            return pizza;
        }
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id=pizza.Id }, pizza);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if(id != pizza.Id)
                return BadRequest();
            var existingPizza = PizzaService.Get(id);
            if(existingPizza is null)
                return NotFound();
            PizzaService.Update(pizza);
            return NoContent();

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza is null)
                return NotFound();
            PizzaService.Delete(id);
            return NoContent();
            
        }
    }
}
