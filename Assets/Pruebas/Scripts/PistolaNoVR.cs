using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PistolaNoVR : MonoBehaviour
{
     // Bullets
    //private int maxBullets = 20;
    //public int bullets;
    public bool usingBullets = false;
    
    public GameObject bulletPrefab;

    private int bulletDamage = 20;
    // RB
    public Rigidbody body;

    // Gun properties
    public Transform barrelTip;

    // Sound
    public AudioClip shootSound;
    public float shootVolume = 1f;

    // Raycast
    public float raycastDistance = 50f;
    public Color rayColor = Color.red;
    

    private void Start()
    {
        if (body == null && GetComponent<Rigidbody>() != null)
            body = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shoot();
    }


    public void Shoot()
    {

        if (usingBullets && GameManager.instance.bullets <= 0) return;
        
        //Play the audio sound
        if (shootSound)
            AudioSource.PlayClipAtPoint(shootSound, transform.position, shootVolume);
            
        //Make a RayCast
        RaycastHit hit;
        if (Physics.Raycast(barrelTip.position, barrelTip.forward, out hit, raycastDistance))
        {
            
            // If the raycast hits something, print the hit info
            // Debug.Log("Raycast hit: " + hit.collider.name);
            var hitBody = hit.transform.GetComponent<Rigidbody>();
            if (hitBody != null)
            {
                hitBody.GetComponent<Target>()?.OnHitTarget();
                hitBody.GetComponent<Zombie>()?.TakeDamage(bulletDamage);
               
            }
        }

        //Make some recoil
        //body.AddForce(barrelTip.transform.up * recoilPower * 5, ForceMode.Impulse);

        if (usingBullets)
        {
            GameManager.instance.bullets--;
            //Esto del game manager no se si funcione pero ojala y si
            GameManager.instance.ChangeBulletText(GameManager.instance.bullets);
        }
        
    }

}
