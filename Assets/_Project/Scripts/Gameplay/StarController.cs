using UnityEngine;
using Shop;

namespace Gameplay {
	
	public class StarController : MonoBehaviour {

		[SerializeField] private GameObject pickupEffect;

		private void OnTriggerEnter2D (Collider2D coll) {
			if (coll.tag == "Player") {
				FindObjectOfType<PlayerInventory> ().money++;
				PlayerPrefs.SetInt ("Money", FindObjectOfType<PlayerInventory>().money);
				GameObject effect = Instantiate (pickupEffect, transform.position, transform.rotation) as GameObject;
				Destroy (gameObject); 
				Destroy (effect, 1f);
			}
		}
	}
}