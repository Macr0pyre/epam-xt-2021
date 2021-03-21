using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_2.Entities;

namespace Task_2_2.Interfaces
{
    public interface ILocated
    {
        Point Location { get; }
    }
}
