using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuControllers {
	
	public class AboutButtonsController : MonoBehaviour {

		[SerializeField] private string externalInforPageURL;

		private void Update () {
			if(Input.GetKeyDown(KeyCode.Escape)) {

				BackToMainMenu ();

			}
		}

		public void OpenExternalInfoPage () {
			Application.OpenURL (externalInforPageURL);
		}

		public void BackToMainMenu () {
			SceneManager.LoadScene ("mainMenu");
		}
	}
}