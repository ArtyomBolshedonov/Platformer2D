using System.Collections.Generic;


namespace Platformer2D
{
    internal sealed class GameMechanicTester : IExecute
    {
        private readonly GameStarter _gameStarter;
        private readonly EnemyView _helicopterObjectView;
        private readonly EnemyView _tankObjectView;
        private readonly List<EnemyModel> _enemyModels;
        private readonly CoinController _coinController;
        private readonly LevelCompleteController _levelCompleteController;
        private readonly ElevatorsController _elevatorsController;
        private readonly SpriteAnimationController _blackHoleAnimationController;
        private readonly SpriteAnimationController _waterAnimationController;

        public GameMechanicTester(GameStarter gameStarter)
        {
            _gameStarter = gameStarter;
            _helicopterObjectView = _gameStarter.HelicopterObjectView;
            _tankObjectView = _gameStarter.TankObjectView;
            _enemyModels = new List<EnemyModel>
            {
                new EnemyModel(_helicopterObjectView, _gameStarter.PlayerObjectView, _gameStarter.BulletViews),
                new EnemyModel(_tankObjectView, _gameStarter.PlayerObjectView, _gameStarter.RocketViews)
            };
            var coinAnimationController = new SpriteAnimationController(_gameStarter.CoinViews.Find(o => o is CoinView).SpriteAnimationConfig);
            _coinController = new CoinController(_gameStarter.PlayerObjectView, _gameStarter.CoinViews, coinAnimationController);
            _levelCompleteController = new LevelCompleteController(_gameStarter.PlayerObjectView, _gameStarter.DeathViews);
            _elevatorsController = new ElevatorsController(_gameStarter.Elevators);
            _blackHoleAnimationController = new SpriteAnimationController(_gameStarter.BlackHoleView.SpriteAnimationConfig);
            _blackHoleAnimationController.StartAnimation(_gameStarter.BlackHoleView.SpriteRenderer,
                AnimationState.Idle, true, _blackHoleAnimationController.AnimationSpeed);
            _waterAnimationController = new SpriteAnimationController(_gameStarter.WaterView.SpriteAnimationConfig);
            _waterAnimationController.StartAnimation(_gameStarter.WaterView.SpriteRenderer,
                AnimationState.Idle, true, _waterAnimationController.AnimationSpeed);
        }

        public void Execute(float deltaTime)
        {
            foreach (var enemyModel in _enemyModels)
            {
                enemyModel.Patrol();
                enemyModel.Aiming();
                enemyModel.Shoot(deltaTime);
                enemyModel.AnimateEnemy(deltaTime);
            }
            _coinController.Execute(deltaTime);
            _levelCompleteController.Execute(deltaTime);
            _elevatorsController.Execute(deltaTime);
            _blackHoleAnimationController.Execute(deltaTime);
            _waterAnimationController.Execute(deltaTime);
        }
    }
}
