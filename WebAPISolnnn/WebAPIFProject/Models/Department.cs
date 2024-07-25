using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIFProject.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DeptNo { get; set; }
        public string DName {  get; set; }
        public string Location { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
