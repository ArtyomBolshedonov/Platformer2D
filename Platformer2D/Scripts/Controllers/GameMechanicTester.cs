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
        private readonly CoinController _coinController;
        private readonly LevelCompleteController _levelCompleteController;
        private readonly ElevatorsController _elevatorsController;
        private readonly SpriteAnimationController _blackHoleAnimationController;
        private readonly SpriteAnimationController _waterAnimationController;
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
            _enemySpriteAnimationController.StartAnimation(_helicopterObjectView.SpriteRenderer,
                AnimationState.Idle, true, _enemySpriteAnimationController.AnimationSpeed * 3);
            _startPatrolPositionX = _helicopterObjectView.transform.position.x;
            _startPatrolPositionY = _helicopterObjectView.transform.position.y;
            _patrolRangeX = _startPatrolPositionX + 5;
            _turningScale = new Vector3(1, 1, 1);
            _aimingBarrel = new AimingBarrel(_helicopterObjectView.Barrrel, _gameStarter.PlayerObjectView.Transform);
            _bulletShooting = new BulletShooting(_gameStarter.BulletViews, _gameStarter.PlayerObjectView, _helicopterObjectView.Barrrel);
            var coinAnimationController = new SpriteAnimationController(_gameStarter.CoinViews.Find(o => o is CoinView).SpriteAnimationConfig);
            _coinController = new CoinController(_gameStarter.PlayerObjectView, _gameStarter.CoinViews, coinAnimationController);
            _levelCompleteController = new LevelCompleteController(_gameStarter.PlayerObjectView, _gameStarter.DeathViews);
            _elevatorsController = new ElevatorsController(_gameStarter.Elevators);
            _blackHoleAnimationController = new SpriteAnimationController(_gameStarter.BlackHoleView.SpriteAnimationConfig);
            _blackHoleAnimationController.StartAnimation(_gameStarter.BlackHoleView.SpriteRenderer,
                AnimationState.Idle, true, _enemySpriteAnimationController.AnimationSpeed);
            _waterAnimationController = new SpriteAnimationController(_gameStarter.WaterView.SpriteAnimationConfig);
            _waterAnimationController.StartAnimation(_gameStarter.WaterView.SpriteRenderer,
                AnimationState.Idle, true, _enemySpriteAnimationController.AnimationSpeed);
        }

        public void Execute(float deltaTime)
        {
            _helicopterObjectView.transform.localScale = _turningScale;
            _helicopterObjectView.Barrrel.localScale = _turningScale;
            _enemySpriteAnimationController.Execute(deltaTime);
            _helicopterObjectView.transform.localPosition = new Vector2
                (Mathf.PingPong(_startPatrolPositionX + Time.time, _patrolRangeX), _startPatrolPositionY);
            IsTurn();
            ChangePosition();
            _aimingBarrel.Aiming();
            _bulletShooting.Shoot(deltaTime);
            _coinController.Execute(deltaTime);
            _levelCompleteController.Execute(deltaTime);
            _elevatorsController.Execute(deltaTime);
            _blackHoleAnimationController.Execute(deltaTime);
            _waterAnimationController.Execute(deltaTime);
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
