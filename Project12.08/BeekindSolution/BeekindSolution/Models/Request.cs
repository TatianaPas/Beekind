using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeekindSolution.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string CreatorId { get; set; }
        [ForeignKey("CreatorId")]
        [ValidateNever]
        public User User { get; set; }
        public string Location { get; set; }
    }
}
