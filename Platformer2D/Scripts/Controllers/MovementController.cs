using UnityEngine;


namespace Platformer2D
{
    internal sealed class MovementController : IExecute
    {
        private GameObject _gameObject;
        private Rigidbody2D _rigidbody2D;
        private MoveTransform _moveTransform;
        private JumpRigidBody _jumpRigidBody;

        public MovementController(GameObject gameObject, float speed, float jumpforce)
        {
            _gameObject = gameObject;
            _rigidbody2D = _gameObject.GetComponent<Rigidbody2D>();
            _moveTransform = new MoveTransform(_gameObject, speed);
            _jumpRigidBody = new JumpRigidBody(_rigidbody2D, jumpforce);
        }

        public void Execute(float deltaTime)
        {
            _moveTransform.Move(Input.GetAxis(InputManager.HORIZONTAL), 0, Time.deltaTime);
            Jump();
        }

        private void Jump()
        {
            if (Input.GetButtonDown(InputManager.JUMP) && OnGround())
            {
                _jumpRigidBody.Jump();
            }
        }

        private bool OnGround()
        {
            bool onGround;
            if (_rigidbody2D.velocity.y != 0) { onGround = false; }
            else { onGround = true; }
            return onGround;
        }
    }
}
