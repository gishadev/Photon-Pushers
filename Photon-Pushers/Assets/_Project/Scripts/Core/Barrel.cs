using System.Linq;
using UnityEngine;

namespace Gisha.Pushers.Core
{
    public class Barrel : MonoBehaviour
    {
        [SerializeField] private float explosionForce;
        [SerializeField] private float explosionRadius;
        [SerializeField] private GameObject explosionPrefab;

        private void Explode()
        {
            var rigidbodies = FindObjectsOfType<PlayerMovement>()
                .Select(x => x.GetComponent<Rigidbody>())
                .ToArray();

            foreach (var rb in rigidbodies)
            {
                var direction = rb.transform.position - transform.position;

                if (direction.magnitude < explosionRadius)
                    rb.AddForce(direction.normalized * explosionForce);
            }

            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Player"))
                Explode();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, explosionRadius);
        }
    }
}
