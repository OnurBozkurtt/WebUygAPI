//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using WebUygAPI.Models;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Web;
//using System.Text.Json.Serialization;
//using System.Text.Json;
//using System.Text.Json.Nodes;
//using Microsoft.AspNetCore.Cors;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System.Reflection.Metadata;
//using System.Net;

//namespace WebUygAPI.Controllers
//{
//    [Route("api")]
//    [EnableCors]
//    [ApiController]
//    [Produces("application/json")]
//    public class DrawController : ControllerBase
//    {
//        //Remde depolamak yerine silip tekrar oluştur.
//        static readonly IDrawRepository repository = new DrawRepository();

//        [HttpGet]
//        [Route("GetAllDraws")]
//        public IEnumerable<DrawInfo> GetAllProducts()
//        {
//            return repository.GetAllDraws();
//        }

//        [HttpGet]
//        [Route("GetDrawById")]
//        public DrawInfo GetProduct(int id)
//        {
//            DrawInfo item = repository.GetDrawById(id);
//            return item;
//        }

//        [HttpPost]
//        [Route("PostDraw")]
//        public DrawInfo PostProduct(DrawInfo item)
//        {
//            item = repository.PostDraw(item);
//            return item;
//        }

//        [HttpPut]
//        [Route("UpdateDrawById")]
//        public void PutProduct(int id, DrawInfo draw)
//        {
//            draw.Id = id;
            
//        }

//        [HttpDelete]
//        [Route("DeleteDrawById")]
//        public void DeleteProduct(int id)
//        {
//            DrawInfo item = repository.GetDrawById(id);
//            if (item == null)
//            {
//                NotFound();
//            }
//            repository.DeleteDrawById(id);
//        }
//    }
//}
