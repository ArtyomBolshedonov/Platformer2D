using UnityEngine;


namespace Platformer2D
{
    internal sealed class MovementController : IExecute
    {
        private readonly PlayerObjectView _playerObjectView;
        private readonly ContactsPoller _contactsPoller;
        private readonly MoveRigidBody _moveRigidBody;
        private readonly JumpRigidBody _jumpRigidBody;

        public MovementController(PlayerObjectView playerObjectView)
        {
            _playerObjectView = playerObjectView;
            _contactsPoller = new ContactsPoller(_playerObjectView.Collider2D);
            _moveRigidBody = new MoveRigidBody(_playerObjectView, _contactsPoller);
            _jumpRigidBody = new JumpRigidBody(_playerObjectView, _contactsPoller);
        }

        public void Execute(float fixedDeltaTime)
        {
            _moveRigidBody.Move(Input.GetAxis(InputManager.HORIZONTAL), 0, fixedDeltaTime);
            _jumpRigidBody.DoJump = Input.GetButton(InputManager.JUMP);
            _jumpRigidBody.Jump();
        }
    }
}
