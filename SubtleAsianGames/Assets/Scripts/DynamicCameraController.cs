namespace Assets.Scripts
{
    using System.Collections.Generic;

    using UnityEngine;

    public class DynamicCameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform playerA = null;

        [SerializeField]
        private Transform playerB = null;

        [SerializeField]
        [Range(0.1f, 1.0f)]
        private float scale = 1.0f;

        private Vector3 offset;

        private List<Transform> points = new List<Transform>();

        #region Unity Callbacks

        private void Start()
        {
            this.offset = this.transform.position - this.playerA.position;

            if (this.playerA != null)
            {
                this.points.Add(this.playerA);
            }

            if (this.playerB != null)
            {
                this.points.Add(this.playerB);
            }
        }

        private void LateUpdate()
        {
            var delta = Vector3.Distance(this.playerA.position, this.playerB.position);

            // Finding the midpoint
            Vector3 sum = Vector3.zero;
            foreach (var point in this.points)
            {
                sum += point.position;
            }
            sum /= this.points.Count;
            sum.z = -10;

            Camera.main.transform.SetPositionAndRotation(sum, Quaternion.identity);
            Camera.main.orthographicSize = delta * this.scale;
        }

        #endregion
    }
}