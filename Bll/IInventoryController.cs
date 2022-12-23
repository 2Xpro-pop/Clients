using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Bll;
public interface IInventoryController
{
    Task DecreaseAsync(Inventory item, int amount);
}
