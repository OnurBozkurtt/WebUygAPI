using System.ComponentModel.DataAnnotations;

namespace WebUygAPI.Models
 
{
    public class DrawInfo

    {
        
        public int Id { get; set; }
        [Required(ErrorMessage = "You must provide a Name.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid character")]
        public string name { get; set; }
        [Required(ErrorMessage = "You must provide a Number.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Invalid number")]
        public string number { get; set; }
        public object coordinates { get; set; }

       
    }

}
