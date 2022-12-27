using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Emp.Models;

public partial class Register
{
    [Key]
    public int RegId { get; set; }

    public string? RegEmployeeCode { get; set; }

    public string? RegEmployeeName { get; set; }

    public string? RegCtc { get; set; }

    public string? RegBasic { get; set; }

    public string? RegPf { get; set; }

    public string? RegMedical { get; set; }

    public string? RegTelephone { get; set; }

    public string? RegLta { get; set; }

    public string? RegSpiallowance { get; set; }
}
