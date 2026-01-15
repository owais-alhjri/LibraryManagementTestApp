using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.DTOs
{
    public class UpdateBook
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? BookState { get; set; }
    }
}
