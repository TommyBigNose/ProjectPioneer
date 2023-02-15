namespace ProjectPioneer.Systems.Character
{
	public interface IHeroBuilder
	{
		IHero CreateHero(string name, IJob job, IImplant implant);
	}
}
