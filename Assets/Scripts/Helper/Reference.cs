using UnityEngine;


namespace ProjectPlatformer
{
    internal sealed class Reference
    {
        private PlayerView _player;
        private TurretView _turret;
        private GemView _gem;
        private BulletView _bullet;
        private Camera _mainCamera;
        private SpriteAnimationsConfig _playerConfig;
        private SpriteAnimationsConfig _gemConfig;

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

        public TurretView Turret
        {
            get
            {
                if (_turret == null)
                {
                    var gameObject = Resources.Load<TurretView>("Turret");
                    _turret = Object.Instantiate(gameObject);
                }
                return _turret;
            }
        }

        public GemView Gem
        {
            get
            {
                if (_gem == null)
                {
                    var gameObject = Resources.Load<GemView>("Gem");
                    _gem = Object.Instantiate(gameObject);
                }
                return _gem;
            }
        }

        public BulletView Bullet
        {
            get
            {
                if (_bullet == null)
                {
                    var gameObject = Resources.Load<BulletView>("Bullet");
                    _bullet = Object.Instantiate(gameObject);
                }
                return _bullet;
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

        public SpriteAnimationsConfig GemConfig
        {
            get
            {
                if (_gemConfig == null)
                {
                    var gameObject = Resources.Load<SpriteAnimationsConfig>("GemAnimConfig");
                    _gemConfig = Object.Instantiate(gameObject);
                }
                return _gemConfig;
            }
        }
    }
}