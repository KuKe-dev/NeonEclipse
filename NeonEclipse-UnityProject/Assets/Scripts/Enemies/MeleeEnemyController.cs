using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public MeleeEnemyData data;
    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        if (player == null) return;

        /* if (TryGetComponent(out TakeDamage takeDamage) && takeDamage.IsStunned())
        {
            rb.linearVelocity = Vector2.zero;
            return;
        } */

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance < data.detectionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * data.speed;
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.CompareTag("Player")) return;
        
        Vector2 dir = (collision.transform.position - transform.position).normalized;

            takeDamage.ApplyDamage(
                damage: 10f,
                knockDirection: dir,
                knockForce: 2000f,
                stunTime: 1f
            );

    }
}
