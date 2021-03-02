using UnityEngine;


namespace ProjectPlatformer
{
    internal sealed class ParalaxManager : IExecute
    {
        private Transform _camera;
        private Transform _background;
        private Vector3 _backStartPosition;
        private Vector3 _cameraStartPosition;
        
        private const float COEF = 0.3f;

        public ParalaxManager(Transform camera, Transform background)
        {
            _camera = camera;
            _background = background;
            _cameraStartPosition = _camera.transform.position;
            _backStartPosition = _background.transform.position;
        }

        public void Execute()
        {
            _background.position = _backStartPosition + (_camera.position - _cameraStartPosition) * COEF;
        }
    }
}