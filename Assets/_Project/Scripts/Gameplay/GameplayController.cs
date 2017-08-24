using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Gameplay.Player;
using Gameplay.UI;
using Utils;
using Shop;

namespace Gameplay {
	
	public class GameplayController : MonoBehaviour {

		[SerializeField] private GameObject touchIconPanel;
		[SerializeField] private GameObject getReadyCounterPanel;
		[SerializeField] private GameObject pauseMenuPanel;
		[SerializeField] private GameObject defeatMenuPanel;
		[SerializeField] private GameObject adConfirmationPanel;
		[SerializeField] private GameObject adRewardPanel;

		[SerializeField] private Transform spawnPosition;

		[SerializeField] private float minObstacleSpawnDistance;
		[SerializeField] private float maxObstacleSpawnDistance;

		[SerializeField] private SimplePool[] obstacles;

		private float lastObstacleSpawnPosition;
		private float distanceToSpawnNextObstacle;

		private Transform playerTr;

		private bool continueUsed = false;

		public bool ContinueUsed { get { return continueUsed; } }

		// Use this for initialization
		private void Start () {
			playerTr = FindObjectOfType<PlayerController> ().transform;

			GenerateNextSpawnDistance ();

			touchIconPanel.SetActive (true);
			getReadyCounterPanel.SetActive (false);
			pauseMenuPanel.SetActive (false);
			defeatMenuPanel.SetActive (false);
			adConfirmationPanel.SetActive (false);
			adRewardPanel.SetActive (false);

			Time.timeScale = 0;
		}
		
		// Update is called once per frame
		private void Update () {
			if (playerTr.position.x > lastObstacleSpawnPosition + distanceToSpawnNextObstacle) {
				SpawnNextObstacle ();

				lastObstacleSpawnPosition = playerTr.position.x;
				GenerateNextSpawnDistance ();
			}
		}

		private void GenerateNextSpawnDistance () {
			distanceToSpawnNextObstacle = Random.Range (minObstacleSpawnDistance, maxObstacleSpawnDistance);
		}

		private void SpawnNextObstacle () {
			int nextObstacleId = Random.Range (0, obstacles.Length);

			obstacles [nextObstacleId].Spawn (spawnPosition, null);
		}

		public void StartCountdown () {
			touchIconPanel.SetActive (false);
			pauseMenuPanel.SetActive (false);
			defeatMenuPanel.SetActive (false);
			adConfirmationPanel.SetActive (false);
			adRewardPanel.SetActive (false);

			getReadyCounterPanel.SetActive (true);
		}

		public void ResumeGame () {
			getReadyCounterPanel.SetActive (false);
			FindObjectOfType<PlayerController> ().StartWalking ();

			Time.timeScale = 1;
		}

		public void PauseGame () {
			pauseMenuPanel.SetActive (true);

			Time.timeScale = 0;
		}

		public void RestartGame () {
			SceneManager.LoadScene ("game");
		}

		public void BackToMainMenu () {
			SceneManager.LoadScene ("mainMenu");
		}

		public void ExitGame () {
			Application.Quit ();
		}

		public void ShowDefeatMenu (int score) {
			if (PlayerPrefs.GetInt("HighScore", 0) < score)
				PlayerPrefs.SetInt ("HighScore", score);
			
			defeatMenuPanel.SetActive (true);
			defeatMenuPanel.transform.FindChild ("ScoreText").GetComponent<Text> ().text = FindObjectOfType<ScoreController> ().Score.ToString ();
			defeatMenuPanel.transform.FindChild ("StarDisplay").GetComponent<Text> ().text = FindObjectOfType<PlayerInventory> ().money.ToString ();
		}

		public void ShowAdConfirmationPanel () {
			adConfirmationPanel.SetActive (true);
		}

		public void UseContinue () {
			continueUsed = true;
			StartCountdown ();
		}
	}
}