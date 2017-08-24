using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI {
	
	public class ContinueButtonController : MonoBehaviour {

		[SerializeField] private GameplayController gameplayController;
		private Button continueButton;

		// Use this for initialization
		private void Awake () {
			continueButton = GetComponent<Button> ();
		}
		
		private void OnEnable () {
			if (gameplayController.ContinueUsed) {
				continueButton.interactable = false;
			} else {
				continueButton.interactable = true;
			}
		}
	}
}