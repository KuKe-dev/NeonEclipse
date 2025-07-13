using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public PlayerData data;
    public InputService input;
    public GameObject weapon;

    private PlayerMovementService movementService;
    private Rigidbody2D rb;
    private Sword sword;

    private Vector2 lastMoveDirection = Vector2.right;
    private float knockbackTimer;
    private bool isAttacking = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movementService = new PlayerMovementService(rb, data.speed);
        sword = weapon.GetComponent<Sword>();
    }

    private void Update()
    {
        if (knockbackTimer > 0f)
        {
            knockbackTimer -= Time.deltaTime;
            return;
        }

        Vector2 moveDirection = input.MoveInput;
        if (moveDirection != Vector2.zero)
        {
            lastMoveDirection = moveDirection.normalized;
        }

        if (input.AttackPressed && !isAttacking)
        {
            StartCoroutine(Attack());
        }
        
        movementService.Move(moveDirection);
    }

    private System.Collections.IEnumerator Attack()
    {
        isAttacking = true;

        // Posiciona arma
        weapon.transform.localPosition = lastMoveDirection * sword.weaponDistance;
        float angle = Mathf.Atan2(lastMoveDirection.y, lastMoveDirection.x) * Mathf.Rad2Deg + 90;
        weapon.transform.localRotation = Quaternion.Euler(0, 0, angle);

        // Ataque
        weapon.SetActive(true);

        yield return new WaitForSeconds(sword.attackDuration);
        
        weapon.SetActive(false);
        isAttacking = false;
    }


}
