using UnityEngine;


namespace Platformer2D
{
    internal sealed class LaserView : ObjectView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("LaserAnimationConfig");
        }
    }
}
