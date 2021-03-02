using UnityEngine;

namespace ProjectPlatformer
{
    internal class PlayerView : LevelObjectView
    {
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        public void MoveHorizontal(float movementVector, float MoveSpeed)
        {
            Rigidbody2D.velocity = Rigidbody2D.velocity.Change(x: Time.fixedDeltaTime * MoveSpeed * (movementVector < 0 ? -1 : 1));
        }

        public void Flip(float movementVector)
        {
            transform.localScale = (movementVector < 0 ? _leftScale : _rightScale);
        }
        
        public void Jump(float jumpForce)
        {
            Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}