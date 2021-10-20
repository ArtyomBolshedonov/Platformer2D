using System;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    internal sealed class SpriteAnimationController : IExecute, IDisposable
    {
        private readonly SpriteAnimationConfig _spriteAnimationConfig;
        private readonly Dictionary<SpriteRenderer, Animation> _activeAnimation;

        public float AnimationSpeed => 10.0f;
        public SpriteAnimationController(SpriteAnimationConfig spriteAnimationConfig)
        {
            _spriteAnimationConfig = spriteAnimationConfig;
            _activeAnimation = new Dictionary<SpriteRenderer, Animation>();
        }
        public void StartAnimation(SpriteRenderer spriteRenderer, AnimationState animationState, bool loop, float speed)
        {
            if(_activeAnimation.TryGetValue(spriteRenderer, out var animation))
            {
                animation.Sleep = false;
                animation.Loop = loop;
                animation.Speed = speed;
                if(animation.AnimationState != animationState)
                {
                    animation.AnimationState = animationState;
                    animation.Sprites = _spriteAnimationConfig.SpriteSequences.Find
                        (spriteSequence => spriteSequence.AnimationState == animationState).Sprites;
                    animation.Counter = 0;
                }
            }
            else
            {
                _activeAnimation.Add(spriteRenderer, new Animation
                {
                    Loop = loop,
                    Speed = speed,
                    AnimationState = animationState,
                    Sprites = _spriteAnimationConfig.SpriteSequences.Find
                    (spriteSequence => spriteSequence.AnimationState == animationState).Sprites
                });
            }
        }
        public void StopAnimation(SpriteRenderer spriteRenderer)
        {
            if (_activeAnimation.ContainsKey(spriteRenderer))
            {
                _activeAnimation.Remove(spriteRenderer);
            }
        }
        public void Execute(float deltaTime)
        {
            foreach (var animation in _activeAnimation)
            {
                animation.Value.Execute(deltaTime);
                if (animation.Value.Counter < animation.Value.Sprites.Count)
                {
                    animation.Key.sprite = animation.Value.Sprites[(int)animation.Value.Counter];
                }
            }
        }
        public void Dispose()
        {
            _activeAnimation.Clear();
        }
    }
}
