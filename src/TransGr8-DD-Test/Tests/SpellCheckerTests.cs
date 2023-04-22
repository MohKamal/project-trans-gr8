using NUnit.Framework;
using TransGr8_DD_Test.Helpers;
using TransGr8_DD_Test.Services;

namespace TransGr8_DD_Test.Tests
{

	[TestFixture]
	public class SpellCheckerTests
	{
		private List<Spell> spells;
		private User user;

		[SetUp]
		public void Setup()
		{

			spells = SpellService.GetAll();

            // Create a new User object with default values for testing.
            user = UserService.GetAll().First();
		}

		[Test]
		public void TestCanUserCastSpellReturnsTrue()
		{
			LoggerHelper.Log().Information("Test Can User Cast Spell Returns True");
			// Arrange
			SpellChecker spellChecker = new SpellChecker();
			string spellName = "Fireball";

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.True(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForInsufficientLevel()
		{
			LoggerHelper.Log().Information("Test Can User Cast Spell Returns False For Insufficient Level");
            // Arrange
            SpellChecker spellChecker = new SpellChecker();
			string spellName = "Fireball";
			user.Level = 2;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForMissingVerbalComponent()
		{
			LoggerHelper.Log().Information("Test Can User Cast Spell Returns False For Missing Verbal Component");
            // Arrange
            SpellChecker spellChecker = new SpellChecker();
			string spellName = "Command";
			user.HasVerbalComponent = false;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForMissingSomaticComponent()
		{
			LoggerHelper.Log().Information("Test Can User Cast Spell Returns False For Missing Somatic Component");
            // Arrange
            SpellChecker spellChecker = new SpellChecker();
			string spellName = "Cure Wounds";
			user.HasSomaticComponent = false;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForMissingMaterialComponent()
		{
            LoggerHelper.Log().Information("Test Can User Cast Spell Returns False For Missing Material Component");
            // Arrange
            SpellChecker spellChecker = new SpellChecker();
			string spellName = "Identify";
			user.HasMaterialComponent = false;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForInsufficientRange()
		{
            LoggerHelper.Log().Information("Test Can User Cast Spell Returns False For Insufficient Range");
            // Arrange
            SpellChecker spellChecker = new SpellChecker();
			string spellName = "Fireball";
			user.Range = 20;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

		[Test]
		public void TestCanUserCastSpellReturnsFalseForMissingConcentration()
		{
            LoggerHelper.Log().Information("Test Can User Cast Spell Returns False For Missing Concentration");
            // Arrange
            SpellChecker spellChecker = new SpellChecker();
			string spellName = "Hold Person";
			user.HasConcentration = false;

			// Act
			bool result = spellChecker.CanUserCastSpell(user, spellName);

			// Assert
			Assert.False(result);
		}

        [Test]
        public void TestCanUserCastSpellReturnsFalseForMissingSavingThrow()
        {
            LoggerHelper.Log().Information("Test Can User Cast Spell Returns False For Missing Saving Throw");
            // Arrange
            SpellChecker spellChecker = new SpellChecker();
            string spellName = "Fireball";
            user.HasDexterity = false;

            // Act
            bool result = spellChecker.CanUserCastSpell(user, spellName);

            // Assert
            Assert.False(result);
        }
    }
}
