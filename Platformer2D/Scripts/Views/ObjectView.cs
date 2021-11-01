using System;
using UnityEngine;


namespace Platformer2D
{
    internal abstract class ObjectView : MonoBehaviour
    {
        public Transform Transform { get; private set; }
        public Collider2D Collider2D { get; private set; }
        public Rigidbody2D Rigidbody2D { get; private set; }
        public SpriteAnimationConfig SpriteAnimationConfig { get; private set; }
        public SpriteRenderer SpriteRenderer { get; private set; }

        public Action<ObjectView> OnObjectContact { get; set; }

        private void Awake()
        {
            Transform = GetComponent<Transform>();
            Collider2D = GetComponent<Collider2D>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
            SpriteRenderer = GetComponent<SpriteRenderer>();
            SpriteAnimationConfig = GetSpriteAnimationConfig();
        }

        protected abstract SpriteAnimationConfig GetSpriteAnimationConfig();

        private void OnTriggerEnter2D(Collider2D collider)
        {
            var interactiveObject = collider.gameObject.GetComponent<ObjectView>();
            OnObjectContact?.Invoke(interactiveObject);
        }
    }
}
