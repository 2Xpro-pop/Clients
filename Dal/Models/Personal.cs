using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models;
public class Personal: IIdPickable
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Surname
    {
        get; set;
    }
    public string PhoneNumber
    {
        get; set;
    }
    public string Address
    {
        get; set;
    }
    public string Email
    {
        get; set;
    }
    public int BranchOfficeId
    {
        get; set;
    }
    public string Post
    {
        get; set;
    }
    public int SalaryType
    {
        get; set;
    }
    public int SalaryPercent
    {
        get; set;
    }
    public double SalaryAmount
    {
        get; set;
    }

    public string Description => $"{Name} {Surname}";
}
