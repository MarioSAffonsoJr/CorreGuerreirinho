using UnityEngine;

namespace Utils {

    public class PoolableObject : MonoBehaviour {

        private SimplePool objectPool;

        public void Initialize (SimplePool pool) {
            objectPool = pool;
        }

        public void Despawn () {
            objectPool.Despawn (gameObject);
        }
    }
}