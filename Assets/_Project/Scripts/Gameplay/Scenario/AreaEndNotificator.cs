using UnityEngine;

namespace Gameplay.Map {
		
	public class AreaEndNotificator : MonoBehaviour {

		private ScenarioController scenarioController;

		// Use this for initialization
		void Start () {
			scenarioController = FindObjectOfType<ScenarioController> ();
		}

		private void OnTriggerEnter2D (Collider2D collider) {
			if (!(collider.tag == "Player"))
				return;
			
			scenarioController.UpdateScenarioModules ();
		}
	}
}