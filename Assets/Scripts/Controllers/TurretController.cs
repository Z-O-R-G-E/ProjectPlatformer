using System.Collections;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class TurretController : IExecute
    {

        private TurretView _turretView;
        private PlayerView _playerView;

        public TurretController(TurretView turretView, PlayerView playerView)
        {
            _turretView = turretView;
            _playerView = playerView;
        }

        public void Execute()
        {
            _turretView.Rotate(_playerView.transform);
        }
    }
}