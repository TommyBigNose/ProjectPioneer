namespace ProjectPioneer.Systems.Data
{
	[AttributeUsage(AttributeTargets.Property)]
	public class SaveableAttribute : Attribute
	{
		private string _name;
		public string Name => _name;

		public SaveableAttribute(string name)
		{
			_name = name;
		}
	}
}
