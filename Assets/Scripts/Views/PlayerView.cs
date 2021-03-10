using System;
using UnityEngine;

namespace ProjectPlatformer
{
    internal class PlayerView : LevelObjectView
    {
        public Action<GemView> OnLevelObjectContact { get; set; }

        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        public void MoveHorizontal(float velocity)
        {
            Rigidbody2D.velocity = Rigidbody2D.velocity.Change(x: velocity);
        }

        public void Flip(float movementVector)
        {
            transform.localScale = (movementVector < 0 ? _leftScale : _rightScale);
        }
        
        public void Jump(float jumpForce)
        {
            Rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var levelObject = collision.gameObject.GetComponent<GemView>();
            OnLevelObjectContact?.Invoke(levelObject);
        }
    }
}