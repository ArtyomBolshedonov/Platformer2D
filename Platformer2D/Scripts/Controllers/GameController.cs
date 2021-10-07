using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    internal sealed class GameController : MonoBehaviour
    {
        private GameStarter _gameStarter;
        private MovementController _movementController;
        private AnimationStateController _animationStateController;
        private CameraController _cameraController;
        private ParalaxController _paralaxController;
        private BackgroundScrollingController _backgroundScrollingController;
        private List<IExecute> _listExecuteObjects;

        private void Start()
        {
            _gameStarter = FindObjectOfType<GameStarter>();
            _listExecuteObjects = new List<IExecute>();
            _movementController = new MovementController(_gameStarter.PlayerObjectView.gameObject,
                _gameStarter.AnimationSpeed, _gameStarter.JumpForce);
            _listExecuteObjects.Add(_movementController);
            _animationStateController = new AnimationStateController(_gameStarter.PlayerObjectView, _gameStarter.AnimationSpeed);
            _listExecuteObjects.Add(_animationStateController);
            _cameraController = new CameraController(_gameStarter.PlayerObjectView, _gameStarter.Camera);
            _listExecuteObjects.Add(_cameraController);
            _paralaxController = new ParalaxController(_gameStarter.Camera.transform, _gameStarter.BackGround.transform);
            _listExecuteObjects.Add(_paralaxController);
            _backgroundScrollingController = new BackgroundScrollingController(_gameStarter.BackGround, _gameStarter.Camera);
            _listExecuteObjects.Add(_backgroundScrollingController);
        }

        private void Update()
        {
            foreach (var item in _listExecuteObjects)
            {
                item.Execute(Time.deltaTime);
            }
        }
    }
}
