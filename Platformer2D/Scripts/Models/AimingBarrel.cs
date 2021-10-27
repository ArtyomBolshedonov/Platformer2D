using UnityEngine;


namespace Platformer2D
{
    internal sealed class AimingBarrel : IAiming
    {
        private readonly Transform _barrelTransform;
        private readonly Transform _aimTransform;

        public AimingBarrel(Transform barrelTransform, Transform aimTransform)
        {
            _barrelTransform = barrelTransform;
            _aimTransform = aimTransform;
        }

        public void Aiming()
        {
            var dir = _aimTransform.position - _barrelTransform.position;
            var angle = Vector3.Angle(Vector3.right, dir);
            var axis = Vector3.Cross(Vector3.right, dir);
            _barrelTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }
    }
}
