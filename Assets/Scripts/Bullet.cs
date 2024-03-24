using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    public float animationHit;
    public AudioSource Hitted_Sound;
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
            if (hitInfo.collider.CompareTag("Player") != true)
            {
                if (!Hitted_Sound.isPlaying)
                {

                    Hitted_Sound.Play();
                }
                if (hitInfo.collider.CompareTag("Enemy") && canHit)
                {
                    hitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                    canHit = false;
                }
                animator.SetBool("isHitted", true);
                
                Destroy(gameObject, animationHit);
            }
            else
            {
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
    }
}
