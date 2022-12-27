using System;
using System.Collections.Generic;

namespace Emp.Models;

public partial class TbEmployee
{
    public int Id { get; set; }

    public string? EmployeeCode { get; set; }

    public string? EmployeeName { get; set; }

    public string? Ctc { get; set; }

    public string? Basic { get; set; }

    public string? Pf { get; set; }

    public string? Medical { get; set; }

    public string? Telephone { get; set; }

    public string? Lta { get; set; }

    public string? Spiallowance { get; set; }
}
