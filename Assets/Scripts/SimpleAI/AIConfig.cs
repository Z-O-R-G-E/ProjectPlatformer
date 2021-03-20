using System;
using UnityEngine;

namespace ProjectPlatformer
{
    [Serializable]
    internal struct AIConfig
    {
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;
    }
}
