using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            int damage = Random.Range(10, 20);
            HealthBar.Instance.DamagePlayer(damage);
        }
    }
}
