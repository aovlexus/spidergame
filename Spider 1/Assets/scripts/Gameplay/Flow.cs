using UnityEngine;

namespace Gameplay
{
    public class Flow : MonoBehaviour
    {
        public float flowSpeed = 4f;
        public Vector3 flowDirection = new Vector3(1, 0, 0);
        public float stabiltyForceFactor = 1f;

        private void Stabilize(Collider2D collision)
        {
            var stabilityForce = (
                1 - Mathf.Abs(Vector3.Dot(
                     collision.attachedRigidbody.velocity.normalized,
                     flowDirection.normalized
                 ))
                ) * stabiltyForceFactor;

            collision.attachedRigidbody.AddForce(
                -collision.attachedRigidbody.velocity * stabilityForce,
                ForceMode2D.Force
            );

        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            Stabilize(collision);
            collision.attachedRigidbody.AddForce(
                flowDirection * flowSpeed,
                ForceMode2D.Force
            );
        }
    }
}
