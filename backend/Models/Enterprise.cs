using System;
using System.ComponentModel.DataAnnotations;

namespace APIBackend.Models
{
    public class Enterprise
    {
        [Key] public int Id { get; set; }
        [Required] public string Created_By { get; set; }
        [Required] public DateTime Created_Date { get; set; }
        [Required] public string Modified_By { get; set; }
        [Required] public DateTime Modified_Date { get; set; }
        [Required] public bool Status { get; set; }
        [Required] public string Address { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string Phone { get; set; }
    }
}
