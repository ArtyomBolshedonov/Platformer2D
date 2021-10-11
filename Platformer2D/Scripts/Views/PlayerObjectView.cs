using UnityEngine;


namespace Platformer2D
{
    internal sealed class PlayerObjectView : ObjectView
    {
        [SerializeField] private float _jumpForce;
        public float JumpForce => _jumpForce;
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("PlayerAnimationConfig");
        }
    }
}
