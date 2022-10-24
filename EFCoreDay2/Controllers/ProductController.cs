using EFCoreDay2.DTOs;
using EFCoreDay2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ProductStore.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
     private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

   
        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }
    
    [HttpGet]
    public IEnumerable<GetProductRespone> GetAll()
    {
        return _productService.GetAll();
    }

    [HttpGet("{id}")]
    public GetProductRespone? GetById(int id)
    {
        return _productService.GetById(id);
    }

    [HttpPost]
    public AddProductResponse? Create([FromBody] AddProductRequest requestModel)
    {
        return _productService.Create(requestModel);
    }

    [HttpPut]
    public UpdateProductResponse? Update([FromBody] UpdateProductRequest requestModel)
    {
        return _productService.Update(requestModel);
    }

    [HttpDelete("{id}")]
    public bool Delete(int id)
    {
        return _productService.Delete(id);
    }
}