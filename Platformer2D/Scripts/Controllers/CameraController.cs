using UnityEngine;


namespace Platformer2D
{
    internal sealed class CameraController : IExecute
    {
        private readonly PlayerObjectView _playerObjectView;
        private readonly Camera _camera;
        private Vector3 _cameraOffSet;

        public CameraController(PlayerObjectView playerObjectView, Camera camera)
        {
            _playerObjectView = playerObjectView;
            _camera = camera;
            _cameraOffSet = new Vector3(0,0,-10);
        }

        public void Execute(float deltaTime)
        {
            _camera.transform.position = _playerObjectView.transform.position + _cameraOffSet;
        }
    }
}
