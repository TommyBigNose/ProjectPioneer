namespace ProjectPioneer.Blazor.Utility
{
	public static class AudioFxHelper
	{
		public static string Fx_Positive_Url =  "/sounds/Windows_Balloon.wav";
		public static string Fx_Negative_Url =  "/sounds/Windows_Notify.wav";
		public static string Fx_Success_Url =  "/sounds/Windows_Logon.wav";
		public static string Fx_Cheer_Url =  "/sounds/Windows_Tada.wav";
		public static string Fx_Failure_Url =  "/sounds/Windows_Ding.wav";
		// public static string Fx_Unknown_Url =  "/sounds/Windows_Ding.wav";
		public static string Fx_Info_Url =  "/sounds/Windows_Information_Bar.wav";
		
		public static string Fx_Shop_Beep_Url =  "/sounds/Repeatable_Beep.wav";
		
		public static string Fx_Calm_Url =  "/sounds/Windows_Ring9.wav";
		public static string Fx_Calm_2_Url =  "/sounds/Windows_Ring10.wav";
		public static string Fx_Calm_3_Url =  "/sounds/Windows_Ring8.wav";
		

		public static readonly Dictionary<string, int> FxTimerDetails = new()
		{
			{Fx_Positive_Url, 1000},
			{Fx_Negative_Url, 1500},
			{Fx_Success_Url, 5000},
			{Fx_Cheer_Url, 1500},
			{Fx_Failure_Url, 1000},
			// {Fx_Unknown_Url, 1000},
			{Fx_Info_Url, 1000},
			
			{Fx_Shop_Beep_Url, 1000},
			
			{Fx_Calm_Url, 10000},
			{Fx_Calm_2_Url, 10000},
			{Fx_Calm_3_Url, 10000},
			
		};
	}
}