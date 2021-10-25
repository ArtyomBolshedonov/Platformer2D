using System.Collections.Generic;
using UnityEngine;


namespace Platformer2D
{
    internal sealed class Animation : IExecute
    {
        public AnimationState AnimationState;
        public List<Sprite> Sprites;
        public float Counter { get; set; }
        public bool Loop { get; set; }
        public bool Sleep { get; set; }
        public float Speed { get; set; }

        public void Execute(float deltaTime)
        {
            if (Sleep) return;
            Counter += deltaTime * Speed;
            if (Loop)
            {
                while(Counter > Sprites.Count)
                {
                    Counter -= Sprites.Count;
                }
            }
            else if(Counter > Sprites.Count)
            {
                Counter = Sprites.Count;
                Sleep = true;
            }
        }
    }
}
