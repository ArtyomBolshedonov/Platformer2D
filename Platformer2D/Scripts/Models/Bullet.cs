using UnityEngine;


namespace Platformer2D
{
    internal sealed class Bullet
    {
        private readonly BulletView _bulletView;
        private Vector3 _direction;

        public Bullet(BulletView bulletView)
        {
            _bulletView = bulletView;
            _bulletView.SetVisible(false);
        }

        public void Throw(Vector3 position, Vector3 velocity)
        {
            _bulletView.Transform.position = position;
            SetDirection(velocity);
            _bulletView.Rigidbody2D.velocity = Vector2.zero;
            _bulletView.Rigidbody2D.angularVelocity = 0;
            _bulletView.Rigidbody2D.AddForce(_direction, ForceMode2D.Impulse);
            _bulletView.SetVisible(true);
        }

        private void SetDirection(Vector3 velocity)
        {
            _direction = velocity;
            var angle = Vector3.Angle(Vector3.right, _direction);
            var axis = Vector3.Cross(Vector3.right, _direction);
            _bulletView.Transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public void Hit()
        {
            _bulletView.SetVisible(false);
        }
    }
}
