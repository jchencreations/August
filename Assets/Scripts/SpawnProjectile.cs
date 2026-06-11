using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnProjectile : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject effectToSpawn;
    public GameObject playerDirection;
    public Animator animator;
    public float fireDiff;
    private float timeToFire=0;

    public static int shots = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //on click, make sure cooldown is surpassed, and not clicking on UI
        if(Input.GetMouseButton(0) && Time.time >= timeToFire && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            //Shoot max shots # of times in platformer and infinite in other rooms
            if (SceneManager.GetActiveScene().name.Equals("Platformer"))
            {
                if (shots > 0)
                {
                    timeToFire = Time.time + fireDiff;
                    SpawnVFX();
                    shots--;
                }
            }
            else
            {
                timeToFire = Time.time + fireDiff;
                SpawnVFX();
            }
        }
    }

    void SpawnVFX()
    {
        GameObject vfx;

        //Protect against nullPointerException
        if(firePoint != null)
        {
            //Spawn VFX
            vfx = Instantiate(effectToSpawn, firePoint.transform.position, Quaternion.identity);
            //Set rotation of the projectile to be only forward
            vfx.transform.rotation = playerDirection.transform.rotation;
            animator.SetTrigger("Fire");
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
