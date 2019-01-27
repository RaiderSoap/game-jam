namespace Assets.Scripts
{
    using System.Collections.Generic;

    using UnityEngine;
    using System;

    public class DynamicCameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform playerA = null;

        [SerializeField]
        private Transform playerB = null;

        [SerializeField]
        private Transform playerC = null;
        [SerializeField]
        private Transform playerD = null;

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
                this.points.Add(this.playerC);
                this.points.Add(this.playerD);
        }

        private void LateUpdate()
        {
            var delta = Math.Max(Vector3.Distance(this.playerA.position, this.playerB.position), Vector3.Distance(this.playerA.position, this.playerC.position));
            delta = Math.Max(delta, Vector3.Distance(this.playerA.position, this.playerD.position));
            delta = Math.Max(delta, Vector3.Distance(this.playerB.position, this.playerC.position));
            delta = Math.Max(delta, Vector3.Distance(this.playerB.position, this.playerD.position));
            delta = Math.Max(delta, Vector3.Distance(this.playerC.position, this.playerD.position));

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