using System.Collections.Generic;
using UnityEngine;

namespace Shop {
	
	public class PlayerInventory : MonoBehaviour {

		public static PlayerInventory Instance;

		private void Start () {
			if (Instance == null) {
				Instance = this;
				DontDestroyOnLoad (gameObject);
			} else {
				Destroy (gameObject);
			}
		}

		public int money;

		public ItemData equipped;
		public List<ItemData> inventory = new List<ItemData>();
	}
}