using System.Collections;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class TurretView : LevelObjectView
    {
        [SerializeField] private Transform _barrelTransform;

        public void Rotate(Transform target)
        {
            var dir = target.position - _barrelTransform.position;
            var angle = Vector3.Angle(Vector3.left, dir);
            var axis = Vector3.Cross(Vector3.left, dir);
            _barrelTransform.rotation = Quaternion.AngleAxis(angle, axis);

        }
    }
}