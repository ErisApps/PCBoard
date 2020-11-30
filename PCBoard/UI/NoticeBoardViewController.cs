using System;
using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.Components;
using BeatSaberMarkupLanguage.ViewControllers;
using PCBoard.Services;
using Zenject;

namespace PCBoard.UI
{
	[HotReload(RelativePathToLayout = @"Views\NoticeBoard.bsml")]
	[ViewDefinition("PCBoard.UI.Views.NoticeBoard.bsml")]
	internal class NoticeBoardViewController : BSMLAutomaticViewController
	{
		private NoticeBoardDataService _noticeBoardDataService = null!;

		[Inject]
		internal void Construct(NoticeBoardDataService noticeBoardDataService)
		{
			_noticeBoardDataService = noticeBoardDataService;

			NoticeBoardText = _noticeBoardDataService.NoticeBoardText;
			_noticeBoardDataService.NoticeBoardTextChanged += OnNoticeBoardTextChanged;
		}

		[UIComponent("noticeboard-scrollcontainer")]
		private BSMLScrollableContainer _scrollableContainer = null!;

		[UIValue("noticeboard-text")]
		internal string NoticeBoardText { get; private set; } = string.Empty;

		private void OnNoticeBoardTextChanged(object sender, EventArgs _)
		{
			NoticeBoardText = _noticeBoardDataService.NoticeBoardText;

			_scrollableContainer.ComputeScrollFocusPosY();
			_scrollableContainer.RefreshButtons();
		}
	}
}