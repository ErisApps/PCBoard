using System.Reflection;
using IPA;
using IPA.Loader;
using IPA.Logging;
using PCBoard.Installers;
using SemVer;
using SiraUtil.Zenject;

namespace PCBoard
{
	[Plugin(RuntimeOptions.DynamicInit)]
	public class Plugin
	{
		private static PluginMetadata? _metadata;
		private static string? _name;
		private static Version? _version;

		public static string Name => _name ??= _metadata?.Name ?? Assembly.GetExecutingAssembly().GetName().Name;
		public static Version Version => _version ??= _metadata?.Version ?? new Version(Assembly.GetExecutingAssembly().GetName().Version.ToString(3));

		[Init]
		public void Init(Logger log, PluginMetadata pluginMetadata, Zenjector zenject)
		{
			_metadata = pluginMetadata;

			zenject.OnApp<AppCoreInstaller>().WithParameters(log);
			zenject.OnMenu<MenuCoreInstaller>();
		}

		[OnEnable,OnDisable]
		public void OnStateChanged()
		{
			// SiraUtil handles this for me, but just adding an empty body method to prevent warnings in the logs ^^
		}
	}
}