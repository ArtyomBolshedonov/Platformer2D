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

        public bool OnGround => IsOnGround();

        public void Jump()
        {
            _rigidbody2D.AddForce(_up);
        }

        private bool IsOnGround()
        {
            bool onGround;
            if (_rigidbody2D.velocity.y == 0) { onGround = true; }
            else { onGround = false; }
            return onGround;
        }
    }
}
