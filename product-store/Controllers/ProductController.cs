using Microsoft.AspNetCore.Mvc;
using product_store.Models;
using product_store.Service;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _productService.GetAllProducts());
    }

    public async Task<IActionResult> Details(Guid? id)
    {
        if (id == null)
            return NotFound();

        var product = await _productService.GetProduct(id);
        if (product == null)
            return NotFound();

        return View(product);
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
        return RedirectToAction(nameof(Index));
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
        return RedirectToAction(nameof(Index));
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
        var product = await _productService.GetProduct(id);
        if (product != null)
            await _productService.DeleteProduct(product);

        return RedirectToAction(nameof(Index));
    }
}