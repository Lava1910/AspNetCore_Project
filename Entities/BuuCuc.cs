using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class BuuCuc
{
    public string MaBc { get; set; } = null!;

    public string TenBc { get; set; } = null!;

    public string DiachiBc { get; set; } = null!;

    public string SdtBc { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
