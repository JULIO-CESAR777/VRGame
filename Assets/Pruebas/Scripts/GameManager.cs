using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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
        //lifeText = GameObject.Find("HealthTextNVR").GetComponent<TextMeshProUGUI>();

        // No VR
        bulletText = GameObject.Find("BulletCountNVR").GetComponent<TextMeshProUGUI>();
        pointsText = GameObject.Find("PointsTextNVR").GetComponent<TextMeshProUGUI>();
        lifeText = GameObject.Find("HealtTextNVR").GetComponent<TextMeshProUGUI>();

        //points = 0;
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
        bulletText.text = amount.ToString() + "/20";
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
        // Definir la intensidad inicial
        float intensity = 0.4f;

        // Habilitar el Vignette y establecer su intensidad
        _vignette.active = true;
        _vignette.intensity.value = intensity;

        // Esperar 0.4 segundos
        yield return new WaitForSeconds(0.35f);

        // Reducir gradualmente la intensidad hasta llegar a 0
        while (intensity > 0)
        {
            intensity -= 0.01f;

            if (intensity < 0)
                intensity = 0;

            _vignette.intensity.value = intensity;

            print("se esta modificando alv");

            // Esperar 0.1 segundos entre cada decremento
            yield return new WaitForSeconds(0.1f);
        }

        // Desactivar el Vignette una vez que la intensidad llega a 0
        _vignette.active = false;
        yield break;
    }

    public void HealPlayer(int healing) { 
        life += healing;
        if(life >= 100) life = 100;
        ChangeLifeText(life);
    }



}
