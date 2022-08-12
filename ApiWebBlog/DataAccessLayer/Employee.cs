using System.ComponentModel.DataAnnotations;

namespace ApiWebBlog.DataAccessLayer
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
