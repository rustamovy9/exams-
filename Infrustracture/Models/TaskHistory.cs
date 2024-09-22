﻿using System.Diagnostics;

namespace Infrustracture.Models;

public class TaskHistory
{
    public Guid Id { get; set; }
    public Guid TaskId { get; set; }
    public string ChangeDescription { get; set; } = null!;
    public DateTime ChangedAt { get;}= DateTime.Now;
}