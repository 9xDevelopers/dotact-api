using System;
using System.Collections.Generic;
using App.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    /// <summary>
    /// BaseController
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BaseController<T>: ControllerBase
    {

        private UnitOfWork _unitOfWork;
        public BaseController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected BaseController()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<T> Get()
        {
            // return _storage.GetAll();
            return null;
        }
 
        // [HttpGet("{id}")]
        // public T Get(Guid id)
        // {
        //     // return _storage.GetById(id);
        //     return;
        // }
 
        [HttpPost("{id}")]
        public void Post(Guid id, [FromBody] T value)
        {
            // _storage.Add(id, value);
            // return null;
        }
    }
}