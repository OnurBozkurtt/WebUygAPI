using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUygAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using Microsoft.AspNetCore.JsonPatch;
using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using sun.swing;

namespace WebUygAPI.Controllers
{
    [Route("api")]
    [EnableCors]
    [ApiController]
    [Produces("application/json")]

    public class ValuesController : ControllerBase
    {
        //Remde depolamak yerine silip tekrar oluştur.
        private static List<DrawInfo> Drawings = new List<DrawInfo>();


        [HttpGet]
        [Route("GetDraws")]
        public async Task<IActionResult> get()
        {

            string filePath = @"C:\Users\Casper\source\repos\WebUygAPI\WebUygAPI\LineData.json";
            using (StreamReader file = new StreamReader(filePath))
            {
                string o1 = file.ReadToEnd();
                var o2 = JsonConvert.SerializeObject(o1);

            }
            var json = System.IO.File.ReadAllText(filePath);
            //var read = json.Split(new char[] { '\r', '\n', '\\' }, StringSplitOptions.RemoveEmptyEntries);
            List<DrawInfo> ınfo = JsonConvert.DeserializeObject<List<DrawInfo>>(json);
            return Ok(ınfo);
        }


        [HttpPost]
        [Route("SendDraw")]
        public async Task<ActionResult<DrawInfo>> addDraw(DrawInfo draw)
        {
            if (ModelState.IsValid)
            {
                string filePath = @"C:\Users\Casper\source\repos\WebUygAPI\WebUygAPI\LineData.json";
                using (StreamReader file = new StreamReader(filePath))
                {
                    string o1 = file.ReadToEnd();
                    var o2 = JsonConvert.SerializeObject(o1);
                }
                var json = System.IO.File.ReadAllText(filePath);
                List<DrawInfo> info = JsonConvert.DeserializeObject<List<DrawInfo>>(json);
                Random random = new Random();
                draw.Id = random.Next();
                if (info == null)
                {
                    return NotFound();
                }
                var result = System.Text.Json.JsonSerializer.Serialize(draw);
                info.Add(draw);
                string changedJson = System.Text.Json.JsonSerializer.Serialize(info, new JsonSerializerOptions() { WriteIndented = true });

                System.IO.File.WriteAllText(filePath, changedJson);

                return Ok(result);
            }
            return Ok();

        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update(int id, DrawInfo draw)
        {
            if (ModelState.IsValid)
            {
                string filePath = @"C:\Users\Casper\source\repos\WebUygAPI\WebUygAPI\LineData.json";
                using (StreamReader file = new StreamReader(filePath))
                {
                    string o1 = file.ReadToEnd();
                    var o2 = JsonConvert.SerializeObject(o1);
                }
                var json = System.IO.File.ReadAllText(filePath);

                List<DrawInfo> info = JsonConvert.DeserializeObject<List<DrawInfo>>(json);

                var upDraw = info.FirstOrDefault(x => x.Id == id);

                if (upDraw != null)
                {
                    upDraw.name = draw.name;
                    upDraw.number = draw.number;
                }

                string changedJson = System.Text.Json.JsonSerializer.Serialize(info, new JsonSerializerOptions() { WriteIndented = true });
                System.IO.File.WriteAllText(filePath, changedJson);
                return Ok(info);
            }

            return Ok();
        }

        [HttpPut]
        [Route("UpdateDraw")]
        public IActionResult UpdateDraw(int id, DrawInfo draw)
        {
            if (ModelState.IsValid)
            {
                string filePath = @"C:\Users\Casper\source\repos\WebUygAPI\WebUygAPI\LineData.json";
                using (StreamReader file = new StreamReader(filePath))
                {
                    string o1 = file.ReadToEnd();
                    var o2 = JsonConvert.SerializeObject(o1);
                }
                var json = System.IO.File.ReadAllText(filePath);

                List<DrawInfo> info = JsonConvert.DeserializeObject<List<DrawInfo>>(json);

                var upDraw = info.FirstOrDefault(x => x.Id == id);
               
                if (upDraw.Id == draw.Id)
                {
                    upDraw.name = draw.name;
                    upDraw.number = draw.number;
                    upDraw.coordinates = draw.coordinates;
                }


                string changedJson = System.Text.Json.JsonSerializer.Serialize(info, new JsonSerializerOptions() { WriteIndented = true });

                System.IO.File.WriteAllText(filePath, changedJson);
                return Ok(info);
            }

            return Ok();
        }





        [HttpDelete]
        [Route("DeleteDraw")]
        public IActionResult DeleteDraw(int id)
        {

            string filePath = @"C:\Users\Casper\source\repos\WebUygAPI\WebUygAPI\LineData.json";
            using (StreamReader file = new StreamReader(filePath))
            {
                string o1 = file.ReadToEnd();
                var o2 = JsonConvert.SerializeObject(o1);

            }
            var json = System.IO.File.ReadAllText(filePath);
            List<DrawInfo> ınfo = JsonConvert.DeserializeObject<List<DrawInfo>>(json);
            var removeDraw = ınfo.Where(x => x.Id == id).FirstOrDefault();
            ınfo.Remove(removeDraw);
            var changedInfo = System.Text.Json.JsonSerializer.Serialize(ınfo, new JsonSerializerOptions() { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, changedInfo);
            //serialzie
            //var changedJson = System.Text.Json.JsonSerializer.Serialize(removeDraw, new JsonSerializerOptions() { WriteIndented = true });

            return Ok(changedInfo);
        }

        [HttpGet]
        [Route("QueryDraws")]
        public async Task<IActionResult> getQuery()
        {
            string filePath = @"C:\Users\Casper\source\repos\WebUygAPI\WebUygAPI\LineData.json";
            using (StreamReader file = new StreamReader(filePath))
            {
                string o1 = file.ReadToEnd();
                var o2 = JsonConvert.SerializeObject(o1);

            }
            var json = System.IO.File.ReadAllText(filePath);
            List<DrawInfo> ınfo = JsonConvert.DeserializeObject<List<DrawInfo>>(json);
            return Ok(ınfo);
        }
    }
}
