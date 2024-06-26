﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ParentTable
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<ChildTable> ChildTables { get; set; } = new List<ChildTable>();
}
