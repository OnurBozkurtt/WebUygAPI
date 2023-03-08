//using Newtonsoft.Json;
//using WebUygAPI.Models;

//namespace WebUygAPI
//{
//    public class DrawService
//    {
//        public List<DrawInfo> GetDraws()
//        {
//            string filePath = @"C:\Users\Casper\source\repos\WebUygAPI\WebUygAPI\LineData.json";
//            using (StreamReader file = new StreamReader(filePath))
//            {
//                string o1 = file.ReadToEnd();
//                var o2 = JsonConvert.SerializeObject(o1);

//            }
//            var json = File.ReadAllText(filePath);
//            List<DrawInfo> ınfo = JsonConvert.DeserializeObject<List<DrawInfo>>(json);

//            return ınfo;
            
//        }

//        public DrawInfo UpdateDraw(int id)
//        {

//            return DrawInfo.GetDraws.FirstOrDefault(x => x.Id == id);
//        }

//        public DrawInfo Edit(DrawInfo draw)
//        {
//            var existingDraw = GetDraws(draw.Id);
//            if (existingDraw != null)
//            {
//                existingDraw.username = draw.username;
//                existingDraw.Name = draw.number;

//            }

//            return existingDraw;

//        }
//    }
//}
