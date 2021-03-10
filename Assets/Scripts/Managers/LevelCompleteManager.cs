using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class LevelCompleteManager : IDisposable
    {
        private Vector3 _startPosition;
        private PlayerView _playerView;
        private List<LevelObjectView> _deathZones;
        private List<LevelObjectView> _winZones;

        public LevelCompleteManager(PlayerView playerView, List<LevelObjectView> deathZones, List<LevelObjectView> winZones)
        {
            _playerView = playerView;
            _deathZones = deathZones;
            _winZones = winZones;
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (_deathZones.Contains(contactView))
            {
                _playerView.Transform.position = _startPosition;
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
