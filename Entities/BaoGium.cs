using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class BaoGium
{
    public string MaBg { get; set; } = null!;

    public decimal GiaDv { get; set; }

    public string? MaDv { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual DichVu? MaDvNavigation { get; set; }
}
