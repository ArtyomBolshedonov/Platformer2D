using UnityEngine;


namespace Platformer2D
{
    internal sealed class MoveTransform : IMove
    {
        private readonly GameObject _gameObject;
        private Vector3 _move;
        public float Speed { get; private set; }

        public MoveTransform(GameObject gameObject, float speed)
        {
            _gameObject = gameObject;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _gameObject.transform.localPosition += _move;
        }
    }
}
