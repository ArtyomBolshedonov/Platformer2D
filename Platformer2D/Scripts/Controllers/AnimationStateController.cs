namespace Platformer2D
{
    internal sealed class AnimationStateController : IExecute
    {
        private readonly SpriteAnimationController _spriteAnimationController;
        private readonly ObjectView _objectView;

        public AnimationStateController(ObjectView objectView)
        {
            _objectView = objectView;
            var playerAnimationConfig = _objectView.SpriteAnimationConfig;
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
            if (_objectView.Rigidbody2D.velocity.x != 0)
            {
                if (_objectView.Rigidbody2D.velocity.x < 0)
                {
                    _objectView.SpriteRenderer.flipX = true;
                }
                else _objectView.SpriteRenderer.flipX = false;
                _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer,
                    AnimationState.Running, true, _spriteAnimationController.AnimationSpeed);
            }
            else _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer,
                AnimationState.Idle, true, _spriteAnimationController.AnimationSpeed);
        }

        private void AnimateJumping()
        {
            if (_objectView.Rigidbody2D.velocity.y > 0)
            {
                _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer,
                    AnimationState.JumpingUp, false,_spriteAnimationController.AnimationSpeed);
            }
            else if (_objectView.Rigidbody2D.velocity.y < 0)
            {
                _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer,
                    AnimationState.OnAir, false, _spriteAnimationController.AnimationSpeed);
            }
        }
    }
}
