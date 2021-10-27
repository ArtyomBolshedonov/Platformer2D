using System;


namespace Platformer2D
{
    internal sealed class EnemyPatrolAI
    {
        private readonly ObjectView _enemyObjectView;
        private readonly EnemyPatrolAIModel _enemyPatrolAIModel;

        public EnemyPatrolAI(ObjectView enemyObjectView, EnemyPatrolAIModel enemyPatrolAIModel)
        {
            _enemyObjectView = enemyObjectView != null ? enemyObjectView :
                throw new ArgumentNullException(nameof(enemyObjectView)); ;
            _enemyPatrolAIModel = enemyPatrolAIModel != null ? enemyPatrolAIModel :
                throw new ArgumentNullException(nameof(enemyPatrolAIModel));
        }

        public void Patrol()
        {
            var newVelocity = _enemyPatrolAIModel.CalculateVelocity(_enemyObjectView.Transform.position);
            _enemyObjectView.Rigidbody2D.velocity = newVelocity;
        }
    }
}
