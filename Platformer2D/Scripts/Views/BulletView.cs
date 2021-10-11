using UnityEngine;


namespace Platformer2D
{
    internal sealed class BulletView : ObjectView
    {
        [SerializeField]
        private TrailRenderer _trail;

        public void SetVisible(bool visible)
        {
            if (_trail) _trail.enabled = visible;
            if (_trail) _trail.Clear();
            SpriteRenderer.enabled = visible;
        }

        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("BulletAnimationConfig");
        }
    }
}
