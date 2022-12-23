using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models;
public class Inventory: IIdPickable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Amount { get; set; }
    public int BranchOfficeId { get; set; }
    public string Description => Name;
}
