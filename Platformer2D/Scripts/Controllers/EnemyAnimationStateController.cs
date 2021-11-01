using UnityEngine;
using System.Collections.Generic;


namespace Platformer2D
{
    internal sealed class EnemyAnimationStateController
    {
        private readonly SpriteAnimationController _spriteAnimationController;
        private readonly ObjectView _objectView;
        private readonly List<Transform> _enemyParts;

        public EnemyAnimationStateController(ObjectView objectView)
        {
            _objectView = objectView;
            _enemyParts = new List<Transform>(_objectView.GetComponentsInChildren<Transform>());
            var animationConfig = _objectView.SpriteAnimationConfig;
            _spriteAnimationController = new SpriteAnimationController(animationConfig);
        }

        public void Execute(float deltaTime)
        {
            _spriteAnimationController.Execute(deltaTime);
            AnimatePatrolling();
        }

        private void AnimatePatrolling()
        {
            var newScale = 1.0f;
            _spriteAnimationController.StartAnimation(_objectView.SpriteRenderer,
             AnimationState.Running, true, _spriteAnimationController.AnimationSpeed);
            if (_objectView.Rigidbody2D.velocity.x < 0)
            {
                newScale = -1.0f;
            }
            else newScale = 1.0f;
            _objectView.Transform.localScale = _objectView.Transform.localScale.Change(x: newScale);
            foreach (var item in _enemyParts)
            {
                item.transform.localScale = item.transform.localScale.Change(x: newScale);
            }
        }
    }
}
