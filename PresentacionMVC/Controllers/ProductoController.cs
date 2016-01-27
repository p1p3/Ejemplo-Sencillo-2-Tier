using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Core;
using PresentacionMVC.Models.Core;

namespace PresentacionMVC.Controllers
{
    public class ProductoController : Controller
    {

        private IUnitOfWork _unitOfWork;
        public ProductoController(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        // GET: Producto
        public ActionResult Index()
        {
            return View();
        }

        // GET: Producto/Details/5
        public ActionResult Details(int id)
        {
            ProductViewModel Producto = new ProductViewModel(_unitOfWork.ProductoRepository.FindById(id));
            return View(Producto);
        }

        // GET: Producto/Create
        public ActionResult Create()
        {
            var Categorias = _unitOfWork.CategoriaRepository.PageAndFilter().Select(x => new  CategoriaViewModel(x)).ToList();
            return View(new ProductViewModel() { Categorias = Categorias });
        }

        [HttpPost]
        // GET: Post/Create
        public ActionResult Create(ProductViewModel producto)
        {
            var Categoria = _unitOfWork.CategoriaRepository.FindById(producto.CategoriaId);
            var Producto = producto.ToDomainModel(Categoria);

            _unitOfWork.ProductoRepository.Add(Producto);
            _unitOfWork.SaveChanges();
            return RedirectToAction("List", "Producto");
        }

        // GET: Producto/List
        public ActionResult List()
        {
            var productos = _unitOfWork.ProductoRepository.PageAndFilter().Select(x => new ProductViewModel(x)).ToList();
            return View(productos);
        }
    }
}