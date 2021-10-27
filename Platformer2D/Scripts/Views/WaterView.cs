using UnityEngine;


namespace Platformer2D
{
    internal sealed class WaterView : ObjectView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("WaterAnimationConfig");
        }
    }
}
