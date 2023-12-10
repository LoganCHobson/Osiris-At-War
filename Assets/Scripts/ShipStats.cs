using UnityEngine;

[CreateAssetMenu(fileName = "ShipStats", menuName = "Create Ship Stats")]
public class ShipStatsSO : ScriptableObject
{
    public float speed;
    public int health;
    public int weaponAmount;
    public float damage;
    public float fireRate;
}
