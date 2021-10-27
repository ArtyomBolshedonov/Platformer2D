using UnityEngine;


namespace MarchingSquaresGenerator
{
    internal sealed class ControlNode : Node
    {
        public bool Active;

        public ControlNode(Vector3 pos, bool active) : base(pos)
        {
            Active = active;
        }
    }
}
