using UnityEngine;
using UnityEngine.UI;

namespace MenuControllers {
	
	public class HighScoreDisplay : MonoBehaviour {

		[SerializeField] private Text highScoreText;

		private void OnEnable () {
			highScoreText.text = PlayerPrefs.GetInt ("HighScore", 0).ToString();
		}
	}
}