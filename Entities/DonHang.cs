using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class DonHang
{
    public string MaDh { get; set; } = null!;

    public int? TrongLuong { get; set; }

    public string? DiaChiNhan { get; set; }

    public string? DiaChiGui { get; set; }

    public DateTime? NgayGui { get; set; }

    public DateTime? NgayNhan { get; set; }

    public string? BaoGia { get; set; }

    public string? TrangThai { get; set; }

    public virtual BaoGium? BaoGiaNavigation { get; set; }
}
