using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Services
{
    /// <summary>
    /// Get all the spells
    /// </summary>
    public class SpellService
    {
        public static List<Spell> GetAll()
        {
            List<Spell> spells = new List<Spell>();
            spells.Add(new Spell
            {
                Name = "Fireball",
                Level = 3,
                CastingTime = "1 action",
                Components = "V, S, M, (a tiny ball of bat guano and sulfur)",
                Range = 150,
                Duration = "Instantaneous",
                SavingThrow = "Dexterity"
            });
            spells.Add(new Spell
            {
                Name = "Magic Missile",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, S",
                Range = 120,
                Duration = "Instantaneous",
                SavingThrow = ""
            });
            spells.Add(new Spell
            {
                Name = "Cure Wounds",
                Level = 1,
                CastingTime = "1 action",
                Components = "V, S",
                Range = 1,
                Duration = "Instantaneous",
                SavingThrow = ""
            });
            return spells;
        }

        public static Spell getSpellByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return null;

            return SpellService.GetAll().Find(x => x.Name.ToLower() == name.ToLower());
        }
    }
}
