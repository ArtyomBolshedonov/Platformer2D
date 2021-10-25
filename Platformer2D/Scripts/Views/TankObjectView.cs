using UnityEngine;


namespace Platformer2D
{
    internal sealed class TankObjectView : EnemyView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("TankAnimationConfig");
        }
    }
}
