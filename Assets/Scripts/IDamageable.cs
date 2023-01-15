using System.Collections;

public interface IDamageable
{
    void TakeDamage(float damage);
    IEnumerator FreezeCoroutine();
}