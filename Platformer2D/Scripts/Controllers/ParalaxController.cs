using UnityEngine;


namespace Platformer2D
{
    internal sealed class ParalaxController : IExecute
    {
        private readonly Transform _camera;
        private readonly Transform _backGround;
        private Vector3 _backStartPosition;
        private Vector3 _cameraStartPosition;
        private const float _coef = 0.3f;

        public ParalaxController(Transform camera, Transform backGround)
        {
            _camera = camera;
            _backGround = backGround;
            _backStartPosition = _backGround.transform.position;
            _cameraStartPosition = _camera.transform.position;
        }

        public void Execute(float deltaTime)
        {
            _backGround.position = _backStartPosition + (_camera.position - _cameraStartPosition) * _coef;
        }
    }
}
