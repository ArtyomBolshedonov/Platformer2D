using UnityEngine;


namespace Platformer2D
{
    internal sealed class FireView : ObjectView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("FireAnimationConfig");
        }
    }
}
