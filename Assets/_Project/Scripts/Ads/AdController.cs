using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System;
using MenuControllers;

namespace Ads {
	
	public class AdController : MonoBehaviour {

		public GameObject rewardPanel;

		public void ShowAd () {
			try {
				if (Advertisement.IsReady ("rewardedVideo")) {
					ShowOptions options = new ShowOptions { resultCallback = OnShowResult };
					Advertisement.Show ("rewardedVideo", options);
				}	
			} catch (Exception e) {
				ErrorMessageController.main.ShowErrorMessage ("Desculpe, houve um erro ao tentar exibir o anúncio.", e.ToString ());
			}
		}

		// Fecha a mensagem de confirmação
		public void CancelAd () {
			gameObject.SetActive (false);
		}

		public void OnShowResult (ShowResult result) {
			switch (result) {
			case ShowResult.Finished:
				rewardPanel.SetActive (true);
				break;
			case ShowResult.Skipped:
				ErrorMessageController.main.ShowErrorMessage ("Desculpe, houve um erro ao tentar exibir o anúncio.", "");
				break;
			case ShowResult.Failed:
				ErrorMessageController.main.ShowErrorMessage ("Desculpe, houve um erro ao tentar exibir o anúncio.", "");
				break;
			}
		}
	}
}