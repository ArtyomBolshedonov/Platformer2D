using UnityEngine;


namespace Platformer2D
{
    internal abstract class EnemyView : ObjectView
    {
        [SerializeField] private Transform _barrel;
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private float _speed;
        public Transform Barrrel => _barrel;
        public Transform[] PatrolPoints => _patrolPoints;
        public float Speed => _speed;

        protected override abstract SpriteAnimationConfig GetSpriteAnimationConfig();
    }
}
