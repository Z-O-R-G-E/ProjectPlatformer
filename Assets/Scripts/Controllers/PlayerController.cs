using UnityEngine;

namespace ProjectPlatformer
{
    internal class PlayerController : IFixedExecute
    {
        private PlayerView _playerView;
        private PlayerModel _playerModel;
        private SpriteAnimator _spriteAnimator;
        private LayerMask _groundLayer = 1;

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
        }

        public void FixedExecute()
        {
            MoveLogic();
            JumpLogic();
        }

        private void MoveLogic()
        {
            var goSideWay = Mathf.Abs(_movementVector.x) > _movingThresh;
            if (goSideWay)
            {
                _playerView.MoveHorizontal(_movementVector.x, _playerModel.MoveSpeed);
                _playerView.Flip(_movementVector.x);
            }
            _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, goSideWay ? AnimState.WALK : AnimState.IDLE, true, _playerModel.AnimationsSpeed);
        }

        private void JumpLogic()
        {
            if (IsGrounded() && (Input.GetAxis("Jump") > 0))
            {
                _playerView.Jump(_playerModel.JumpForce);
            }
            if (!IsGrounded()) 
            {
                _spriteAnimator.StartAnimation(_playerView.SpriteRenderer, AnimState.JUMPUP, true, _playerModel.AnimationsSpeed);
            }
        }

        bool IsGrounded()
        {
            RaycastHit2D hit = Physics2D.BoxCast(_playerView.Collider2D.bounds.center, _playerView.Collider2D.bounds.size, 0, Vector2.down, 0.1f, _groundLayer);

            return hit.collider != null;
        }
    }
}