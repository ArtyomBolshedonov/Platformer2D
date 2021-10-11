using UnityEngine;


namespace Platformer2D
{
    internal abstract class ObjectView : MonoBehaviour
    {
        private Transform _transform;
        private Collider2D _collider2D;
        private Rigidbody2D _rigidbody2D;
        public float YVelocity { get; set; }

        public SpriteAnimationConfig SpriteAnimationConfig { get; private set; }

        public SpriteRenderer SpriteRenderer { get; private set; }

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            SpriteAnimationConfig = GetSpriteAnimationConfig();
        }

        protected abstract SpriteAnimationConfig GetSpriteAnimationConfig();
    }
}
