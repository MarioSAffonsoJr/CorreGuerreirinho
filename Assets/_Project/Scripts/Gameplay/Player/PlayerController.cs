using UnityEngine;
using Gameplay.UI;
using Utils;

namespace Gameplay.Player {
	
	public class PlayerController : MonoBehaviour {

		[SerializeField] private float speed;

		[SerializeField] private int scoreToSpeedUp;
		[SerializeField] private float speedUpAmount;

		private int lastSpeedUpScoreReached = 0;
		private ScoreController score;

		[SerializeField] private float jumpSpeed;

		[SerializeField] private Transform groundChecker;
		[SerializeField] private LayerMask groundLayer;

		private bool stopped;
		public bool Stopped { get { return stopped; } }

		private bool grounded;
		public bool Grounded { get { return grounded; } }

		private Transform tr;
		private Rigidbody2D rb;

		// Use this for initialization
		private void Start () {
			tr = transform;
			rb = GetComponent<Rigidbody2D> ();
			stopped = true;
			score = FindObjectOfType<ScoreController> ();
		}
		
		// Update is called once per frame
		private void Update () {
			if (!stopped)
				Walk ();

			// Check if is touching the ground
			if (Physics2D.OverlapCircle (groundChecker.position, 0.05f, groundLayer) != null)
				grounded = true;
			else
				grounded = false;

			CheckScore ();
		}

		private void OnCollisionEnter2D (Collision2D coll) {
			if (coll.gameObject.tag == "Obstacle") {
				StopWalking ();
				coll.gameObject.GetComponent<PoolableObject> ().Despawn ();
				FindObjectOfType<GameplayController> ().ShowDefeatMenu (score.Score);
			}
		}

		private void Walk () {
			tr.Translate (Vector3.right * speed * Time.deltaTime);
		}

		public void CheckJump () {
			if (grounded) {
				Jump ();
			}
		}

		private void Jump () {
			rb.velocity = Vector2.up * jumpSpeed;
		}

		public void StartWalking () {
			stopped = false;
		}

		private void StopWalking () {
			stopped = true;
		}

		private void CheckScore () {
			if (score.Score > lastSpeedUpScoreReached + scoreToSpeedUp) {
				speed += speedUpAmount;
				lastSpeedUpScoreReached += scoreToSpeedUp;
			}
		}
	}
}