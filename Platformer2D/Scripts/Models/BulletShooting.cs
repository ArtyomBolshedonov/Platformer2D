using UnityEngine;
using System.Collections.Generic;


namespace Platformer2D
{
    internal sealed class BulletShooting : IShoot
    {
        private const float _delay = 5;
        private const float _startSpeed = 5;

        private readonly List<Bullet> _bullets;
        private readonly Transform _transform;

        private int _currentIndex;
        private float _timeTillNextBullet;

        public BulletShooting(List<BulletView> bulletViews, Transform transform)
        {
            _bullets = new List<Bullet>();
            _transform = transform;
            foreach (var bulletView in bulletViews)
            {
                _bullets.Add(new Bullet(bulletView));
            }
        }

        public void Shoot()
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position, _transform.right * _startSpeed);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count) _currentIndex = 0;
            }
            _bullets.ForEach(b => b.BulletFly());
        }
    }
}
