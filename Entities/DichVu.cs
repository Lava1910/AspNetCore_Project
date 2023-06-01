using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class DichVu
{
    public string MaDv { get; set; } = null!;

    public string TenDv { get; set; } = null!;

    public string TrongLuong { get; set; } = null!;

    public string TuyenDv { get; set; } = null!;

    public virtual ICollection<BaoGium> BaoGia { get; set; } = new List<BaoGium>();
}
