using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Interfaces
{
    /// <summary>
    /// Check if the user has the duration for a spell
    /// </summary>
    public interface IUserDuration
    {
        public bool HasUserDuration(User user, Spell spell);
    }
}
