using System;
using BeatSaberMarkupLanguage;
using BeatSaberMarkupLanguage.MenuButtons;
using Zenject;

namespace PCBoard.UI
{
	internal class SettingsControllerManager : IInitializable, IDisposable
	{
		private readonly NoticeBoardFlowCoordinator _noticeBoardFlowCoordinator;
		private MenuButton? _noticeBoardButton;

		[Inject]
		public SettingsControllerManager(NoticeBoardFlowCoordinator noticeBoardFlowCoordinator)
		{
			_noticeBoardFlowCoordinator = noticeBoardFlowCoordinator;
			_noticeBoardButton = new MenuButton("Notice board", "Read up on the latest news.", OnClick);
		}

		public void Initialize()
		{
			MenuButtons.instance.RegisterButton(_noticeBoardButton);
		}

		public void Dispose()
		{
			if (_noticeBoardButton == null)
			{
				return;
			}

			if (MenuButtons.IsSingletonAvailable)
			{
				MenuButtons.instance.UnregisterButton(_noticeBoardButton);
			}

			_noticeBoardButton = null!;
		}

		private void OnClick()
		{
			if (_noticeBoardFlowCoordinator == null)
			{
				return;
			}

			BeatSaberUI.MainFlowCoordinator.PresentFlowCoordinator(_noticeBoardFlowCoordinator);
		}
	}
}