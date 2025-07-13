using UnityEngine;

public class PlayerMovementService
{
    private readonly Rigidbody2D rb;
    private readonly float speed;

    public PlayerMovementService(Rigidbody2D rb, float speed)
    {
        this.rb = rb;
        this.speed = speed;
    }

    public void Move(Vector2 direction)
    {
        rb.linearVelocity = direction * speed;
    }

    public void Knockback(Vector2 direction, float force)
    {
        rb.linearVelocity = direction.normalized * force;
    }
}

