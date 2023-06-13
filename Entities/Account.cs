using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class Account
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? UserEmail { get; set; }

    public string? UserPassword { get; set; }

    public string? Role { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; set; } = new List<KhachHang>();

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
