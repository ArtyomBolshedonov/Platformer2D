using UnityEngine;


namespace Platformer2D
{
    internal sealed class HelicopterObjectView : EnemyView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("HelicopterAnimationConfig");
        }
    }
}
