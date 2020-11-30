using System;
using System.Threading;
using System.Threading.Tasks;
using SiraUtil;
using Zenject;

namespace PCBoard.Services
{
	public class NoticeBoardDataService : IInitializable
	{
		private const string NOTICE_BOARD_DATA_URL = "http://questboard.xyz/vrnews.php/1.3.1";

		private readonly WebClient _webClient;

		internal string NoticeBoardText { get; private set; } = string.Empty;

		internal event EventHandler? NoticeBoardTextChanged;

		public NoticeBoardDataService(WebClient webClient)
		{
			_webClient = webClient;
		}

		public void Initialize()
		{
			Task.Run(async () =>
			{
				var result = await _webClient.GetAsync(NOTICE_BOARD_DATA_URL, CancellationToken.None).ConfigureAwait(false);
				if (result.IsSuccessStatusCode)
				{
					NoticeBoardText = result.ContentToString();
					NoticeBoardTextChanged?.Invoke(this, EventArgs.Empty);
				}
			});
		}
	}
}