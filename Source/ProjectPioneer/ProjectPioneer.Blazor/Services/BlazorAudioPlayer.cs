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
			// _audioFxPlayers.Add(new AudioWrapper() {AudioFxComponent = new AudioFxPlayer() });
			//
			// await _audioFxPlayers[i].AudioFxComponent.PlaySoundAsync(@AudioFxHelper.Fx_Calm_Url);
			
			AudioWrapper audio = new () { AudioFxComponent = new AudioFxPlayer() };
			AudioFxPlayers.Add(audio);
			// await Task.Delay(25).ConfigureAwait(false);
			await audio.AudioFxComponent.PlaySoundAsync(soundUrl).ConfigureAwait(false);
		}
	}
}