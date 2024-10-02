using System;
using System.Collections.Generic;

namespace MVC_EFCore.Models
{
    public partial class Pet
    {
        public int Id { get; set; }
        public string Ten { get; set; } = null!;
        public int? SoChan { get; set; } // ? nullable - có thể null
        public string? Loai { get; set; }
        public string? ImgUrl { get; set; }
        public int? SenId { get; set; }

        public virtual Sen? Sen { get; set; } // Navigation được sử dụng để tạo mối liên kết
    }
}
