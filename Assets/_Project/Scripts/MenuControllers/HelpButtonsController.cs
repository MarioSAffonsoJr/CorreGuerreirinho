using UnityEngine;
using UnityEngine.SceneManagement;
using Shop;

namespace MenuControllers {
	
	public class HelpButtonsController : MonoBehaviour {

		[SerializeField] private GameObject adConfirmationPanel;
		[SerializeField] private GameObject adRewardPanel;

		[SerializeField] private string externalInforPageURL;
		[SerializeField] private string externalDonationPageURL;

		private void Update () {
			if(Input.GetKeyDown(KeyCode.Escape)) {

				BackToMainMenu ();

			}
		}

		public void ShowConfirmAdMessage () {
			adConfirmationPanel.SetActive (true);
		}

		public void OpenExternalInfoPage () {
			Application.OpenURL (externalInforPageURL);
		}

		public void OpenExternalDonationPage () {
			Application.OpenURL (externalDonationPageURL);
		}

		public void BackToMainMenu () {
			SceneManager.LoadScene ("mainMenu");
		}

		public void GiveReward () {
			if (adRewardPanel.activeSelf) {
				adConfirmationPanel.SetActive (false);
				adRewardPanel.SetActive (false);
				FindObjectOfType<PlayerInventory> ().money += 1;
				PlayerPrefs.SetInt ("Money", FindObjectOfType<PlayerInventory>().money);
			}
		}
	}
}