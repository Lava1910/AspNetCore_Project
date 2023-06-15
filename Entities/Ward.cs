using System;
using System.Collections.Generic;

namespace AspNetCore_Project.Entities;

public partial class Ward
{
    public int WardsId { get; set; }

    public int DistrictId { get; set; }

    public string Name { get; set; } = null!;
}
