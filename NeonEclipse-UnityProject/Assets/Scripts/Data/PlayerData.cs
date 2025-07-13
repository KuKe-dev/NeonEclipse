using UnityEngine;

[CreateAssetMenu(menuName = "Data/Player")]
public class PlayerData : ScriptableObject
{
    public float speed = 10f;
    public float knockbackStunTime = 0.1f;
}
