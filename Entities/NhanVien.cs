using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string TenNv { get; set; } = null!;

    public string SdtNv { get; set; } = null!;

    public string EmailNv { get; set; } = null!;

    public string? PhongBan { get; set; }

    public string? BuuCuc { get; set; }

    public int? UserId { get; set; }

    public virtual BuuCuc? BuuCucNavigation { get; set; }

    public virtual PhongBan? PhongBanNavigation { get; set; }

    public virtual Account? User { get; set; }
}
