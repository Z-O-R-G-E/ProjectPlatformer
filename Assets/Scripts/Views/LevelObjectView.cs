using UnityEngine;


namespace ProjectPlatformer
{
    internal class LevelObjectView : MonoBehaviour
    {
        private Transform _transform;
        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;
        private Collider2D _collider;

        public Transform Transform => _transform;
        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Rigidbody2D Rigidbody2D => _rigidbody;
        public Collider2D Collider2D => _collider;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _collider = GetComponent<Collider2D>();
        }
    }
}