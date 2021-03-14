using UnityEngine;

namespace ProjectPlatformer
{
    internal sealed class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _offset;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
        }

        public void Execute()
        {
            if(_player.transform.localScale.x > 0)
            {
                _offset = new Vector3(0.0f, 0.3f, -1.0f);
            }
            else
            {
                _offset = new Vector3(0.0f, 0.3f, -1.0f);
            }
            _mainCamera.position = _player.position + _offset;
        }
    }
}