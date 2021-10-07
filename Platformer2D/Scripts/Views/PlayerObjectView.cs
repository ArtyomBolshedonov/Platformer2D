using UnityEngine;


namespace Platformer2D
{
    internal sealed class PlayerObjectView : ObjectView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("PlayerAnimationConfig");
        }
    }
}
