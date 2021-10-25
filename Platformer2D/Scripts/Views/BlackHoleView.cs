using UnityEngine;


namespace Platformer2D
{
    internal sealed class BlackHoleView : ObjectView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("BlackHoleAnimationConfig");
        }
    }
}
