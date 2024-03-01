using _Core.Utils;

namespace Core
{
    public interface IDamageable
    {
        void TakeDamage(float damage);

        void TakeDamage(float damage, DamageCause cause);
        
        void Heal(float health);
        
        void Die();
        
        void SetHealth(float health);
        
        float GetHealth();
    }
}