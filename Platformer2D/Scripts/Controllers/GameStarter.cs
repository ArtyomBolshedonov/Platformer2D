using UnityEngine;


namespace Platformer2D
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private int _animationSpeed;
        [SerializeField] private float _jumpForce;
        [SerializeField] private GameObject _backGround;
        public int AnimationSpeed => _animationSpeed;
        public float JumpForce => _jumpForce;
        public PlayerObjectView PlayerObjectView { get; private set; }
        public Camera Camera { get; private set; }

        public GameObject BackGround => _backGround;

        private void Awake()
        {
            PlayerObjectView = FindObjectOfType<PlayerObjectView>();
            Camera = FindObjectOfType<Camera>();
        }
    }
}
