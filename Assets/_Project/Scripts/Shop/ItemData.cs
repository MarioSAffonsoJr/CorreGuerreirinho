using UnityEngine;

namespace Shop {
	
	[CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/New Item", order = 1)]
	public class ItemData : ScriptableObject {

		public string itemId;

		public Sprite image;

		public int price;

		public GameObject prefab;
	}
}