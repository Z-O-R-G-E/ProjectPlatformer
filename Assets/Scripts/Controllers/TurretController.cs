using System.Collections;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class TurretController : IExecute
    {
        private float _timeTillNextBullet;

        private TurretView _turretView;
        private TurretModel _turretModel;
        private PlayerView _playerView;
        private BulletView _bulletView;

        public TurretController(TurretView turretView, PlayerView playerView, BulletView bulletView)
        {
            _turretView = turretView;
            _playerView = playerView;
            _bulletView = bulletView;
            _turretModel = new TurretModel();
        }

        public void Execute()
        {
            _turretView.Rotate(_playerView.transform);
            FireLogic();
        }

        public void FireLogic()
        {
            if (_timeTillNextBullet > 0)
            {
                _timeTillNextBullet -= Time.deltaTime;
            }
            else
            {
                _timeTillNextBullet = _turretModel.Delay;
                _turretView.Fire(_bulletView, _turretModel.StartSpeed);
            }
        }
    }
}