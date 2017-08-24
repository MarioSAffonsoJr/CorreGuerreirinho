using UnityEngine;
using Shop;

namespace Gameplay.Player {

	public class SkinInstantiator : MonoBehaviour {

		private PlayerInventory player;
		[SerializeField] private GameObject defaultSkin;

		// Use this for initialization
		void Awake () {
			player = FindObjectOfType<PlayerInventory> ();

			if (player == null || player.equipped.prefab == null) {
				Instantiate (defaultSkin, transform.position, transform.rotation, transform.parent);
			} else {
				Instantiate (player.equipped.prefab, transform.position, transform.rotation, transform.parent);
			}

			Destroy (this);
		}
	}
}