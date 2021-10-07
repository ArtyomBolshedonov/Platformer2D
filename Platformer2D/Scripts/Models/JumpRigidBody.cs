using UnityEngine;


namespace Platformer2D
{
    internal sealed class JumpRigidBody : IJump
    {
        private readonly Rigidbody2D _rigidbody2D;
        private Vector2 _up;

        public JumpRigidBody(Rigidbody2D rigidbody2D, float jumpForce)
        {
            _rigidbody2D = rigidbody2D;
            _up = new Vector2(0, jumpForce);
        }
        public void Jump()
        {
            _rigidbody2D.AddForce(_up);
        }
    }
}
