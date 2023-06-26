namespace ProjectPioneer.Blazor.Services
{
	public interface IAudioPlayer
	{
		List<AudioWrapper> AudioFxPlayers { get; }
		Task PlaySoundAsync(string soundUrl);
		void Cleanup();
	}
}