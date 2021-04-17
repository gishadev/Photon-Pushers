using UnityEngine;

namespace Gisha.Pushers.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;

        Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Vector3 angularInput = new Vector3(-Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
            _rb.angularVelocity = angularInput * movementSpeed;
        }
    }
}