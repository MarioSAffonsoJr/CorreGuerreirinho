using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils {
	
	public class MusicController : MonoBehaviour {

		[SerializeField] private AudioClip menusMusic;
		[SerializeField] private AudioClip gameMusic;

		private string currentSceneType;

		private AudioSource audioSource;

		private bool muted;

		// Use this for initialization
		private void Awake () {
			if (FindObjectsOfType<MusicController> ().Length > 1)
				Destroy (gameObject);
			else
				DontDestroyOnLoad (gameObject);
		}

		private void Start () {
			audioSource = GetComponent<AudioSource> ();

			SetAudioByScene ();

			if (SceneManager.GetActiveScene ().name != "game") {
				currentSceneType = "menu";
				audioSource.clip = menusMusic;
			} else {
				currentSceneType = "game";
				audioSource.clip = gameMusic;
			}

			LoadMutedStatus ();

			UpdateMutedStatus ();

			SceneManager.activeSceneChanged += OnSceneChanged;
		}
		
		private void OnSceneChanged (Scene scene1, Scene scene2) {
			SetAudioByScene ();
		}

		private void SetAudioByScene () {
			if (SceneManager.GetActiveScene ().name != "game") {
				if (currentSceneType != "menu") {
					audioSource.Stop ();
					audioSource.clip = menusMusic;
					currentSceneType = "menu";
					if (!muted) {
						audioSource.Play ();
					}
				}
			} else {
				if (currentSceneType != "game") {
					audioSource.Stop ();
					audioSource.clip = gameMusic;
					currentSceneType = "game";
					if (!muted) {
						audioSource.Play ();
					}
				}
			}
		}

		private void LoadMutedStatus () {
			int isMuted = PlayerPrefs.GetInt ("Muted", 0);

			if (isMuted > 0)
				muted = true;
			else
				muted = false;
		}

		public void UpdateMutedStatus () {
			LoadMutedStatus ();

			if (muted)
				audioSource.Stop ();
			else
				audioSource.Play ();
		}
	}
}