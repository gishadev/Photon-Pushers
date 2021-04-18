using Photon.Pun;
using UnityEngine;

namespace Gisha.Pushers.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement")]
        [SerializeField] private float movementSpeed;

        [Header("Push")]
        [SerializeField] private float pushMagnitude;
        [SerializeField] private float raycastDst;

        Vector3 _angularInput;
        Vector3 _pushInput;

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

            Move();
            CheckForPush();
        }

        private void Move()
        {
            _angularInput = new Vector3(-Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
            _rb.angularVelocity = _angularInput * movementSpeed;
        }

        private void CheckForPush()
        {
            _pushInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical")).normalized;
            _pushInput *= -1f;

            if (Physics.Raycast(transform.position, _pushInput, out RaycastHit hitInfo, raycastDst))
            {
                if (hitInfo.collider.CompareTag("Player"))
                {
                    var pv = hitInfo.collider.GetComponent<PhotonView>();

                    if (!pv.IsMine)
                    {
                        var pushForce = _pushInput * pushMagnitude;
                        pv.RPC("PushMe", RpcTarget.All, pushForce);
                    }
                }
            }
        }

        [PunRPC]
        private void PushMe(Vector3 pushForce)
        {
            _rb.AddForce(pushForce);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, _pushInput * raycastDst);
        }
    }
}