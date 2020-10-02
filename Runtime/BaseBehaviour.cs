using UnityEngine;

namespace UnityBaseCode
{
    public class BaseBehaviour : MonoBehaviour
    {
        [HideInInspector]
        public int guid;

        protected virtual void Awake()
        {
            this.guid = this.gameObject.GetInstanceID();
        }
    }
}
