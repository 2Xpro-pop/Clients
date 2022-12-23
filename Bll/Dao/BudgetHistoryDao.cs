using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll.Dao;
public class BudgetHistoryDao
{
    public string Fillial { get; set; } = null!;
    public string Description { get; set; } = null!;
    public double Currency
    {
        get; set;
    }
}
