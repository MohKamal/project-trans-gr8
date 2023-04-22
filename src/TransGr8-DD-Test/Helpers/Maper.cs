using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Helpers
{
    /// <summary>
    /// To create a dynamic test functions, i need to map the spell requiements with the user fileds
    /// This way, it will be easier to know if the user can cast a spell
    /// Example: If the spell has the Component V, the function will search for the user property HasVerbalComponent using the mapping
    /// </summary>
    public class Maper
    {
        /// <summary>
        /// Spell components mapped with user fileds
        /// </summary>
        public Dictionary<string, string> SpellComponentsWithUserFileds
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {"V", "HasVerbalComponent" },
                    {"S", "HasSomaticComponent" },
                    {"M", "HasMaterialComponent" }
                };
            }
        }

        /// <summary>
        /// Spell duration mapped with user fields
        /// </summary>
        public Dictionary<string, string> SpellDurationsWithUserFileds
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {"Instantaneous", "" },
                    {"Concentration", "HasConcentration" },
                };
            }
        }

        /// <summary>
        /// Spell Saving throws mapped with the user fields
        /// </summary>
        public Dictionary<string, string> SpellSavingThrowWithUserFileds
        {
            get
            {
                return new Dictionary<string, string>()
                {
                    {"Dexterity", "HasDexterity" },
                };
            }
        }
    }
}
