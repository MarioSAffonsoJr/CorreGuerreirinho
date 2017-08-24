using UnityEngine;
using UnityEngine.SceneManagement;

namespace MenuControllers {
	
	public class MainMenuController : MonoBehaviour {

		[SerializeField] private GameObject creditsPanel;
		[SerializeField] private GameObject highScorePanel;

		private void Update () {
			if(Input.GetKeyDown(KeyCode.Escape)) {

				Application.Quit();

			}
		}

		public void Play () {
			SceneManager.LoadScene ("game");
		}

		public void GoToStore () {
			SceneManager.LoadScene ("store");
		}

		public void GoToAbout () {
			SceneManager.LoadScene ("about");
		}

		public void GoToHelp () {
			SceneManager.LoadScene ("help");
		}

		public void ShowCredits () {
			creditsPanel.SetActive (true);
		}

		public void CloseCredits () {
			creditsPanel.SetActive (false);
		}

		public void ShowHighScore () {
			highScorePanel.SetActive (true);
		}

		public void CloseHighScore () {
			highScorePanel.SetActive (false);
		}
	}
}