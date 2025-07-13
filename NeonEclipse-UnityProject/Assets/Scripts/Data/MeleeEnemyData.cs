using UnityEngine;

[CreateAssetMenu(menuName = "Data/MeleeEnemy")]
public class MeleeEnemyData : ScriptableObject
{
    public float speed = 4f;
    public float detectionRange = 10f;
    public float stunTime = 0.5f;
}
