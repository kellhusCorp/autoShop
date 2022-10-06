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

    public async Task<IActionResult> Index()
    {
        var responseDto = await _productService.GetAllProductsAsync<ResponseDto>();
        if (responseDto != null && responseDto.IsSuccess)
        {
            var productsDtos = JsonConvert.DeserializeObject<ProductDto[]>(Convert.ToString(responseDto.Result));
            return View(productsDtos);
        }

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProductAsync<ResponseDto>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        
        return View(model);
    }
}