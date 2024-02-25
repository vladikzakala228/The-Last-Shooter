using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public int heal;
    public LayerMask whatIsSolid;
    public float animationHit;
    public GameObject particals;
    private Animator animator;
    private bool canHit = true;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player") && canHit)
            {
                hitInfo.collider.GetComponent<PlayerController>().TakeDamage(damage);
                canHit = false;
            }

            if (hitInfo.collider.CompareTag("Enemy") && canHit)
            {
                hitInfo.collider.GetComponent<Enemy>().HealEnemy(heal);
                Instantiate(particals,transform.position, Quaternion.identity);
                canHit = false;
            }
            animator.SetBool("IsHitted", true);
            Destroy(gameObject, animationHit);
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
