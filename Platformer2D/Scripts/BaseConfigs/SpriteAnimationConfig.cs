using System;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    [CreateAssetMenu(fileName = "SpriteAnimationConfig", menuName = "Configs/SpriteAnimationConfig", order = 1)]
    internal class SpriteAnimationConfig : ScriptableObject
    {
        public List<SpriteSequence> SpriteSequences = new List<SpriteSequence>();
    }
}
