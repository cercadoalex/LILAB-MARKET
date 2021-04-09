using LILAB.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoService _productoService;
        public ProductoController(ProductoService productoService)
        {
            _productoService = productoService;
        }

        //http://localhost:5000/api/producto
        [HttpGet]
        public ActionResult GetAll()
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                var item = _productoService.GetAll();
                if (item != null)
                {
                    resposonse.data = item;
                    resposonse.errormensaje = "";
                    resposonse.error = false;
                }
                else
                {
                    resposonse.data = null;
                    resposonse.errormensaje = "No Existe Registros";
                    resposonse.error = true;
                }
            }
            catch (Exception ex)
            {
                resposonse.data = null;
                resposonse.errormensaje = ex.Message;
                resposonse.error = true;
            }
            object datos = (object)resposonse;
            return Ok(datos);
        }

        //http://localhost:5000/api/producto/2
        [HttpGet("{productoId}")]
        public ActionResult GetProductoById(int productoId)
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                var item = _productoService.GetById(productoId);
                if (item != null)
                {
                    resposonse.data = item;
                    resposonse.errormensaje = "";
                    resposonse.error = false;
                }
                else
                {
                    resposonse.data = null;
                    resposonse.errormensaje = "No Existe Registros";
                    resposonse.error = true;
                }
            }
            catch (Exception ex)
            {
                resposonse.data = null;
                resposonse.errormensaje = ex.Message;
                resposonse.error = true;
            }
            object datos = (object)resposonse;
            return Ok(datos);
        }


        //http://localhost:5000/api/producto/Categoria/2
        [HttpGet("Categoria/{categoriaid}")]
        public ActionResult GetAllProductoByCategoriaId(int categoriaid)
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                var item = _productoService.GetAllByCategoriaId(categoriaid);
                if (item != null)
                {
                    resposonse.data = item;
                    resposonse.errormensaje = "";
                    resposonse.error = false;
                }
                else
                {
                    resposonse.data = null;
                    resposonse.errormensaje = "No Existe Registros";
                    resposonse.error = true;
                }
            }
            catch (Exception ex)
            {
                resposonse.data = null;
                resposonse.errormensaje = ex.Message;
                resposonse.error = true;
            }
            object datos = (object)resposonse;
            return Ok(datos);
        }


        //http://localhost:5000/api/producto/UpdateStock
        [HttpGet("UpdateStock")]
        public ActionResult Update()
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                _productoService.UpdateStock();
                resposonse.data = "";
                resposonse.errormensaje = "";
                resposonse.error = false;
            }
            catch (Exception ex)
            {
                resposonse.data = null;
                resposonse.errormensaje = ex.Message;
                resposonse.error = true;
            }
            object datos = (object)resposonse;
            return Ok(datos);
        }
    }
}
