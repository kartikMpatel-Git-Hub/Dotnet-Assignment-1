using BLL.BussinesLogicLayer;
using Domain.ModelLayer;
using Microsoft.AspNetCore.Mvc;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.Total = await _productService.GetTotalProduct();
        return View(await _productService.GetAllProducts());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ProductModel productModel)
    {
        if (!ModelState.IsValid)
            return View(productModel);

        await _productService.CreateProduct(productModel);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
            return NotFound();

        var product = await _productService.GetProduct(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, ProductModel productModel)
    {
        if (id != productModel.Id)
            return NotFound();

        if (!ModelState.IsValid)
            return View(productModel);

        await _productService.UpdateProduct(productModel);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
            return NotFound();

        var product = await _productService.GetProduct(id);
        if (product == null)
            return NotFound();

        return View(product);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _productService.DeleteProduct(id);
        return RedirectToAction("Index");
    }
}