using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Platformer2D
{
    internal sealed class CoinController : IDisposable, IExecute
    {
        private readonly ObjectView _playerObjectView;
        private readonly SpriteAnimationController _spriteAnimationController;
        private readonly List<CoinView> _coinViews;

        public CoinController(ObjectView playerObjectView, List<CoinView> coinViews, SpriteAnimationController spriteAnimationController)
        {
            _playerObjectView = playerObjectView;
            _spriteAnimationController = spriteAnimationController;
            _coinViews = coinViews;
            _playerObjectView.OnObjectContact += OnObjectContact;

            foreach (var coinView in _coinViews)
            {
                _spriteAnimationController.StartAnimation(coinView.SpriteRenderer, AnimationState.Idle,
                    true, _spriteAnimationController.AnimationSpeed);
            }
        }

        private void OnObjectContact(ObjectView objectView)
        {
            if (_coinViews.Contains(objectView))
            {
                _spriteAnimationController.StopAnimation(objectView.SpriteRenderer);
                GameObject.Destroy(objectView.gameObject);
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
