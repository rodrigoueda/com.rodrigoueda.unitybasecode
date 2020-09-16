using UnityEngine;

namespace UnityBaseCode
{
    public class BaseBehaviour : MonoBehaviour
    {
        [HideInInspector]
        public string guid;

        protected virtual void Awake()
        {
            this.guid = System.Guid.NewGuid().ToString();
        }
    }
}
