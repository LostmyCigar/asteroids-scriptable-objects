using DefaultNamespace.ScriptableEvents;
using UnityEngine;
using UnityEngine.UIElements;
using Variables;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private ScriptableEventInt _onAsteroidDestroyed;
        [SerializeField] private AstroidData _asteroidData;

        [Header("References:")]
        [SerializeField] private Transform _shape;

        private SpriteRenderer _spriteRenderer;
        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private int _instanceId;

        private void Start()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _instanceId = GetInstanceID();

            SetSprite();
            SetColor();
            SetDirection();
            AddForce();
            AddTorque();
            SetSize();
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (string.Equals(other.tag, "Laser"))
            {
               HitByLaser();
            }
        }

        private void HitByLaser()
        {
            _onAsteroidDestroyed.Raise(_instanceId);
            Destroy(gameObject);
        }

        // TODO Can we move this to a single listener, something like an AsteroidDestroyer?
        public void OnHitByLaser(IntReference asteroidId)
        {
            if (_instanceId == asteroidId.GetValue())
            {
                Destroy(gameObject);
            }
        }
        
        public void OnHitByLaserInt(int asteroidId)
        {
            if (_instanceId == asteroidId)
            {
                Destroy(gameObject);
            }
        }
        
        private void SetSprite()
        {
            var rand = Random.Range(0, _asteroidData.astroidSprites.Length);
            _spriteRenderer.sprite = _asteroidData.astroidSprites[rand];
        }

        private void SetColor()
        {
            var rand = Random.Range(0, _asteroidData.astroidColors.Length);
            _spriteRenderer.color = _asteroidData.astroidColors[rand];
        }
        private void SetDirection()
        {
            var size = new Vector2(3f, 3f);
            var target = new Vector3
            (
                Random.Range(-size.x, size.x),
                Random.Range(-size.y, size.y)
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            var force = Random.Range(_asteroidData._minForce, _asteroidData._maxForce);
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse);
        }

        private void AddTorque()
        {
            var torque = Random.Range(_asteroidData._minTorque, _asteroidData._maxTorque);
            var roll = Random.Range(0, 2);

            if (roll == 0)
                torque = -torque;
            
            _rigidbody.AddTorque(torque, ForceMode2D.Impulse);
        }

        private void SetSize()
        {
            var size = Random.Range(_asteroidData._minSize, _asteroidData._maxSize);
            _shape.localScale = new Vector3(size, size, 0f);
        }
    }
}
