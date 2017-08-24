using UnityEngine;

namespace Gameplay.Player {
	
	public class AnimationController : MonoBehaviour {

		private Animator animator;
		private PlayerController player;
		private Rigidbody2D rb;

		private void Start () {
			animator = GetComponentInChildren<Animator> ();
			rb = GetComponent<Rigidbody2D> ();
			player = GetComponent<PlayerController> ();
		}
		
		// Update is called once per frame
		private void Update () {
			animator.SetFloat ("ySpeed", rb.velocity.y);
			animator.SetBool ("stopped", player.Stopped);
			animator.SetBool ("grounded", player.Grounded);
		}
	}
}