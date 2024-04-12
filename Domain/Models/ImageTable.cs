using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class ImageTable
{
    public int Id { get; set; }

    public byte[]? Image { get; set; }
}
