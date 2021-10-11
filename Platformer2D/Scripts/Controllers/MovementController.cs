using UnityEngine;


namespace Platformer2D
{
    internal sealed class MovementController : IExecute
    {
        private readonly ObjectView _objectView;
        private readonly MoveTransform _moveTransform;
        private readonly JumpTransform _jumpTransform;

        public MovementController(ObjectView objectView, float speed, float jumpforce)
        {
            _objectView = objectView;
            _moveTransform = new MoveTransform(_objectView.gameObject, speed);
            _jumpTransform = new JumpTransform(_objectView.gameObject, jumpforce);
        }

        public void Execute(float deltaTime)
        {
            _moveTransform.Move(Input.GetAxis(InputManager.HORIZONTAL), 0, deltaTime);
            Jump();
        }

        private void Jump()
        {
            _jumpTransform.DoJump = Input.GetButtonDown(InputManager.JUMP);
            _jumpTransform.Jump();
            _objectView.YVelocity = _jumpTransform.YVelocity;
        }
    }
}
