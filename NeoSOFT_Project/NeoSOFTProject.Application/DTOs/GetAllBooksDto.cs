﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoSOFTProject.Application.DTOs
{
   public class GetAllBooksDto 
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string AuthorName { get; set; } = string.Empty;
    }
}
