using UnityEngine;


namespace Platformer2D
{
    internal sealed class MoveRigidBody : IMove
    {
        private readonly PlayerObjectView _playerObjectView;
        private readonly ContactsPoller _contactsPoller;
        private const float _movingThresh = 0.1f;
        private float _goSideWay = 0;

        public float Speed => _playerObjectView.WalkSpeed;

        public MoveRigidBody(PlayerObjectView playerObjectView, ContactsPoller contactsPoller)
        {
            _playerObjectView = playerObjectView;
            _contactsPoller = contactsPoller;
        }

        public void Move(float horizontal, float vertical, float fixedDeltaTime)
        {
            _contactsPoller.CheckContacts();
            _goSideWay = horizontal;
            var walks = Mathf.Abs(_goSideWay) > _movingThresh;
            var newVelocity = 0.0f;
            if (walks &&
            (_goSideWay > 0 || !_contactsPoller.HasLeftContacts) &&
            (_goSideWay < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = Time.fixedDeltaTime * Speed *
                   (_goSideWay < 0 ? -1 : 1);
            }
            _playerObjectView.Rigidbody2D.velocity = _playerObjectView.Rigidbody2D.velocity.Change(
                 x: newVelocity);
        }
    }
}
