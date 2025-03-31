using System;
using Autohand.Demo;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pistola : MonoBehaviour
{
    
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private int bulletDamage = 20; 
    
    // RB
    public Rigidbody body;

    // Gun properties
    public Transform barrelTip;
    public float hitPower = 1;
    public float recoilPower = 1;
    public LayerMask layer;

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
    
    public void Shoot()
    {

        if (GameManager.instance.usingBullets && GameManager.instance.bullets <= 0) return;
        
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
        body.AddForce(barrelTip.transform.up * recoilPower * 5, ForceMode.Impulse);

        if (GameManager.instance.usingBullets)
        {
            GameManager.instance.bullets--;
            //Esto del game manager no se si funcione pero ojala y si
            GameManager.instance.ChangeBulletText(GameManager.instance.bullets);
        }
        
    }

}
