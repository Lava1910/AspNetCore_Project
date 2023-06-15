using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class Province
{
    public int ProvinceId { get; set; }

    public string Name { get; set; } = null!;
}
