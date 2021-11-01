using UnityEngine;


namespace Platformer2D
{
    internal sealed class RocketView : BulletView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("RocketAnimationConfig");
        }
    }
}
