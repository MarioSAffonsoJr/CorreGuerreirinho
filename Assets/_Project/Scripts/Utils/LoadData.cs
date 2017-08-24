using UnityEngine;
using Shop;

namespace Utils {
	
	public class LoadData : MonoBehaviour {

		[SerializeField] private ItemList itemList;

		// Use this for initialization
		private void Start () {
			PlayerInventory player = FindObjectOfType<PlayerInventory> ();

			if (player.money > 0)
				return;

			player.money = PlayerPrefs.GetInt ("Money", 0);

			for (int i = 0; i < itemList.itens.Length; i++) {
				if (PlayerPrefs.GetInt (itemList.itens [i].name, 0) == 1) {
					player.inventory.Add(itemList.itens[i]);

					if (itemList.itens [i].name == PlayerPrefs.GetString ("Equipped", "NORMAL")) {
						player.equipped = itemList.itens [i];
					}
				}
			}
		}
	}
}