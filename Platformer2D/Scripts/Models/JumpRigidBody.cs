using UnityEngine;


namespace Platformer2D
{
    internal sealed class JumpRigidBody : IJump
    {
        private readonly PlayerObjectView _playerObjectView;
        private readonly ContactsPoller _contactsPoller;
        private const float _jumpThresh = 0.1f;

        public bool DoJump { get; set; }

        public JumpRigidBody(PlayerObjectView playerObjectView, ContactsPoller contactsPoller)
        {
            _playerObjectView = playerObjectView;
            _contactsPoller = contactsPoller;
        }

        public bool OnGround => _contactsPoller.IsGrounded;

        public void Jump()
        {
            if (OnGround && DoJump &&
              Mathf.Abs(_playerObjectView.Rigidbody2D.velocity.y) <= _jumpThresh)
            {
                _playerObjectView.Rigidbody2D.AddForce(Vector3.up * _playerObjectView.JumpForce);
            }
        }
    }
}
