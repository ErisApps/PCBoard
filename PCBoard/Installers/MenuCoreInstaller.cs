using PCBoard.UI;
using SiraUtil;
using SiraUtil.Tools;
using Zenject;

namespace PCBoard.Installers
{
	public class MenuCoreInstaller : Installer<MenuCoreInstaller>
	{
		private readonly SiraLog _logger;

		public MenuCoreInstaller(SiraLog logger)
		{
			_logger = logger;
		}

		public override void InstallBindings()
		{
			_logger.Debug($"Running {nameof(InstallBindings)} of {nameof(MenuCoreInstaller)}");

			Container.BindViewController<NoticeBoardViewController>();
			Container.BindFlowCoordinator<NoticeBoardFlowCoordinator>();

			_logger.Debug($"Binding {nameof(SettingsControllerManager)}");
			Container.BindInterfacesAndSelfTo<SettingsControllerManager>().AsSingle().NonLazy();

			_logger.Debug($"All bindings installed in {nameof(MenuCoreInstaller)}");
		}
	}
}