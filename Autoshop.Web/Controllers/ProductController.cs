using Autoshop.Web.Models;
using Autoshop.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Autoshop.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
        var responseDto = await _productService.GetAllProductsAsync<ResponseDto>();
        if (responseDto != null && responseDto.IsSuccess)
        {
            var productsDtos = JsonConvert.DeserializeObject<ProductDto[]>(Convert.ToString(responseDto.Result));
            return View(productsDtos);
        }

        return View();
    }
}