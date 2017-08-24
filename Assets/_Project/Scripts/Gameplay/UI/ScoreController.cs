using UnityEngine;
using UnityEngine.UI;
using Gameplay.Player;

namespace Gameplay.UI {
	
	public class ScoreController : MonoBehaviour {

		[SerializeField] private Text scoreText;

		private int score;

		public int Score { get { return score; } }

		private Transform playerTr;

		// Use this for initialization
		private void Start () {
			playerTr = FindObjectOfType<PlayerController> ().transform;
		}
		
		// Update is called once per frame
		private void Update () {
			score = (int) playerTr.position.x / 5;
			scoreText.text = score.ToString ("0");
		}
	}
}