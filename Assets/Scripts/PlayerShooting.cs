using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    [SerializeField] private float range = 100f;

    [SerializeField] private Camera fpsCam;

    [SerializeField] private GameObject diceBullet;
    [SerializeField] private Transform shotPoint;

    [SerializeField] private float upForce;
    [SerializeField] private float rightForce;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();
            ShootBullet();
        }
    }

    private void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }

    private void ShootBullet ()
    {
        Rigidbody rb = Instantiate(diceBullet, shotPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(shotPoint.right * upForce, ForceMode.Impulse);
        rb.AddForce(shotPoint.up * rightForce, ForceMode.Impulse);
        Destroy(rb.gameObject, 3f);
    }
}
