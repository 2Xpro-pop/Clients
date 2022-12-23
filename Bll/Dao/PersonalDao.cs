using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Bll.Dao;
public class PersonalDao
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public double Salary { get; set; }
    public int SalaryProcent { get; set; }
    public string OfficeName { get; set; }
}
