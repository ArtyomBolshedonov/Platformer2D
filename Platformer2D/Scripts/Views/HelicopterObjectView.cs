using UnityEngine;


namespace Platformer2D
{
    internal sealed class HelicopterObjectView : ObjectView
    {
        [SerializeField] private Transform _barrel;

        public Transform Barrrel => _barrel;

        protected override SpriteAnimationConfig GetSpriteAnimationConfig()
        {
            return Resources.Load<SpriteAnimationConfig>("HelicopterAnimationConfig");
        }
    }
}
