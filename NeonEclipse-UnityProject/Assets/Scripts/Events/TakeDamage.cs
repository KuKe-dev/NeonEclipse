using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TakeDamage : MonoBehaviour
{
    [Header("Opciones de daño")]
    public float health = 100f;
    public bool destroyOnDeath = true;

    private Rigidbody2D rb;
    private float stunTimer = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            rb.velocity = Vector2.zero;
        }
    }

    public bool IsStunned() => stunTimer > 0;

    public void ApplyDamage(float damage, Vector2 knockDirection, float knockForce, float stunTime)
    {
        // Aplicar knockback
        rb.velocity = knockDirection.normalized * knockForce;

        // Aplicar stun
        stunTimer = stunTime;

        // Restar vida (opcional)
        health -= damage;
        if (health <= 0 && destroyOnDeath)
        {
            Destroy(gameObject);
        }


        // 🚨 A futuro: reproducir animaciones, partículas, sonido, etc.
    }
}
