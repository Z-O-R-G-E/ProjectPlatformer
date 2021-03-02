using UnityEngine;


namespace ProjectPlatformer
{
    internal sealed class Reference
    {
        private PlayerView _player;
        private Camera _mainCamera;
        private SpriteAnimationsConfig _playerConfig;

        public PlayerView Player
        {
            get
            {
                if(_player == null)
                {
                    var gameObject = Resources.Load<PlayerView>("Player");
                    _player = Object.Instantiate(gameObject);
                }
                return _player;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if(_mainCamera == null)
                {
                    var gameObject = Resources.Load<Camera>("MainCamera");
                    _mainCamera = Object.Instantiate(gameObject);
                }
                return _mainCamera;
            }
        }

        public SpriteAnimationsConfig PlayerConfig
        {
            get
            {
                if (_playerConfig == null)
                {
                    var gameObject = Resources.Load<SpriteAnimationsConfig>("PlayerAnimConfig");
                    _playerConfig = Object.Instantiate(gameObject);
                }
                return _playerConfig;
            }
        }
    }
}