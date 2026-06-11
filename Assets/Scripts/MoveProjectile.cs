using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public float speed;
    public GameObject muzzle;
    public GameObject impact;

    // Start is called before the first frame update
    void Start()
    {
        //Spawn muzzle flash vfx effect
        var muzzleVFX = Instantiate(muzzle, transform.position, Quaternion.identity);
        Destroy(muzzleVFX, muzzleVFX.GetComponent<ParticleSystem>().main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        //Move projectile forward
        transform.position += transform.forward * (speed * Time.deltaTime);
    }

    //Delete Projectile when colliding with something, then play the flash
    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;

        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point;

        var impactVFX = Instantiate(impact, pos, Quaternion.identity);
        Destroy(impactVFX, impactVFX.GetComponent<ParticleSystem>().main.duration);  

        Destroy(gameObject);
    }
}
