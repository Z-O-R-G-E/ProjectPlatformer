using UnityEngine;

namespace ProjectPlatformer
{
    class EnemiesConfigurator : MonoBehaviour
    {
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private LevelObjectView _simplePatrolAIView;

        private SimplePatrolAI _simplePatrolAI;

        private void Start()
        {
            _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new SimplePatrolAIModel(_simplePatrolAIConfig));
        }

        private void FixedUpdate()
        {
            if (_simplePatrolAI != null)
            {
                _simplePatrolAI.FixedUpdate();
            }
        }
    }
}
