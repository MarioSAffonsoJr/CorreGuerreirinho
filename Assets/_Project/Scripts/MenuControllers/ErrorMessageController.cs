using UnityEngine;
using UnityEngine.UI;

namespace MenuControllers {
	
	public class ErrorMessageController : MonoBehaviour {

		public static ErrorMessageController main;

		public GameObject errorMessagePanel;
		public Text errorMessageText;

		private void Start () {
			main = this;
		}

		public void ShowErrorMessage (string message, string error) {
			errorMessagePanel.SetActive (true);
			errorMessageText.text = message + "\n" + error;
		}
	}
}