using UnityEngine;

namespace Shop {
	
	[CreateAssetMenu(fileName = "NewItemList", menuName = "Inventory/New Item List", order = 2)]
	public class ItemList : ScriptableObject {

		public ItemData[] itens;
	}
}