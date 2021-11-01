using UnityEngine;


namespace Platformer2D
{
    internal sealed class LeverObjectView : ObjectView
    {
        [SerializeField] private Color _completedColor;
        [SerializeField] private int _id;

        public int Id => _id;

        private Color _defaultColor;

        public void ProcessComplete()
        {
            SpriteRenderer.flipX = true;
            SpriteRenderer.color = _completedColor;
        }

        public void ProcessActivate()
        {
            SpriteRenderer.flipX = false;
            SpriteRenderer.color = _defaultColor;
        }

        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            _defaultColor = SpriteRenderer.color;
            return Resources.Load<SpriteAnimationConfig>("LeverAnimationConfig");
        }
    }
}

