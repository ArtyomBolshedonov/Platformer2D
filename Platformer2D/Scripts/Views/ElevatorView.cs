using UnityEngine;


namespace Platformer2D
{
    internal sealed class ElevatorView : ObjectView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("ElevatorAnimationConfig");
        }
    }
}
