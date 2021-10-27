using UnityEngine;
using UnityEngine.Tilemaps;


namespace MarchingSquaresGenerator
{
    internal sealed class MarchingSquaresLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMapGround;
        [SerializeField] private Tile _tileGround;
        [SerializeField] private int _widthMap;
        [SerializeField] private int _heightMap;
        [SerializeField] private bool _borders;
        [SerializeField] [Range(0, 100)] private int _factorSmooth;
        [SerializeField] [Range(0, 100)] private int _randomFillPercent;

        public Tilemap TileMapGround => _tileMapGround;
        public Tile TileGround => _tileGround;
        public Vector2 MapStartPosition
        {
            get
            {
                var positionX = transform.position.x + _widthMap / 2 - 2;
                var positionY = transform.position.y - _heightMap / 2 - 1;
                return new Vector2(positionX, positionY);
            }
        }
        public int WidthMap => _widthMap;
        public int HeightMap => _heightMap;
        public bool Borders => _borders;
        public int FactorSmooth => _factorSmooth;
        public int RandomFillPercent => _randomFillPercent;
    }
}
