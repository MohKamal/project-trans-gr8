using TransGr8_DD_Test.Services;

namespace TransGr8_DD_Test
{
    /// <summary>
    /// This class inherit's from the AbstractSpellChecker to implement the task function
    /// </summary>
    public class SpellChecker: AbstractSpellChecker
	{

		public SpellChecker() : base() { }

		/// <summary>
		/// The task function, check if the user can cast a spell
		/// </summary>
		/// <param name="user"></param>
		/// <param name="spellName"></param>
		/// <returns></returns>
		public override bool CanUserCastSpell(User user, string spellName)
		{
			Spell spell =SpellService.getSpellByName(spellName);

			// if not object were provided, abort
			if (spell == null) return false;
			if (user == null) return false;

			// Check spell conditions
			if (!HasUserSpellComponents(user, spell)) return false;
			if (!HasUserASpellCondition(user, spell, "Level")) return false;
			if (!HasUserASpellCondition(user, spell, "Range")) return false;
			if (!HasUserDuration(user, spell)) return false;
			if (!HasUserSavingThrow(user, spell)) return false;

            // if all the conditions a satisfied, the user can cast this spell
            return true;
		}
		
	}
}
