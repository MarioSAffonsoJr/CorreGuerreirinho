using UnityEngine;

namespace Utils {
	
	public class ObstacleDespawner : MonoBehaviour {

		private void OnTriggerEnter2D (Collider2D coll) {
			if (coll.tag == "Obstacle") {
				coll.transform.GetComponent<PoolableObject> ().Despawn ();
			}

			if (coll.tag == "Pickup") {
				Destroy (coll.gameObject);
			}
		}
	}
}