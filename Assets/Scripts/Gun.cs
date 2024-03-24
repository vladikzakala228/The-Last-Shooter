using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float offset;
    public GameObject bullet;
    public Transform showPoint;
    public AudioSource Shoot_Sound, Reloud_Sound;

    private float timeBtwShots;
    public float startTimeBtwShots;

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, showPoint.position, transform.rotation);
                Shoot_Sound.Play(0);
                Invoke("Play_Reloud_Sound", 0.9f);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    private void Play_Reloud_Sound()
    {
        Reloud_Sound.Play(0);
    }
}
