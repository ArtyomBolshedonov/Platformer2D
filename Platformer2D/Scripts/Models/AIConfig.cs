using UnityEngine;


namespace Platformer2D
{
    internal struct AIConfig
    {
        public float speed;
        public float minSqrDistanceToTarget;
        public Transform[] waypoints;
    }
}
