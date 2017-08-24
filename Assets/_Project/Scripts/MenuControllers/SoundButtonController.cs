using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace MenuControllers {
	
	public class SoundButtonController : MonoBehaviour {

		[SerializeField] private Sprite mutedSprite;
		[SerializeField] private Sprite unmutedSprite;

		private Image muteImage;

		private bool muted;

		// Use this for initialization
		private void Start () {
			muteImage = GetComponent<Image> ();

			LoadMutedStatus ();
		}

		private void OnEnable () {
			muteImage = GetComponent<Image> ();

			LoadMutedStatus ();

			UpdateButtonSprite ();
		}

		private void LoadMutedStatus () {
			int isMuted = PlayerPrefs.GetInt ("Muted", 0);

			if (isMuted > 0)
				muted = true;
			else
				muted = false;
		}

		public void ToogleMuted () {
			if (muted) {
				muted = false;
				PlayerPrefs.SetInt ("Muted", 0);
			} else {
				muted = true;
				PlayerPrefs.SetInt ("Muted", 1);
			}

			UpdateButtonSprite ();

			FindObjectOfType<MusicController> ().UpdateMutedStatus ();
		}

		private void UpdateButtonSprite () {
			if (muted)
				muteImage.sprite = mutedSprite;
			else
				muteImage.sprite = unmutedSprite;
		}
	}
}