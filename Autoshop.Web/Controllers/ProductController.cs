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

    [HttpGet]
    [Route("Product/Edit/{productId:int}")]
    public async Task<IActionResult> Edit(int productId)
    {
        var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);
        if (response != null && response.IsSuccess)
        {
            var productDto = JsonConvert.DeserializeObject<ProductDto>(Convert.ToString(response.Result));
            return View(productDto);
        }
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int productId)
    {
        var response = await _productService.GetProductByIdAsync<ResponseDto>(productId);
        if (response != null && response.IsSuccess)
        {
            var model = JsonConvert.DeserializeObject<ProductDto>(response.Result.ToString());
            return View(model);
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(ProductDto model)
    {
        if (model.ProductId != 0)
        {
            var response = await _productService.DeleteProductAsync<ResponseDto>(model.ProductId);
            if (response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
        }

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(ProductDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.UpdateProductAsync<ResponseDto>(model);
            if (response != null && response.IsSuccess)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        
        return View(model);
    }
    
}