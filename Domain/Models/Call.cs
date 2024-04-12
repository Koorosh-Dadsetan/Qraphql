﻿using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Call
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string Phone { get; set; } = null!;
}
