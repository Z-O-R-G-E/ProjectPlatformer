using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class GemManager : IDisposable
    {
        private const float _animationSpeed = 10;

        private PlayerView _playerView;
        private SpriteAnimator _spriteAnimator;
        private GemView _gemView;

        public GemManager(PlayerView playerView, GemView gemView, SpriteAnimator spriteAnimator)
        {
            _playerView = playerView;
            _spriteAnimator = spriteAnimator;
            _gemView = gemView;
            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            _spriteAnimator.StartAnimation(_gemView.SpriteRenderer, AnimState.IDLE, true, _animationSpeed);
        }

        private void OnLevelObjectContact(GemView contactView)
        {
            
            _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
            GameObject.Destroy(contactView.gameObject);
            
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
