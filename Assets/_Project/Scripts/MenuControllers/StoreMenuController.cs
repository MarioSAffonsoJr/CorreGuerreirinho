using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Shop;

namespace MenuControllers {
	
	public class StoreMenuController : MonoBehaviour {

		[SerializeField] private GameObject adConfirmationPanel;
		[SerializeField] private GameObject adRewardPanel;
		[SerializeField] private GameObject buyConfirmationPanel;
		[SerializeField] private GameObject messagePanel;

		[SerializeField] private int starsRewardedPerAd;

		private int itemToBeBought = 0;

		private void Start () {
			adConfirmationPanel.SetActive (false);
			adRewardPanel.SetActive (false);
			buyConfirmationPanel.SetActive (false);
		}

		private void Update () {
			if(Input.GetKeyDown(KeyCode.Escape)) {

				BackToMainMenu ();

			}
		}

		public void ShowAdConfirmationPanel () {
			adConfirmationPanel.SetActive (true);
		}

		public void CancelAdPanel () {
			adConfirmationPanel.SetActive (false);
		}

		public void GiveAdReward () {
			if (adRewardPanel.activeSelf) {
				adConfirmationPanel.SetActive (false);
				adRewardPanel.SetActive (false);
				FindObjectOfType<PlayerInventory> ().money += starsRewardedPerAd;
				PlayerPrefs.SetInt ("Money", FindObjectOfType<PlayerInventory>().money);
			}
		}

		public void ShowBuyConfirmationPanel (int itemIndex) {
			buyConfirmationPanel.SetActive (true);
			itemToBeBought = itemIndex;
		}

		public void ConfirmBuy () {
			buyConfirmationPanel.SetActive (false);

			FindObjectOfType<ShopController> ().ConfirmBuy (itemToBeBought);
		}

		public void CancelBuyPanel () {
			buyConfirmationPanel.SetActive (false);
			itemToBeBought = 0;
		}

		public void ShowMessagePanel (string message) {
			messagePanel.SetActive (true);
			messagePanel.GetComponentInChildren<Text> ().text = message;
		}

		public void CloseMessagePanel () {
			messagePanel.SetActive (false);
		}

		public void BackToMainMenu () {
			SceneManager.LoadScene ("mainMenu");
		}
	}
}