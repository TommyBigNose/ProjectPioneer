using ProjectPioneer.Blazor.Pages.Elements;

namespace ProjectPioneer.Blazor.Services
{
	public class BlazorAudioPlayer : IAudioPlayer
	{
		public List<AudioWrapper> AudioFxPlayers { get; private set; }

		public BlazorAudioPlayer()
		{
			AudioFxPlayers = new List<AudioWrapper>();
		}
		
		public async Task PlaySoundAsync(string soundUrl)
		{
			AudioWrapper audio = new () { AudioFxComponent = new AudioFxPlayer() };
			AudioFxPlayers.Add(audio);
			await Task.Delay(10);
			await audio.AudioFxComponent.PlaySoundAsync(soundUrl).ConfigureAwait(false);
		}

		public void Cleanup()
		{
			List<AudioWrapper> audioToCleanup = new();
			foreach (var audio in AudioFxPlayers)
			{
				if (!audio.AudioFxComponent.IsCurrentlyPlaying)
				{
					audioToCleanup.Add(audio);
				}
			}

			AudioFxPlayers = AudioFxPlayers.Except(audioToCleanup).ToList();
		}
	}
}