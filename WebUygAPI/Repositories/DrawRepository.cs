//using Newtonsoft.Json;

//namespace WebUygAPI.Models
//{
//    public class DrawRepository : IDrawRepository
//    {
//        private List<DrawInfo> draw = new List<DrawInfo>();
//        private int _nextId = 1;

//        public DrawRepository()
//        {
//            string filePath = @"C:\Users\Casper\source\repos\WebUygAPI\WebUygAPI\LineData.json";
//            using (StreamReader file = new StreamReader(filePath))
//            {
//                string o1 = file.ReadToEnd();
//                var o2 = JsonConvert.SerializeObject(o1);
//                var json = File.ReadAllText(filePath);
//                List<DrawInfo> ınfo = JsonConvert.DeserializeObject<List<DrawInfo>>(json);
//            }
//        }

//        public IEnumerable<DrawInfo> GetAllDraws()
//        {
//            return draw;
//        }

//        public DrawInfo GetDrawById(int id)
//        {
//            return draw.Find(p => p.Id == id);
//        }

//        public DrawInfo PostDraw(DrawInfo item)
//        {
//            if (item == null)
//            {
//                throw new ArgumentNullException("item");
//            }
//            item.Id = _nextId++;
//            draw.Add(item);
//            return item;
//        }

//        public void DeleteDrawById(int id)
//        {
//            draw.RemoveAll(p => p.Id == id);
//        }

//        public bool UpdateDrawById(DrawInfo item)
//        {
//            if (item == null)
//            {
//                throw new ArgumentNullException("item");
//            }
//            int index = draw.FindIndex(p => p.Id == item.Id);
//            if (index == -1)
//            {
//                return false;
//            }
//            draw.RemoveAt(index);
//            draw.Add(item);
//            return true;
//        }
//    }
//}