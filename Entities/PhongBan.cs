using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class PhongBan
{
    public string MaPb { get; set; } = null!;

    public string TenPb { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
