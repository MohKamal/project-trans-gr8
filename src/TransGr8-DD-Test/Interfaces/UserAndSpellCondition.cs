using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Interfaces
{
    /// <summary>
    /// Check if the user has a spell condition, general the user and spell will have the same property name
    /// </summary>
    public interface UserAndSpellCondition
    {
        public bool HasUserASpellCondition(User user, Spell spell, string property);
    }
}
