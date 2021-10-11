using UnityEngine;


namespace Platformer2D
{
    internal sealed class JumpTransform : IJump
    {
        private readonly GameObject _gameObject;
        private readonly float _jumpforce;
        private const float _g = -10f;
        private const float _groundLevel = -5;
        private float _yVelocity;

        public float YVelocity => _yVelocity;

        public bool DoJump { get; set; }

        public bool OnGround => IsOnGround();

        public JumpTransform(GameObject gameObject, float jumpforce)
        {
            _gameObject = gameObject;
            _jumpforce = jumpforce;
        }

        public void Jump()
        {
            if (OnGround)
            {
                if (DoJump && _yVelocity == 0)
                {
                    _yVelocity = _jumpforce;
                }
                else if (_yVelocity < 0)
                {
                    _yVelocity = 0;
                    _gameObject.transform.position = _gameObject.transform.position.Change(y: _groundLevel);
                }
            }
            else
            {
                _yVelocity += _g * Time.deltaTime;
                _gameObject.transform.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }

        private bool IsOnGround()
        {
            return _gameObject.transform.position.y <= _groundLevel + float.Epsilon && _yVelocity <= 0;
        }
    }
}
