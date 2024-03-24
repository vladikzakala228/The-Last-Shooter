using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int max_health;
    public int health;
    public GameObject Player;
    public GameObject bullet;
    public Transform showPoint;
    public float offset;
    public AudioSource Death_Sound, Get_Damaged, Shoot_Sound;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private Animator animator;
    public float deathanim;

    private void Start()
    {
        animator = GetComponent<Animator>();
        health = max_health;
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
                Shoot_Sound.Play(0);
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
            Death_Sound.Play(0);
            Destroy(gameObject, deathanim);
        }
    }
    public void TakeDamage(int damage)
    {
        animator.SetBool("GetHit", true);
        Get_Damaged.Play(0);
        health -= damage;
        Invoke("DisableGetHit", 0.4f);
    }

    public void HealEnemy(int heal)
    {
        if (health < max_health) { 
            health += heal;
        }
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
