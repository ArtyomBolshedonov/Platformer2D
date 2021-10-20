namespace Platformer2D
{
    internal sealed class AnimationStateController : IExecute
    {
        private readonly SpriteAnimationController _spriteAnimationController;
        private readonly ObjectView _playerObjectView;
        private readonly ContactsPoller _contactsPoller;

        public AnimationStateController(ObjectView playerObjectView, ContactsPoller contactsPoller)
        {
            _playerObjectView = playerObjectView;
            _contactsPoller = contactsPoller;
            var playerAnimationConfig = _playerObjectView.SpriteAnimationConfig;
            _spriteAnimationController = new SpriteAnimationController(playerAnimationConfig);
        }

        public void Execute(float deltaTime)
        {
            _spriteAnimationController.Execute(deltaTime);
            AnimateIdleAndRun();
            AnimateJumping();
        }

        private void AnimateIdleAndRun()
        {
            if (_playerObjectView.Rigidbody2D.velocity.x != _contactsPoller.GroundVelocity.x)
            {
                if (_playerObjectView.Rigidbody2D.velocity.x < _contactsPoller.GroundVelocity.x)
                {
                    _playerObjectView.SpriteRenderer.flipX = true;
                }
                else _playerObjectView.SpriteRenderer.flipX = false;
                _spriteAnimationController.StartAnimation(_playerObjectView.SpriteRenderer,
                    AnimationState.Running, true, _spriteAnimationController.AnimationSpeed);
            }
            else _spriteAnimationController.StartAnimation(_playerObjectView.SpriteRenderer,
             AnimationState.Idle, true, _spriteAnimationController.AnimationSpeed);
        }

        private void AnimateJumping()
        {
            if (!_contactsPoller.IsGrounded)
            {
                if (_playerObjectView.Rigidbody2D.velocity.y > 0)
                {
                    _spriteAnimationController.StartAnimation(_playerObjectView.SpriteRenderer,
                        AnimationState.JumpingUp, false, _spriteAnimationController.AnimationSpeed);
                }
                else if (_playerObjectView.Rigidbody2D.velocity.y < 0)
                {
                    _spriteAnimationController.StartAnimation(_playerObjectView.SpriteRenderer,
                        AnimationState.OnAir, false, _spriteAnimationController.AnimationSpeed);
                }
            }
        }
    }
}
