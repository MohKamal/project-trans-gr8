using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Interfaces
{
    /// <summary>
    /// The obligatory function by the task
    /// </summary>
    public interface IUserCanCastSpell
    {
        public bool CanUserCastSpell(User user, string spellName);
    }
}
