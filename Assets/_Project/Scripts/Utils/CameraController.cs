using UnityEngine;
using Gameplay.Player;

namespace Utils {
	
	public class CameraController : MonoBehaviour {

		[SerializeField] private float cameraLeftMargin;

		private Transform playerTr;
		private PlayerController player;

		private Transform tr;
		private Transform targetPosition;

		void Start () {
			tr = transform;
			playerTr = FindObjectOfType<PlayerController> ().transform;
			targetPosition = transform.GetChild (0);
		}

		private void Update () {
			tr.Translate (new Vector3 (playerTr.position.x - targetPosition.position.x, 0, 0));
		}
	}
}