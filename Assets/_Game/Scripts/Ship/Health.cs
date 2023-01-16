using UnityEngine;

namespace Ship
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;

        private int _health;
        private const int MIN_HEALTH = 0;

        private void Start()
        {
            _health = _playerData._startHealth;
        }


        
        public void TakeDamage(int damage)
        { 
            Debug.Log("Took some damage");
            _health = Mathf.Max(MIN_HEALTH, _health - damage);
        }
    }
}
