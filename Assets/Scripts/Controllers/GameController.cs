using System.Collections.Generic;
using UnityEngine;


namespace ProjectPlatformer{
    internal sealed class GameController: MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _background;

        private Reference _reference;
        private List<IExecute> _interactiveObjects;
        private List<IFixedExecute> _fixedInteractiveObjects;

        private Camera _mainCamera;
        private CameraController _cameraController;
        private ParalaxManager _paralaxManager;

        private PlayerView _playerView;
        private PlayerController _playerController;
        private SpriteAnimator _playerAnimator;

        private TurretView _turretView;
        private TurretController _turretController;

        private BulletView _bulletView;

        private GemManager _gemManager;
        private GemView _gemView;
        private SpriteAnimator _gemAnimator;

        //private InputController _inputController;

        private void Awake()
        {
            _interactiveObjects = new List<IExecute>();
            _fixedInteractiveObjects = new List<IFixedExecute>();

            _reference = new Reference();

            _playerView = _reference.Player;
            _mainCamera = _reference.MainCamera;
            _turretView = _reference.Turret;
            _bulletView = _reference.Bullet;
            _gemView = _reference.Gem;

            _paralaxManager = new ParalaxManager(_mainCamera.transform, _background.transform);
            _interactiveObjects.Add(_paralaxManager);
            
            _cameraController = new CameraController(_playerView.transform, _mainCamera.transform);
            _interactiveObjects.Add(_cameraController);
            
            _playerAnimator = new SpriteAnimator(_reference.PlayerConfig);
            _interactiveObjects.Add(_playerAnimator);
            
            _playerController = new PlayerController(_playerView, _playerAnimator);
            _fixedInteractiveObjects.Add(_playerController);

            _turretController = new TurretController(_turretView, _playerView, _bulletView);
            _interactiveObjects.Add(_turretController);

            _gemAnimator = new SpriteAnimator(_reference.GemConfig);
            _interactiveObjects.Add(_gemAnimator);

            _gemManager = new GemManager(_playerView, _gemView, _gemAnimator);

            /*
            _inputController = new InputController(_playerView);
            _interactiveObjects.Add(_inputController);
            */
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Count; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }

        private void FixedUpdate()
        {
            for (var i = 0; i < _fixedInteractiveObjects.Count; i++)
            {
                var interactiveObject = _fixedInteractiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.FixedExecute();
            }
        }

        private void OnDestroy()
        {
            
        }
    }
}