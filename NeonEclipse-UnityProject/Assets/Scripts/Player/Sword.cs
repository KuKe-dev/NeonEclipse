using UnityEngine;

public class Sword : MonoBehaviour
{
    public int damage = 10;
    public float attackDuration = 0.3f;
    public float weaponDistance = 0.6f;

    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy")) return;

        Vector2 knockDir = (collision.transform.position - player.position).normalized;

        if (collision.TryGetComponent(out TakeDamage takeDamage))
        {
            takeDamage.ApplyDamage(
                damage: 10f,
                knockDirection: knockDir,
                knockForce: 20f,
                stunTime: 5f
            );
        }
    }
}
