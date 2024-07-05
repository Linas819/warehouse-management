using Microsoft.AspNetCore.Mvc;
using warehouse_management.Services;
using warehouse_management.WarehouseDB;
using warehouse_management.Models;

namespace warehouse_management.Controllers;

[ApiController]
[Route("[controller]")]
public class WarehouseController : ControllerBase
{
    private WarehouseService warehouseService;
    public WarehouseController(WarehouseService warehouseService)
    {
        this.warehouseService = warehouseService;
    }
    [HttpGet]
    public IActionResult GetWarehouseProducts()
    {
        List<Product> products = warehouseService.GetWarehouseProducts();
        return(Ok(new{
            Success = true,
            Data = products
        }));
    }
    [HttpDelete("{*productId}")]
    public IActionResult DeleteWarehouseProduct(string productId)
    {
        DatabaseUpdateResponceModel responceModel = warehouseService.DeleteWarehouseProduct(productId);
        return(Ok(new{
            Success = responceModel.Success,
            Message = responceModel.Message
        }));
    }
    [HttpPost]
    public IActionResult AddWarehouseProduct([FromBody] Product product)
    {
        DatabaseUpdateResponceModel responceModel = warehouseService.AddWarehouseProduct(product);
        return(Ok(new{
            Success = responceModel.Success,
            Message = responceModel.Message
        }));
    }
}