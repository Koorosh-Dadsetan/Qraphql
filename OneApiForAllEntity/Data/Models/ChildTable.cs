using System;
using System.Collections.Generic;

namespace OneApiForAllEntity.Data.Models;

public partial class ChildTable
{
    public int Id { get; set; }

    public int? ParentId { get; set; }

    public string? ComponentName { get; set; }

    public virtual ParentTable? Parent { get; set; }
}
