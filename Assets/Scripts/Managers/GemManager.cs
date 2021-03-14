using System;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class GemManager : IDisposable
    {
        private const float _animationSpeed = 10;

        private LevelObjectView _playerView;
        private SpriteAnimator _spriteAnimator;
        private LevelObjectView _gemView;

        public GemManager(LevelObjectView playerView, LevelObjectView gemView, SpriteAnimator spriteAnimator)
        {
            _playerView = playerView;
            _spriteAnimator = spriteAnimator;
            _gemView = gemView;
            _playerView.OnLevelObjectContact += OnLevelObjectContact;

            _spriteAnimator.StartAnimation(_gemView.SpriteRenderer, AnimState.IDLE, true, _animationSpeed);
        }

        private void OnLevelObjectContact(LevelObjectView contactView)
        {
            if (contactView.GetComponent<GemView>())
            {
                _spriteAnimator.StopAnimation(contactView.SpriteRenderer);
                GameObject.Destroy(contactView.gameObject);
            }
        }

        public void Dispose()
        {
            _playerView.OnLevelObjectContact -= OnLevelObjectContact;
        }
    }
}
