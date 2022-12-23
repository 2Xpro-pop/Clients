using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal;
public interface IIdPickable
{
    int Id { get; set; }
    string Description { get; }
}
