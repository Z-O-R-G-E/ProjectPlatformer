using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class TurretView : LevelObjectView
    {
        [SerializeField] private Transform _barrelTransform;
        [SerializeField] private Transform _emitterTransform;
        public List<BulletView> Bullets;

        public void Rotate(Transform target)
        {
            var dir = target.position - _barrelTransform.position;
            var angle = Vector3.Angle(Vector3.left, dir);
            var axis = Vector3.Cross(Vector3.left, dir);
            _barrelTransform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public void Fire(BulletView bulletView, float startSpeed)
        {
            bulletView.Transform.position = _emitterTransform.position;
            bulletView.Rigidbody2D.velocity = Vector2.zero;
            bulletView.Rigidbody2D.angularVelocity = 0;
            bulletView.Rigidbody2D.AddForce(-_emitterTransform.right * startSpeed, ForceMode2D.Impulse);
        }

    }
}