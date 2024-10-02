using System;
using System.Collections.Generic;

namespace MVC_EFCore.Models
{
    public partial class Sen
    {
        public Sen() // Cái này xóa đi cũng ko sao
        {
            Pets = new HashSet<Pet>();
        }

        public int Id { get; set; }
        public string Ten { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? DiaChi { get; set; }

        public virtual ICollection<Pet> Pets { get; set; } // Navigation đến 1 List PET
        // Nghĩa là 1 SEN - Nhiều PET (thể hiện quan hệ 1 - n)
    }
}
