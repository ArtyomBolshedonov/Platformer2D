﻿using UnityEngine;


namespace Platformer2D
{
    internal class BulletView : ObjectView
    {
        [SerializeField]
        private TrailRenderer _trail;

        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            SpriteRenderer.enabled = visible;
            Rigidbody2D.simulated = visible;
            Collider2D.enabled = visible;
        }

        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("BulletAnimationConfig");
        }
    }
}
