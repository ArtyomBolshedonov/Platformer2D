using UnityEngine;


namespace Platformer2D
{
    internal sealed class BackgroundScrollingController : IExecute
    {
        private readonly GameObject _backGround;
        private readonly Camera _mainCamera;
        private Vector2 _screenBounds;

        public BackgroundScrollingController(GameObject backGround, Camera mainCamera)
        {
            _backGround = backGround;
            _mainCamera = mainCamera;
            _screenBounds = _mainCamera.ScreenToWorldPoint
                (new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z));
            LoadChildObject(_backGround);
        }

        private void LoadChildObject(GameObject obj)
        {
            var objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
            var childsNeeded = (int)Mathf.Ceil(_screenBounds.x * 2 / objectWidth);
            GameObject clone = Object.Instantiate(obj);
            for (int i = 0; i <= childsNeeded; i++)
            {
                GameObject child = Object.Instantiate(clone);
                child.transform.SetParent(obj.transform);
                child.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
                child.name = obj.name + i;
            }
            Object.Destroy(clone);
            Object.Destroy(obj.GetComponent<SpriteRenderer>());
        }

        private void RepositionChildObject(GameObject obj)
        {
            Transform[] children = obj.GetComponentsInChildren<Transform>();
            if (children.Length > 1)
            {
                GameObject firstChild = children[1].gameObject;
                GameObject lastChild = children[children.Length - 1].gameObject;
                float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
                if (_mainCamera.transform.position.x + _screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
                {
                    firstChild.transform.SetAsLastSibling();
                    firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2,
                        lastChild.transform.position.y, lastChild.transform.position.z);
                }
                else if (_mainCamera.transform.position.x - _screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
                {
                    lastChild.transform.SetAsFirstSibling();
                    lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2,
                        firstChild.transform.position.y, firstChild.transform.position.z);
                }
            }
        }

        public void Execute(float deltaTime)
        {
            RepositionChildObject(_backGround);
        }
    }
}
