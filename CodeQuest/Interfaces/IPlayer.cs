using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuest.Interfaces
{
    public interface IPlayer
    {
        string Name { get; }
        bool Equals(object name);
        int GetHashCode();
    }
}
