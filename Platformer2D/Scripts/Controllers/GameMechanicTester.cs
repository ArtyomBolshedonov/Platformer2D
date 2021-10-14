using UnityEngine;


namespace Platformer2D
{
    internal sealed class GameMechanicTester : IExecute
    {
        private readonly GameStarter _gameStarter;
        private readonly HelicopterObjectView _helicopterObjectView;
        private readonly SpriteAnimationController _enemySpriteAnimationController;
        private readonly AimingBarrel _aimingBarrel;
        private readonly BulletShooting _bulletShooting;
        private Vector3 _turningScale;
        private readonly float _startPatrolPositionX;
        private readonly float _startPatrolPositionY;
        private readonly float _patrolRangeX;
        private float pastPosition;
        private float presentPosition;

        public GameMechanicTester(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;
            _helicopterObjectView = _gameStarter.HelicopterObjectView;
            _enemySpriteAnimationController = new SpriteAnimationController(_helicopterObjectView.SpriteAnimationConfig);
            _startPatrolPositionX = _helicopterObjectView.transform.position.x;
            _startPatrolPositionY = _helicopterObjectView.transform.position.y;
            _patrolRangeX = _startPatrolPositionX + 3;
            _turningScale = new Vector3(1, 1, 1);
            _aimingBarrel = new AimingBarrel(_helicopterObjectView.Barrrel, _gameStarter.PlayerObjectView.Transform);
            _bulletShooting = new BulletShooting(_gameStarter.BulletViews, _gameStarter.PlayerObjectView, _helicopterObjectView.Barrrel);
        }

        public void Execute(float deltaTime)
        {
            _helicopterObjectView.transform.localScale = _turningScale;
            _helicopterObjectView.Barrrel.localScale = _turningScale;
            _enemySpriteAnimationController.Execute(deltaTime);
            _enemySpriteAnimationController.StartAnimation(_helicopterObjectView.SpriteRenderer,
                AnimationState.Idle, true, _enemySpriteAnimationController.AnimationSpeed * 3);
            _helicopterObjectView.transform.localPosition = new Vector2
                (Mathf.PingPong(_startPatrolPositionX + Time.time, _patrolRangeX), _startPatrolPositionY);
            IsTurn();
            ChangePosition();
            _aimingBarrel.Aiming();
            _bulletShooting.Shoot(deltaTime);
        }

        private void IsTurn()
        {
            presentPosition = _helicopterObjectView.transform.position.x;
            if (presentPosition > pastPosition)
            {
                _turningScale.x = 1;
            }
            else _turningScale.x = -1;
        }

        private void ChangePosition()
        {
            pastPosition = presentPosition;
        }
    }
}
