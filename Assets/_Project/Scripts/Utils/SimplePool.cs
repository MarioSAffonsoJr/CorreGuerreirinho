using System.Collections.Generic;
using UnityEngine;

namespace Utils {

    public class SimplePool : MonoBehaviour {

        [SerializeField] private GameObject spawnableObject;
        [SerializeField] private float startingNumberOfClones;

        private List<GameObject> activeObjects = new List<GameObject>();

	    // Use this for initialization
	    void Start () {
		    for (int i = 0; i < startingNumberOfClones; i++)
            {
                InstantiateNewObject ();
            }
	    }
	
	    private void InstantiateNewObject () {
            GameObject newObject = (GameObject)Instantiate(spawnableObject, transform.position, transform.rotation, transform);
            newObject.GetComponent<PoolableObject>().Initialize (this);

            newObject.SetActive(false);
        }

        public void Spawn (Transform newPosition, Transform newParent) {
            if (transform.childCount > 0) {
                GameObject spawningObject = transform.GetChild(0).gameObject;
                spawningObject.transform.position = newPosition.position;
                spawningObject.transform.parent = newParent;

                activeObjects.Add (spawningObject);

                spawningObject.SetActive (true);
            } else {
                InstantiateNewObject ();
                Spawn (newPosition, newParent);
            }
        }

        public void Despawn (GameObject despawningObject) {
            int activeObjectIndex = activeObjects.IndexOf(despawningObject);

            activeObjects.RemoveAt (activeObjectIndex);

            despawningObject.SetActive(false);
            despawningObject.transform.position = transform.position;
            despawningObject.transform.rotation = transform.rotation;
            despawningObject.transform.parent = transform;
        }
    }
}