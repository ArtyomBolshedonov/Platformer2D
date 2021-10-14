using UnityEngine;
using System.Collections.Generic;


namespace Platformer2D
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private int _animationSpeed;
        [SerializeField] private GameObject _backGround;
        public int AnimationSpeed => _animationSpeed;
        public GameObject BackGround => _backGround;
        public PlayerObjectView PlayerObjectView { get; private set; }
        public Camera Camera { get; private set; }
        public HelicopterObjectView HelicopterObjectView { get; private set; }
        public CoinView CoinView { get; private set; }
        public List<BulletView> BulletViews { get; private set; }
        public List<ObjectView> FireViews { get; private set; }

        private void Awake()
        {
            PlayerObjectView = FindObjectOfType<PlayerObjectView>();
            Camera = FindObjectOfType<Camera>();
            HelicopterObjectView = FindObjectOfType<HelicopterObjectView>();
            CoinView = FindObjectOfType<CoinView>();
            BulletViews = new List<BulletView>(FindObjectsOfType<BulletView>());
            FireViews = new List<ObjectView>(FindObjectsOfType<FireView>());
        }
    }
}
