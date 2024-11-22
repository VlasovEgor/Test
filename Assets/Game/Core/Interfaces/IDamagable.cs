using System;

public interface IDamagable
{
    public event Action<Entity> OnHealthEmpty;
    public void TakeDamage(int damage);
}
