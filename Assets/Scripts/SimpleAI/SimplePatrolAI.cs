using System;
using UnityEngine;

namespace ProjectPlatformer
{
    class SimplePatrolAI
    {
        private readonly LevelObjectView _view;
        private readonly SimplePatrolAIModel _model;

        public SimplePatrolAI(LevelObjectView view, SimplePatrolAIModel model) 
        {
            _view = view != null ? view : throw new ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }

        public void FixedUpdate()
        {
            var newVelicity = _model.CalculateVelocity(_view.Transform.position) * Time.fixedDeltaTime;
            _view.Rigidbody2D.velocity = newVelicity;
        }
    }
}
