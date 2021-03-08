using UnityEngine;

namespace ProjectPlatformer
{
    internal class PlayerController : IFixedExecute
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private SpriteAnimator _spriteAnimator;
        private readonly ContactsPoller _contactsPoller;

        private const float _movingThresh = 0.1f;

        private Vector2 _movementVector
        {
            get
            {
                var horizontal = Input.GetAxis("Horizontal");
                var vertical = 0.0f;

                return new Vector2(horizontal, vertical);
            }
        }

        public PlayerController(PlayerView playerView, SpriteAnimator spriteAnimator)
        {
            _playerView = playerView;
            _playerView.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            _playerModel = new PlayerModel();
            _spriteAnimator = spriteAnimator;
            _contactsPoller = new ContactsPoller(_playerView.Collider2D);
        }

        public void FixedExecute()
        {
            MoveLogic();
            JumpLogic();
            _contactsPoller.Execute();
        }

        private void MoveLogic()
        {
            var walks = Mathf.Abs(_movementVector.x) > _movingThresh;
            if (walks)
            {
                _playerView.Flip(_movementVector.x);
            }

            var newVelocity = 0.0f;

            if (walks &&
                (_movementVector.x > 0 || !_contactsPoller.HasLeftContacts) &&
                (_movementVector.x < 0 || !_contactsPoller.HasRightContacts))
            {
                newVelocity = Time.fixedDeltaTime * _playerModel.MoveSpeed * (_movementVector.x < 0 ? -1 : 1);
            }
            _playerView.MoveHorizontal(newVelocity);
            _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, walks ? AnimState.WALK : AnimState.IDLE, true, _playerModel.AnimationsSpeed);
        }

        private void JumpLogic()
        {
            if (_contactsPoller.HasBottomContacts && (Input.GetAxis("Jump") > 0))
            {
                _playerView.Jump(_playerModel.JumpForce);
            }
            if (!_contactsPoller.HasBottomContacts) 
            {
                _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, AnimState.JUMPUP, true, _playerModel.AnimationsSpeed);
            }
        }
    }
}