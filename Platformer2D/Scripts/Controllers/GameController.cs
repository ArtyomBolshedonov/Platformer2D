using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    internal sealed class GameController : MonoBehaviour
    {
        private GameStarter _gameStarter;
        private MovementController _movementController;
        private AnimationStateController _playerAnimationStateController;
        private CameraController _cameraController;
        private ParalaxController _paralaxController;
        private BackgroundScrollingController _backgroundScrollingController;
        private GameMechanicTester _gameMechanicTester;
        private CoinController _coinController;
        private LevelCompleteController _levelCompleteController;
        private List<IExecute> _listExecuteObjects;
        private List<IExecute> _listFixedExecuteObjects;

        private void Start()
        {
            _gameStarter = FindObjectOfType<GameStarter>();
            _listExecuteObjects = new List<IExecute>();
            _listFixedExecuteObjects = new List<IExecute>();
            _movementController = new MovementController(_gameStarter.PlayerObjectView);
            _listFixedExecuteObjects.Add(_movementController);
            _playerAnimationStateController = new AnimationStateController(_gameStarter.PlayerObjectView);
            _listExecuteObjects.Add(_playerAnimationStateController);
            _cameraController = new CameraController(_gameStarter.PlayerObjectView, _gameStarter.Camera);
            _listExecuteObjects.Add(_cameraController);
            _paralaxController = new ParalaxController(_gameStarter.Camera.transform, _gameStarter.BackGround.transform);
            _listExecuteObjects.Add(_paralaxController);
            _backgroundScrollingController = new BackgroundScrollingController(_gameStarter.BackGround, _gameStarter.Camera);
            _listExecuteObjects.Add(_backgroundScrollingController);
            _gameMechanicTester = new GameMechanicTester(_gameStarter);
            _listExecuteObjects.Add(_gameMechanicTester);
            var coinViews = new List<CoinView>(FindObjectsOfType<CoinView>());
            var coinAnimationController = new SpriteAnimationController(coinViews.Find(o => o is CoinView).SpriteAnimationConfig);
            _coinController = new CoinController(_gameStarter.PlayerObjectView, coinViews, coinAnimationController);
            _listExecuteObjects.Add(_coinController);
            _levelCompleteController = new LevelCompleteController(_gameStarter.PlayerObjectView, _gameStarter.FireViews);
            _listExecuteObjects.Add(_levelCompleteController);
        }

        private void FixedUpdate()
        {
            var fixedDeltaTime = Time.fixedDeltaTime;
            foreach (var item in _listFixedExecuteObjects)
            {
                item.Execute(fixedDeltaTime);
            }
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            foreach (var item in _listExecuteObjects)
            {
                item.Execute(deltaTime);
            }
        }
    }
}
