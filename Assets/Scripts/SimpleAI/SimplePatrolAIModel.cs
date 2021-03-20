using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class SimplePatrolAIModel
    {
        private readonly AIConfig _aiConfig;
        private Transform _target;
        private int _currentPointIndex;

        public SimplePatrolAIModel(AIConfig aiConfig)
        {
            _aiConfig = aiConfig;
            _target = GetNextWaypoint();
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);

            if(sqrDistance <= _aiConfig.minDistanceToTarget)
            {
                _target = GetNextWaypoint();
            }

            var direction = ((Vector2)_target.position - fromPosition).normalized;
            return _aiConfig.speed * direction;
        }

        private Transform GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _aiConfig.waypoints.Length;
            return _aiConfig.waypoints[_currentPointIndex];
        }
    }
}