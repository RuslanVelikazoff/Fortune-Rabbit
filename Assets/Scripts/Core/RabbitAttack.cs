using System.Collections;
using UnityEngine;

public class RabbitAttack : MonoBehaviour
{
    [SerializeField]
    private float attackDelay = 1f;

    private bool isAttack = false;
    
    private Animator playerAnimator;

    [SerializeField] 
    private SpawnRabbit spawnRabbit;

    private void Start()
    {
        playerAnimator = spawnRabbit.GetRabbitAnimator();
    }

    private void Update()
    {
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("IsAttack", isAttack);
        }
    }

    public void Attack()
    {
        if (!isAttack)
        {
            StartCoroutine(AttackCO());
            
            Collider2D[] enemies = Physics2D.OverlapCircleAll(this.gameObject.transform.position,
                1f, LayerMask.GetMask("Enemy"));
            for (int i = 0; i < enemies.Length; i++)
            {
                Destroy(enemies[i].gameObject);
            }
        }
    }

    private IEnumerator AttackCO()
    {
        isAttack = true;

        yield return new WaitForSeconds(attackDelay);

        isAttack = false;
    }
}
