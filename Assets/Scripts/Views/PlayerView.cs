using UnityEngine;

namespace ProjectPlatformer
{
    internal class PlayerView : LevelObjectView
    {
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        public void MoveHorizontal(Vector2 movementVector, float MoveSpeed)
        {
            Rigidbody2D.AddForce(movementVector * MoveSpeed, ForceMode2D.Impulse);
        }

        public void Flip(float xAxisInput)
        {
            transform.localScale = (xAxisInput < 0 ? _leftScale : _rightScale);
        }
        
        public void Jump(float jumpForce)
        {
            Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}