using Photon.Pun;
using UnityEngine;

namespace Gisha.Pushers.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed;

        Rigidbody _rb;
        PhotonView _pv;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _pv = GetComponent<PhotonView>();
        }

        private void Update()
        {
            if (!_pv.IsMine)
                return;

            Vector3 angularInput = new Vector3(-Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
            _rb.angularVelocity = angularInput * movementSpeed;
        }
    }
}