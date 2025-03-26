using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    //UI
    [SerializeField] private TextMeshProUGUI bulletText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI pointsText;

    // Points
    public int points;

    // Bullets
    public int bullets = 20;
    private int maxBullets = 20;
    public bool usingBullets;

    //Life
    public int life;
    private int maxLife = 100;

    public float intensity = 0;

    private Volume _volume;  // El volumen con el efecto Vignette
    private Vignette _vignette;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        //Volume code
        _volume = GetComponent<Volume>();

        // Obtener el efecto Vignette dentro del perfil del Volume
        if (_volume.profile.TryGet<Vignette>(out _vignette))
        {
            // Si se encuentra, puedes empezar a modificar las propiedades del efecto
            Debug.Log("Efecto Vignette encontrado y listo para modificar.");
            _vignette.intensity.value = 0f;
        }
        else
        {
            Debug.LogError("No se encontró el efecto Vignette en el perfil del Volume.");
        }


        // VR
        //bulletText = GameObject.Find("BulletText").GetComponent<TextMeshProUGUI>();
        //pointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
        //lifeText = GameObject.Find("HealthText").GetComponent<TextMeshProUGUI>();

        // No VR
        bulletText = GameObject.Find("BulletCountNVR").GetComponent<TextMeshProUGUI>();
        pointsText = GameObject.Find("PointsTextNVR").GetComponent<TextMeshProUGUI>();
        lifeText = GameObject.Find("HealtTextNVR").GetComponent<TextMeshProUGUI>();

        points = 0;
        bullets = maxBullets;
        life = maxLife;


        ChangeBulletText(bullets);
        ChangePointsText(points);
        ChangeLifeText(life);


    }

    public void ChangePointsText(int addPoints = 0) {
        points += addPoints;
        pointsText.text = points.ToString();
    }

    public void ChangeBulletText(int amount)
    {
        if (GameManager.instance.usingBullets) bulletText.text = "infinite";

        // VR
        //bulletText.text = amount.ToString();
        // No VR
        bulletText.text = bullets.ToString() + "/20";
    }

    public void ChangeLifeText(int amount)
    {
        lifeText.text = "Health: " + amount.ToString();
    }

    public void ChangeDeathScene()
    {
        //Cambia a escena de muerte jijijjiijiji
        Debug.Log("murio");
    }

    public void BuyBullets(int losepoints, int someBullets) {
        if (points < losepoints) return;

        points -= losepoints;
        Debug.Log("points: " + points);
        AddBullets(someBullets);
        ChangeBulletText(bullets);
        ChangePointsText();
    }

    private void AddBullets(int extraBullets) { 
        bullets += extraBullets;
        if (bullets >= maxBullets) bullets = maxBullets;
    }

    public void DmgPlayer(int dmg) { 
        life -= dmg;

        if(life <= 0) ChangeDeathScene();
        StartCoroutine(ScreenEffect());
        ChangeLifeText(life);
    }

    private IEnumerator ScreenEffect() {

        float intensity = 0.4f;

        _vignette.active = true;
        _vignette.intensity.value = intensity;

        yield return new WaitForSeconds(0.35f);

        while (intensity > 0)
        {
            intensity -= 0.01f;

            if (intensity < 0)
                intensity = 0;

            _vignette.intensity.value = intensity;

            print("se esta modificando alv");

            yield return new WaitForSeconds(0.1f);
        }

        _vignette.active = false;
        yield break;
    }

    public void HealPlayer(int healing) { 
        life += healing;
        if(life >= 100) life = 100;
        ChangeLifeText(life);
    }



}
