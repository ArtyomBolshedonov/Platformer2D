using UnityEngine;


namespace Platformer2D
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private int _animationSpeed;
        [SerializeField] private GameObject _backGround;
        public int AnimationSpeed => _animationSpeed;
        public PlayerObjectView PlayerObjectView { get; private set; }
        public Camera Camera { get; private set; }

        public GameObject BackGround => _backGround;

        public HelicopterObjectView HelicopterObjectView { get; private set; }

        private void Awake()
        {
            PlayerObjectView = FindObjectOfType<PlayerObjectView>();
            Camera = FindObjectOfType<Camera>();
            HelicopterObjectView = FindObjectOfType<HelicopterObjectView>();
        }
    }
}
