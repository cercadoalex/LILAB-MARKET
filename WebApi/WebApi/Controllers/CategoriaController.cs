﻿using LILAB.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Dynamic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _categoriaService;
        public CategoriaController(CategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        //http://localhost:5000/api/categoria
        [HttpGet]
        public ActionResult GetAll()
        {
            dynamic resposonse = new ExpandoObject();
            try
            {
                var item = _categoriaService.GetAll();
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



    }
}
