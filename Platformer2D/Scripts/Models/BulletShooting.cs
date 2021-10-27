using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;


namespace Platformer2D
{
    internal sealed class BulletShooting : IShoot, IDisposable
    {
        private readonly List<BulletView> _bulletViews;
        private readonly List<Bullet> _bullets;
        private readonly Transform _transform;
        private readonly ObjectView _playerObjectView;
        private Vector3 _startPosition;

        private int _hitCount = 0;
        private int _currentIndex;
        private float _timeTillNextBullet;
        private const float _delay = 5;
        private const float _startSpeed = 10;

        public BulletShooting(List<BulletView> bulletViews, ObjectView playerObjectView, Transform transform)
        {
            _playerObjectView = playerObjectView;
            _startPosition = _playerObjectView.Transform.position;
            _bulletViews = bulletViews;
            _bullets = new List<Bullet>();
            _transform = transform;
            _playerObjectView.OnObjectContact += OnObjectContact;

            foreach (var bulletView in bulletViews)
            {
                _bullets.Add(new Bullet(bulletView));
            }
        }

        public void Shoot(float deltaTime)
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= deltaTime;
            }
            else
            {
                _timeTillNextBullet = _delay;
                _bullets[_currentIndex].Throw(_transform.position, _transform.right * _startSpeed);
                _currentIndex++;
                if (_currentIndex >= _bullets.Count) _currentIndex = 0;
            }
        }

        private void OnObjectContact(ObjectView objectView)
        {
            if (_bulletViews.Contains(objectView))
            {
                _bulletViews.Find(b => b == objectView).SetVisible(false);
                _hitCount++;
            }
            if (_hitCount == 3)
            {
                _playerObjectView.Transform.position = _startPosition;
                _hitCount = 0;
            }
        }

        public void Dispose()
        {
            _playerObjectView.OnObjectContact -= OnObjectContact;
        }
    }
}
