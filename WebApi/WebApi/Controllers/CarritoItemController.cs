using LILAB.Model;
using LILAB.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoItemController : ControllerBase
    {
        private readonly CarritoItemService _carritoItemService;
        public CarritoItemController(CarritoItemService carritoItemService)
        {
            _carritoItemService = carritoItemService;
        }

        //http://localhost:5000/api/carritoItem
        [HttpGet]
        public ActionResult GetAll()
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                var item = _carritoItemService.GetAll();
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


        //http://localhost:5000/api/carritoItem/1
        [HttpDelete("{carritoId}")]
        public ActionResult Delete(int carritoId)
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                _carritoItemService.Delete(carritoId);
                resposonse.data = null;
                resposonse.errormensaje = "Registro Eliminado";
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


        //http://localhost:5000/api/carritoItem
        [HttpPost]
        public ActionResult Create(CarritoItem carritoItem)
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                _carritoItemService.Create(carritoItem);
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
