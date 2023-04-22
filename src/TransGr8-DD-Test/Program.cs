using Serilog;
using TransGr8_DD_Test.Helpers;
using TransGr8_DD_Test.Services;

namespace TransGr8_DD_Test
{
	public class Program
	{
		static void Main(string[] args)
		{
            string spellName = args[0];
            // Use the spell checker to determine if the user can cast the spell.
            SpellChecker spellChecker = new SpellChecker();
			// Getting user from service
            bool canCast = spellChecker.CanUserCastSpell(UserService.GetAll().First(), spellName);

            // Output the result.
            LoggerHelper.Log().Information("Can the user cast {0}? {1}", spellName, canCast);
			Console.ReadKey();
		}
	}
}