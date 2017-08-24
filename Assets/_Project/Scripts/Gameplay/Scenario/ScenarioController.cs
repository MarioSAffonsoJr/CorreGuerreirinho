using UnityEngine;
using DG.Tweening;
using Gameplay.UI;
using Utils;

enum Scenario {
	Day,
	Afternoon,
	Night
}

namespace Gameplay.Map {
	
	public class ScenarioController : MonoBehaviour {

		private Scenario currentScenario;

		[SerializeField] private GameObject[] mapModules;

		[SerializeField] private int scoreToChangeScenario;
		private int nextScoreGoal;
		private ScoreController score;

		private void Start () {
			currentScenario = Scenario.Day;
			score = FindObjectOfType<ScoreController> ();
			nextScoreGoal = scoreToChangeScenario;
		}

		// Update is called once per frame
		void Update () {
			if (nextScoreGoal <= score.Score) {
				ChangeScenario ();
				nextScoreGoal += scoreToChangeScenario;
			}
		}

		public void UpdateScenarioModules () {
			GameObject aux = mapModules[0];

			for (int i = 1; i < mapModules.Length; i++) {
				mapModules [i - 1] = mapModules [i];
			}

			int nextModuleId = mapModules.Length - 1;
			mapModules [nextModuleId] = aux;
			mapModules [nextModuleId].transform.position = mapModules [nextModuleId-1].transform.FindChild ("AreaEndNotificator").position;
		}

		public void ChangeScenario () {
			switch (currentScenario) {
			case Scenario.Day:
				currentScenario = Scenario.Afternoon;

				DOTween.Init ();

				for (int i = 0; i < mapModules.Length; i++) {
					mapModules[i].transform.FindChild ("fase2").GetComponent<SpriteRenderer> ().color = Color.white;
					mapModules[i].transform.FindChild ("fase1").GetComponent<SpriteRenderer> ().DOFade (0f, 1f);
				}

				break;

			case Scenario.Afternoon:
				currentScenario = Scenario.Night;

				DOTween.Init ();

				for (int i = 0; i < mapModules.Length; i++) {
					mapModules [i].transform.FindChild ("fase2").GetComponent<SpriteRenderer> ().DOFade (0f, 1f);
				}

				break;

			case Scenario.Night:
				currentScenario = Scenario.Day;

				DOTween.Init ();

				for (int i = 0; i < mapModules.Length; i++) {
					mapModules [i].transform.FindChild ("fase1").GetComponent<SpriteRenderer> ().DOFade (1f, 1f);
				}

				break;
			}
		}
	}
}