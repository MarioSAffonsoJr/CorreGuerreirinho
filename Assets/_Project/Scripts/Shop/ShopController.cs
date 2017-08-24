using UnityEngine;
using UnityEngine.UI;
using MenuControllers;

namespace Shop {
	
	public class ShopController : MonoBehaviour {

		public Text moneyDisplay;

		[SerializeField] private ItemList shopList;
		private PlayerInventory player;

		[SerializeField] private Transform skinDisplaysContainer;
		[SerializeField] private GameObject skinDisplayPrefab;

		private int currentSkinEquippedIndex;

		private void Start () {
			for (int i = 0; i < shopList.itens.Length; i++) {
				int index = i;

				GameObject skinDetails = Instantiate (skinDisplayPrefab, skinDisplaysContainer) as GameObject;
				skinDetails.name = shopList.itens [i].itemId;
				Transform skinDetailsTr = skinDetails.transform;
				skinDetailsTr.GetChild (0).GetComponent<Image> ().sprite = shopList.itens [i].image;
				skinDetailsTr.GetChild (1).GetComponentInChildren<Text> ().text = shopList.itens [i].price.ToString();
				skinDetailsTr.GetChild (1).GetComponent<Button> ().onClick.AddListener (() => Buy (index));
			}

			player = FindObjectOfType<PlayerInventory> ();

			for (int i = 0; i < shopList.itens.Length; i++) {
				int index = i;

				bool inInventory = false;
				bool isEquipped = false;

				for (int j = 0; j < player.inventory.Count; j++) {
					if (shopList.itens [i] == player.inventory [j])
						inInventory = true;
				}

				if (shopList.itens [i] == player.equipped)
					isEquipped = true;

				if (inInventory) {
					Transform skinDetails = skinDisplaysContainer.GetChild (i);
					skinDetails.GetChild (1).gameObject.SetActive (false);
					skinDetails.GetChild (2).gameObject.SetActive (true);

					if (!isEquipped) {
						skinDetails.GetChild (2).GetComponentInChildren<Text>().text = "Equipar";
						skinDetails.GetChild (2).GetComponent<Button>().onClick.AddListener (() => Equip (index));
					} else {
						currentSkinEquippedIndex = i;

						skinDetails.GetChild (2).GetComponentInChildren<Text>().text = "Usando";
						skinDetails.GetChild (2).GetComponent<Button>().interactable = false;
					}
				}
			}
		}

		private void Update () {
			moneyDisplay.text = player.money.ToString();
		}

		public void Buy (int itemIndex) {
			if (player.money >= shopList.itens [itemIndex].price) {
				FindObjectOfType<StoreMenuController> ().ShowBuyConfirmationPanel (itemIndex);
			} else
				FindObjectOfType<StoreMenuController>().ShowMessagePanel ("Desculpe, mas você não tem estrelas o suficiente para comprar essa roupinha.");
		}

		public void ConfirmBuy (int itemIndex) {
			player.inventory.Add (shopList.itens [itemIndex]);
			player.money -= shopList.itens [itemIndex].price;

			PlayerPrefs.SetInt (shopList.itens [itemIndex].itemId, 1);
			PlayerPrefs.SetInt ("Money", player.money);

			Transform skinDetails = skinDisplaysContainer.GetChild (itemIndex);
			skinDetails.GetChild (1).gameObject.SetActive (false);
			skinDetails.GetChild (2).gameObject.SetActive (true);

			skinDetails.GetChild (2).GetComponentInChildren<Text>().text = "Equipar";
			skinDetails.GetChild (2).GetComponent<Button>().onClick.AddListener (() => Equip (itemIndex));
		}

		public void Equip (int itemIndex) {
			int previousEquippedItem = currentSkinEquippedIndex;

			player.equipped = shopList.itens [itemIndex];
			currentSkinEquippedIndex = itemIndex;

			PlayerPrefs.GetString ("Equipped", shopList.itens [itemIndex].itemId);

			Transform skinDetails = skinDisplaysContainer.GetChild (previousEquippedItem);
			skinDetails.GetChild (2).GetComponentInChildren<Text>().text = "Equipar";
			skinDetails.GetChild (2).GetComponent<Button>().onClick.AddListener (() => Equip (previousEquippedItem));
			skinDetails.GetChild (2).GetComponent<Button>().interactable = true;

			skinDetails = skinDisplaysContainer.GetChild (currentSkinEquippedIndex);
			skinDetails.GetChild (2).GetComponentInChildren<Text>().text = "Usando";
			skinDetails.GetChild (2).GetComponent<Button>().onClick.RemoveAllListeners ();
			skinDetails.GetChild (2).GetComponent<Button>().interactable = false;
		}
	}
}