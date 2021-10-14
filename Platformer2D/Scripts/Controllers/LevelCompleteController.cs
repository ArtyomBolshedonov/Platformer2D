using System;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    internal sealed  class LevelCompleteController : IDisposable, IExecute
    {
        private Vector3 _startPosition;
        private readonly ObjectView _playerObjectView;
        private readonly List<ObjectView> _deathZones;
        private readonly SpriteAnimationController _spriteAnimationController;
        //private List<LevelObjectView> _winZones;

        public LevelCompleteController(ObjectView playerObjectView, List<ObjectView> deathZones)
        {
            _playerObjectView = playerObjectView;
            _startPosition = _playerObjectView.Transform.position;
            _playerObjectView.OnObjectContact += OnObjectContact;
            _deathZones = deathZones;
            _spriteAnimationController = new SpriteAnimationController(_deathZones.Find(f => f is ObjectView).SpriteAnimationConfig);
            foreach (var deathZone in _deathZones)
            {
                _spriteAnimationController.StartAnimation(deathZone.SpriteRenderer, AnimationState.Idle,
                    true, _spriteAnimationController.AnimationSpeed);
            }
            //_winZones = winZones;
        }

        private void OnObjectContact(ObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _playerObjectView.Transform.position = _startPosition;
            }
        }

        public void Dispose()
        {
            _playerObjectView.OnObjectContact -= OnObjectContact;
        }

        public void Execute(float deltaTime)
        {
            _spriteAnimationController.Execute(deltaTime);
        }
    }
}

