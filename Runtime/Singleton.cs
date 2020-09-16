using UnityEngine;

namespace UnityBaseCode
{
    public class Singleton<T> : BaseBehaviour where T : BaseBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get {
                if (instance == null) {
                    instance = (T)FindObjectOfType(typeof(T));
                }
                return instance;
            }
        }
    }
}