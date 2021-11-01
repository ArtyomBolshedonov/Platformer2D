﻿using UnityEngine;
using System.Collections.Generic;


namespace Platformer2D
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] private GameObject _backGround;
        public GameObject BackGround => _backGround;
        public PlayerObjectView PlayerObjectView { get; private set; }
        public Camera Camera { get; private set; }
        public HelicopterObjectView HelicopterObjectView { get; private set; }
        public List<CoinView> CoinViews { get; private set; }
        public List<BulletView> BulletViews { get; private set; }
        public List<ObjectView> DeathViews { get; private set; }
        public List<ObjectView> Elevators { get; private set; }
        public BlackHoleView BlackHoleView { get; private set; }
        public WaterView WaterView { get; private set; }
        public TankObjectView TankObjectView { get; private set; }
        public List<BulletView> RocketViews { get; private set; }
        public List<LeverObjectView> LeverObjectViews { get; private set; }

        private void Awake()
        {
            PlayerObjectView = FindObjectOfType<PlayerObjectView>();
            Camera = FindObjectOfType<Camera>();
            HelicopterObjectView = FindObjectOfType<HelicopterObjectView>();
            CoinViews = new List<CoinView>(FindObjectsOfType<CoinView>());
            BulletViews = new List<BulletView>(FindObjectsOfType<BulletView>());
            DeathViews = new List<ObjectView>(FindObjectsOfType<FireView>());
            var laser = FindObjectOfType<LaserView>();
            DeathViews.Add(laser);
            Elevators = new List<ObjectView>(FindObjectsOfType<ElevatorView>());
            BlackHoleView = FindObjectOfType<BlackHoleView>();
            WaterView = FindObjectOfType<WaterView>();
            TankObjectView = FindObjectOfType<TankObjectView>();
            RocketViews = new List<BulletView>(FindObjectsOfType<RocketView>());
            LeverObjectViews = new List<LeverObjectView>(FindObjectsOfType<LeverObjectView>());
        }
    }
}
