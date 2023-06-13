using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class PhieuGui
{
    public string MaPg { get; set; } = null!;

    public string? TrongLuong { get; set; }

    public double? CuocPhi { get; set; }

    public DateTime? NgayGui { get; set; }

    public DateTime? NgayNhan { get; set; }
}
