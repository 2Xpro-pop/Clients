using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models;
public class Schedule: IIdPickable
{
    public int Id { get; set; }
    public int PatientId { get; set; }
    public int PostId { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }

    public string Description => Date.ToString();
}
