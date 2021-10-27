using System.Collections.Generic;


namespace Platformer2D
{
    internal sealed class EnemyModel : IAiming, IShoot
    {
        private readonly EnemyView _enemyObjectView;
        private readonly AimingBarrel _aimingBarrel;
        private readonly BulletShooting _bulletShooting;
        private readonly EnemyPatrolAI _enemyPatrolAI;
        private readonly EnemyAnimationStateController _enemyAnimationStateController;
        private readonly List<SpriteAnimationController> _bulletAnimationControllers;

        public EnemyModel(EnemyView enemyObjectView, ObjectView playerObjectView, List<BulletView> bulletViews)
        {
            _enemyObjectView = enemyObjectView;
            var enemyAIConfig = new AIConfig
            {
                minSqrDistanceToTarget = 1.0f,
                speed = _enemyObjectView.Speed,
                waypoints = _enemyObjectView.PatrolPoints
            };
            _enemyPatrolAI = new EnemyPatrolAI(_enemyObjectView, new EnemyPatrolAIModel(enemyAIConfig));
            _aimingBarrel = new AimingBarrel(enemyObjectView.Barrrel, playerObjectView.Transform);
            _bulletShooting = new BulletShooting(bulletViews, playerObjectView, enemyObjectView.Barrrel);
            _enemyAnimationStateController = new EnemyAnimationStateController(_enemyObjectView);
            _bulletAnimationControllers = new List<SpriteAnimationController>();
            foreach (var bulletView in bulletViews)
            {
                var bulletAnimationController = new SpriteAnimationController(bulletView.SpriteAnimationConfig);
                bulletAnimationController.StartAnimation(bulletView.SpriteRenderer, AnimationState.Running,
                    true, bulletAnimationController.AnimationSpeed);
                _bulletAnimationControllers.Add(bulletAnimationController);
            }
        }

        public void Aiming()
        {
            _aimingBarrel.Aiming();
        }

        public void Patrol()
        {
            if (_enemyPatrolAI != null) _enemyPatrolAI.Patrol();
        }

        public void Shoot(float fixedDeltaTime)
        {
            _bulletShooting.Shoot(fixedDeltaTime);
        }

        public void AnimateEnemy(float deltaTime)
        {
            _enemyAnimationStateController.Execute(deltaTime);
            foreach (var bulletView in _bulletAnimationControllers)
            {
                bulletView.Execute(deltaTime);
            }
        }
    }
}
