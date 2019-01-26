namespace Assets.Scripts
{
    using UnityEngine;

    public class DynamicCameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform playerA;

        private Vector3 offset;

        #region Unity Callbacks

        private void Start()
        {
            this.offset = this.transform.position - this.playerA.position;
        }

        private void LateUpdate()
        {
            this.transform.position = this.playerA.transform.position + this.offset;
        }

        #endregion
    }
}