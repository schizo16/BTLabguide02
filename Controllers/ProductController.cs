using BTLabguide02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTLabguide02.Controllers
{
    public class ProductController : Controller
    {


        private readonly List<Product> _products = new List<Product>
        {
            new Product {
                    Id = 1,
                    Name = "Đồ bơi trẻ em nam",
                    ImageUrl = "/images/1.jpg",
                    Price = 89.9,
                    SalePrice = 69.9,
                    CategoryId = 1,
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Status = "Còn hàng",
                    CreatedAt = DateTime.Now,

                },
                new Product {
                    Id = 2,
                    Name = "Đồ bơi trẻ em nữ",
                    ImageUrl = "/images/2.jpg",
                    Price = 99.9,
                    SalePrice = 79.9,
                    CategoryId = 1,
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Status = "Còn hàng",
                    CreatedAt = DateTime.Now,

                },
                new Product {
                    Id = 3,
                    Name = "Đồ bơi trẻ em nữ",
                    ImageUrl = "/images/3.jpg",
                    Price = 89.9,
                    SalePrice = 69.9,
                    CategoryId = 1,
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Status = "Còn hàng",
                    CreatedAt = DateTime.Now,

                },
                new Product {
                    Id = 4,
                    Name = "Đồ bơi trẻ em nữ",
                    ImageUrl = "/images/4.jpg",
                    Price = 89.9,
                    SalePrice = 69.9,
                    CategoryId = 1,
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Status = "Còn hàng",
                    CreatedAt = DateTime.Now,

                },
                new Product {
                    Id = 5,
                    Name = "Túi xách thời trang",
                    ImageUrl = "/images/5.jpg",
                    Price = 89.9,
                    SalePrice = 69.9,
                    CategoryId = 2,
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Status = "Còn hàng",
                    CreatedAt = DateTime.Now,

                },
                new Product {
                    Id = 6,
                    Name = "Túi xách thời trang",
                    ImageUrl = "/images/6.jpg",
                    Price = 129.9,
                    SalePrice = 119.9,
                    CategoryId = 2,
                    Description = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit...",
                    Status = "Còn hàng",
                    CreatedAt = DateTime.Now,

                },
        };
        private readonly List<Category> _categories = new List<Category>
        {
            new Category
                {
                    Id = 1,
                    Name = "Đồ bơi"
                },
                new Category
                {
                    Id = 2,
                    Name = "Túi xách"
                },
                new Category
                {
                    Id = 3,
                    Name = "Đồng hồ"
                },
                new Category
                {
                    Id = 4,
                    Name = "Ti vi"
                },
                new Category
                {
                    Id = 5,
                    Name = "Tủ lạnh"
                },
                new Category
                {
                    Id = 6,
                    Name = "Máy giặt"
                },
                new Category
                {
                    Id = 7,
                    Name = "Quạt điện"
                },
                new Category
                {
                    Id = 8,
                    Name = "Máy sưởi"
                }
                
        };

        [Route("san-pham", Name = "product")]
        public IActionResult Index()
        {
            var categories = _categories.ToList();

            var viewModel = new List<CategoryViewModel>();

            foreach (var category in categories)
            {
                var products = _products.Where(p => p.CategoryId == category.Id).ToList();

                var categoryViewModel = new CategoryViewModel
                {
                    Category = category,
                    Products = products
                };

                viewModel.Add(categoryViewModel);
            }

            return View(viewModel);
        }
        [Route("chi-tiet-san-pham")]
        public IActionResult Details(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        public IActionResult Category(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            var products = _products.Where(p => p.CategoryId == id).ToList();

            var viewModel = new CategoryViewModel
            {
                Category = category,
                Products = products
            };

            return View("Index", viewModel);
        }
    }


    }

