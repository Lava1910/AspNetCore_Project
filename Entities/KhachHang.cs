using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class KhachHang
{
    public string MaKh { get; set; } = null!;

    public string TenKh { get; set; } = null!;

    public string SdtKh { get; set; } = null!;

    public string EmailKh { get; set; } = null!;

    public string? DiachiKh { get; set; }

    public int? UserId { get; set; }

    public virtual Account? User { get; set; }
}
