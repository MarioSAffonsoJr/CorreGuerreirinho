using UnityEngine;
using Gameplay.UI;

namespace Gameplay {
	
	public class StarSpawnController : MonoBehaviour {

		[SerializeField] private int scoreToSpawnStar;
		[SerializeField] private Transform starSpawnPosition;
		[SerializeField] private GameObject starPrefab;

		private int lastScoreStarSpawned;

		private ScoreController score;

		// Use this for initialization
		private void Start () {
			score = FindObjectOfType<ScoreController> ();
			lastScoreStarSpawned = 0;
		}
		
		// Update is called once per frame
		private void Update () {
			if (score.Score >= lastScoreStarSpawned + scoreToSpawnStar) {
				SpawnStar ();
				lastScoreStarSpawned += scoreToSpawnStar;
			}
		}

		private void SpawnStar () {
			Instantiate (starPrefab, starSpawnPosition.position, starSpawnPosition.rotation);
		}
	}
}