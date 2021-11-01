using UnityEngine;


namespace Platformer2D
{
    internal sealed class EnemyPatrolAIModel
    {
        private readonly AIConfig _config;
        private Transform _target;
        private int _currentPointIndex;
        
        public EnemyPatrolAIModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWaypoint();
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _config.minSqrDistanceToTarget)
            {
                _target = GetNextWaypoint();
            }
            var direction = ((Vector2)_target.position - fromPosition).normalized;
            return _config.speed * direction;
        }

        private Transform GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.waypoints.Length;
            return _config.waypoints[_currentPointIndex];
        }
    }
}
