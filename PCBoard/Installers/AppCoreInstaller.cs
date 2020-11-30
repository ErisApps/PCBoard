using IPA.Logging;
using PCBoard.Services;
using SiraUtil;
using Zenject;

namespace PCBoard.Installers
{
	public class AppCoreInstaller : Installer<Logger, AppCoreInstaller>
	{
		private readonly Logger _logger;

		public AppCoreInstaller(Logger logger)
		{
			_logger = logger;
		}

		public override void InstallBindings()
		{
			Container.BindLoggerAsSiraLogger(_logger);

			Container.BindInterfacesAndSelfTo<NoticeBoardDataService>().AsSingle();
		}
	}
}