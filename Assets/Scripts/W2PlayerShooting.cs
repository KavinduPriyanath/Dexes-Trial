using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W2PlayerShooting : MonoBehaviour
{
    [SerializeField] private float damage = 10f;

    [SerializeField] private float range = 100f;

    [SerializeField] private Camera fpsCam;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();
        }
    }

    /*
    private void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            TargetW2 target = hit.transform.GetComponent<TargetW2>();

            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }*/
}
