using UnityEngine;


namespace Platformer2D
{
    internal sealed class AnimationStateController : IExecute
    {
        private readonly SpriteAnimationController _spriteAnimationController;
        private readonly ObjectView _objectView;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly float _animationSpeed;

        public AnimationStateController(ObjectView objectView, float animationSpeed)
        {
            _objectView = objectView;
            _animationSpeed = animationSpeed;
            _rigidbody2D = _objectView.gameObject.GetComponent<Rigidbody2D>();
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
            if (Input.GetAxis(InputManager.HORIZONTAL) != 0)
            {
                if (Input.GetAxis(InputManager.HORIZONTAL) < 0)
                {
                    _objectView.SpriteRenderer.flipX = true;
                }
                else _objectView.SpriteRenderer.flipX = false;
                _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer, AnimationState.Running, true, _animationSpeed);
            }
            else _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer, AnimationState.Idle, true, _animationSpeed);
        }

        private void AnimateJumping()
        {
            if (_rigidbody2D.velocity.y > 0)
            {
                _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer, AnimationState.JumpingUp, false, _animationSpeed);
            }
            else if (_rigidbody2D.velocity.y < 0)
            {
                _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer, AnimationState.OnAir, false, _animationSpeed);
            }
        }
    }
}
