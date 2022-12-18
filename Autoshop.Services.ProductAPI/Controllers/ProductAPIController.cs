using Autoshop.Services.ProductAPI.Models.Dto;
using Autoshop.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autoshop.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductApiController : ControllerBase
    {
        protected ResponseDto _response;

        private readonly IProductRepository _productRepository;

        public ProductApiController(IProductRepository repository)
        {
            _productRepository = repository;
            _response = new ResponseDto();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ResponseDto> Get()
        {
            try
            {
                var productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> {ex.ToString()};
            }

            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDto> Get(int id)
        {
            try
            {
                var productDtos = await _productRepository.GetProductById(id);
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ResponseDto> Post([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<ResponseDto> Put([FromBody] ProductDto productDto)
        {
            try
            {
                var model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDto> Delete(int id)
        {
            try
            {
                var isSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }
    }
}
