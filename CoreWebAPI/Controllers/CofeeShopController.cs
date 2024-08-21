using CoreWebAPI.Data;
using CoreWebAPI.Models;
using CoreWebAPI.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CofeeShopController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public CofeeShopController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        public IActionResult GetAllCofeeShops()
        {
            var allCofeeShops = dBContext.CofeeShops.ToList();
            return Ok(allCofeeShops);
        }


        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployee(Guid id)
        {
            var cofeeShop = dBContext.CofeeShops.Find(id);
            if (cofeeShop == null)
            {
                return NotFound();
            }
            return Ok(cofeeShop);
        }

        [HttpPost]
        public IActionResult AddCofeeShop(AddCofeeShopDTO addCofeeShopDTO)
        {
            var cofeeShopEntity = new CofeeShop()
            {
                Name = addCofeeShopDTO.Name,
                OpeningHours = addCofeeShopDTO.OpeningHours,
                Address = addCofeeShopDTO.Address
            };

            dBContext.CofeeShops.Add(cofeeShopEntity);
            dBContext.SaveChanges();
            return Ok(cofeeShopEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(int id, UpdateCofeeShopDTO updateCofeeShopDTO)
        {
            var cofeeShop = dBContext.CofeeShops.Find(id);
            if (cofeeShop == null)
            {
                return NotFound();
            }
            cofeeShop.Name = updateCofeeShopDTO.Name;
            cofeeShop.OpeningHours = updateCofeeShopDTO.OpeningHours;
            cofeeShop.Address = updateCofeeShopDTO.Address;
            //dBContext.Employees.Update(employee);
            dBContext.SaveChanges();

            return Ok(cofeeShop);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteEmployee(int id)
        {
            var cofeeShop = dBContext.CofeeShops.Find(id);
            if (cofeeShop == null)
            {
                return NotFound();
            }
            dBContext.CofeeShops.Remove(cofeeShop);
            dBContext.SaveChanges();
            return Ok(cofeeShop);
        }

    }
}
