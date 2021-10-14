using System;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    [Serializable]
    internal sealed class SpriteSequence
    {
        public AnimationState AnimationState;
        public List<Sprite> Sprites = new List<Sprite>();
    }
}
