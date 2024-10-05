using UnityEngine;
using Random = UnityEngine.Random;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int damage = Random.Range(5, 10);
            HealthBar.Instance.DamagePlayer(damage);
        }
    }
}
