using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI {

	public class GetReadyCounterController : MonoBehaviour {

		[SerializeField] private int numberCounterStartsFrom;

		[SerializeField] private GameplayController gameplayController;

		private Text counterText;
		private float lastTimeCounterChanged;
		private const float changingCounterInterval = 1f;
		private int counter;

		private void OnEnable () {
			counterText = GetComponent<Text> ();
			counter = numberCounterStartsFrom;
			counterText.text = counter.ToString ();
			lastTimeCounterChanged = Time.realtimeSinceStartup;
		}

		private void Update () {
			if (lastTimeCounterChanged + changingCounterInterval < Time.realtimeSinceStartup) {
				counter--;

				if (counter > 0) {
					counterText.text = counter.ToString ();
					lastTimeCounterChanged = Time.realtimeSinceStartup;
				} else
					gameplayController.ResumeGame ();
			}
		}
	}
}