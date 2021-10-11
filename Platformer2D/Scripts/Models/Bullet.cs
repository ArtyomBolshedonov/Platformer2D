using UnityEngine;


namespace Platformer2D
{
    internal sealed class Bullet
    {
        private readonly BulletView _view;
        private Vector3 _velocity;
        private readonly float _radius = 0.3f;
        private const float _groundLevel = -6;
        private const float _g = -10;

        public Bullet(BulletView view)
        {
            _view = view;
            _view.gameObject.SetActive(false);
        }

        public void BulletFly()
        {
            if (IsGrounded())
            {
                SetVelocity(_velocity.Change(y: -_velocity.y));
                _view.gameObject.transform.position = _view.gameObject.transform.position.Change(y: _groundLevel + _radius);
            }
            else
            {
                SetVelocity(_velocity + Vector3.up * _g * Time.deltaTime);
                _view.gameObject.transform.position += _velocity * Time.deltaTime;
            }
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _view.gameObject.transform.position = position;
            SetVelocity(velocity);
            _view.gameObject.SetActive(true);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            var angle = Vector3.Angle(Vector3.right, _velocity);
            var axis = Vector3.Cross(Vector3.right, _velocity);
            _view.gameObject.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        private bool IsGrounded()
        {
            return _view.gameObject.transform.position.y <= _groundLevel + _radius + float.Epsilon && _velocity.y <= 0;
        }
    }
}
