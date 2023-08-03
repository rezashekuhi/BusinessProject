using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templete.Services.Products.Dto
{
    public class AddProductDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int GroupId { get; set; }
        [Required]
        [Range(1,int.MaxValue)]
        public int MinimumInventory { get; set; }
    }
}
