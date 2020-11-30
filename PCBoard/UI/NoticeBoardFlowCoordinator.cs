using System;
using BeatSaberMarkupLanguage;
using HMUI;
using SiraUtil.Tools;
using Zenject;

namespace PCBoard.UI
{
	internal class NoticeBoardFlowCoordinator : FlowCoordinator
	{
		private SiraLog _logger = null!;
		private NoticeBoardViewController _noticeBoardViewController = null!;

		[Inject]
		internal void Construct(SiraLog siraLog, NoticeBoardViewController noticeBoardViewController)
		{
			_logger = siraLog;
			_noticeBoardViewController = noticeBoardViewController;
		}

		protected override void DidActivate(bool firstActivation, bool addedToHierarchy, bool screenSystemEnabling)
		{
			try
			{
				if (firstActivation)
				{
					SetTitle("Notice board");
					showBackButton = true;
					ProvideInitialViewControllers(_noticeBoardViewController);
				}
			}
			catch (Exception ex)
			{
				_logger.Error(ex);
			}
		}

		protected override void BackButtonWasPressed(ViewController _)
		{
			// Dismiss ourselves
			BeatSaberUI.MainFlowCoordinator.DismissFlowCoordinator(this);
		}
	}
}