using Agreement.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agreement.Models
{
    public class ErrorModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        [Required]
        public string UniqueId { get; set; }
        [Required]
        public ResultType ResultType { get; set; }
        public string ErrorMessage { get; set; }
        [Required]
        public RequestType RequestType { get; set; }

    }
}
