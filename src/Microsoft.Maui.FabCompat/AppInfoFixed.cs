using Microsoft.Maui.ApplicationModel;

namespace Microsoft.Maui.FabCompat;

public static class AppInfoFixed
{
	// Workaround until https://github.com/dotnet/maui/pull/11200 is merged
	public static AppTheme RequestedTheme =>
#if ANDROID
		(Application.Context.Resources!.Configuration!.UiMode & Android.Content.Res.UiMode.NightMask) switch
		{
			Android.Content.Res.UiMode.NightYes => AppTheme.Dark,
			Android.Content.Res.UiMode.NightNo => AppTheme.Light,
			_ => AppTheme.Unspecified
		};
#else
		AppInfo.RequestedTheme;
#endif
}