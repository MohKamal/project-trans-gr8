namespace TransGr8_DD_Test
{
	public class Spell
	{
		public string Name { get; set; }
		public int Level { get; set; }
		public string CastingTime { get; set; }
		public string Components { get; set; }
		public int Range { get; set; }
		public string Duration { get; set; }
		public string SavingThrow { get; set; }

		/// <summary>
		/// Get the spell properties that don't need to be tested
		/// This properties are a descriptive part of the spell
		/// </summary>
		public string[] PropertyToIgnoreOnChecking
		{
			get
			{
				return new string[]
				{
					"Name",
				};
			}
		}

		/// <summary>
		/// Get the spell components as an array
		/// </summary>
		/// <returns></returns>
		public string[] getCompoents()
		{
			return this.Components.Split(',');
		}
	}
}