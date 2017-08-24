using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.UI {
	
	public class TouchIconController : MonoBehaviour {

		[SerializeField] private Sprite[] sprites;
		[SerializeField] private float changingSpriteInterval;

		[SerializeField] private GameplayController gameplayController;

		private Image image;
		private float lastTimeSpriteChanged;
		private int currentSpriteId;

		private void Start () {
			image = GetComponent<Image> ();
			currentSpriteId = 0;
			image.sprite = sprites [currentSpriteId];
			lastTimeSpriteChanged = Time.realtimeSinceStartup;
		}

		private void Update () {
			if (lastTimeSpriteChanged + changingSpriteInterval < Time.realtimeSinceStartup) {
				currentSpriteId++;

				if (currentSpriteId >= sprites.Length)
					currentSpriteId = 0;
				
				image.sprite = sprites [currentSpriteId];
				lastTimeSpriteChanged = Time.realtimeSinceStartup;
			}

			if (Input.GetMouseButtonDown (0)) {
				gameplayController.StartCountdown ();
			}
		}
	}
}