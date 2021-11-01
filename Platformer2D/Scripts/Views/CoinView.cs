using UnityEngine;


namespace Platformer2D
{
    internal sealed class CoinView : ObjectView
    {
        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("CoinAnimationConfig");
        }
    }
}
