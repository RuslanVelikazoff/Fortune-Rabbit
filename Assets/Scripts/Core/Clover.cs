using UnityEngine;

public class Clover : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            StatsPanel.Instance.CollectClover();
        }
    }
}
