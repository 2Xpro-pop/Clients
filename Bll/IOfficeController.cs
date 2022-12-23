using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bll;
public interface IOfficeController
{
    Task ChangeBudget(int id, double budget, string description);
}
