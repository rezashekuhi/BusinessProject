using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Services.Groups.Dto
{
    public class AddGroupDto
    {
        [Required]
        public string Name { get; set; }
    }
}
