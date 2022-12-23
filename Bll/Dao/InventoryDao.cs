using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Models;

namespace Bll.Dao;
public class InventoryDao:Inventory
{
    public double Price { get; set; }
}
