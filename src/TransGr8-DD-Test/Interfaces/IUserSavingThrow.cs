using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Interfaces
{
    /// <summary>
    /// Check if the user has the saving throws for a spell
    /// </summary>
    public interface IUserSavingThrow
    {
        public bool HasUserSavingThrow(User user, Spell spell);
    }
}
