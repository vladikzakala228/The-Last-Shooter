using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public GameObject Player;
    public GameObject bullet;
    public Transform showPoint;
    public float offset;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Animator animator;
    public float deathanim;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Player.transform.position) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        showPoint.transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        float difference_x = Player.transform.position.x - transform.position.x;

        if (difference_x >= -8.6f || difference_x >= 8.6f)
        {
            if (timeBtwShots <= 0)
            {
                animator.SetBool("IsAttacking", true);
                Invoke("DisableAttack", 0.4f);
                Instantiate(bullet, showPoint.position, showPoint.transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
        if (health <= 0)
        {
            animator.SetBool("IsDead", true);
            Destroy(gameObject, deathanim);
        }
    }
    public void TakeDamage(int damage)
    {
        animator.SetBool("GetHit", true);
        health -= damage;
        Invoke("DisableGetHit", 0.4f);
    }

    public void HealEnemy(int heal)
    {
        health += heal;
    }

    private void DisableGetHit()
    {
        animator.SetBool("GetHit", false);
    }

    private void DisableAttack()
    {
        animator.SetBool("IsAttacking", false);
    }
}
