using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string? TenNv { get; set; }

    public string? SdtNv { get; set; }

    public string? EmailNv { get; set; }

    public string? PhongBan { get; set; }

    public string? BuuCuc { get; set; }

    public int? UserId { get; set; }

    public virtual BuuCuc? BuuCucNavigation { get; set; }

    public virtual PhongBan? PhongBanNavigation { get; set; }

    public virtual Account? User { get; set; }
}
