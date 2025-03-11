using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PistolaNoVR : MonoBehaviour
{
     // Bullets
    private int maxBullets = 20;
    public int bullets;
    public bool usingBullets = false;
    
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    private Vector3 initialGunPosition;
    
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
    
    // Input Action
    public InputActionReference fire;

    private void OnEnable()
    {
        fire.action.started += Fire;
    }

    private void OnDisable()
    {
        fire.action.started -= Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        Shoot();
    }

    private void Start()
    {
        if (body == null && GetComponent<Rigidbody>() != null)
            body = GetComponent<Rigidbody>();
        bullets = maxBullets;
        
        //condicional para activar usando balas o no
        
    }


    public void Shoot()
    {

        Debug.Log("se esta disparando");
        if (usingBullets && bullets <= 0) return;
        
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
            }
        }

        //Make some recoil
        //body.AddForce(barrelTip.transform.up * recoilPower * 5, ForceMode.Impulse);

        if (usingBullets)
        {
            bullets--;
            //Esto del game manager no se si funcione pero ojala y si
            GameManager.instance.ChangeBulletText(bullets);
        }
        
    }

    public void AddBullets(int takeBullets)
    {
        bullets += takeBullets;
        if (bullets >= maxBullets) bullets = maxBullets;
    }
}
