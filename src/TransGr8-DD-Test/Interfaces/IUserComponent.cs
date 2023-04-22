using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Interfaces
{
    /// <summary>
    /// Check if the user has a or all the components of a spell
    /// </summary>
    public interface IUserComponent
    {
        public bool HasUserSpellComponents(User user, Spell spell);
        public bool HasUserSpellComponent(User user, Spell spell, string component);
    }
}
