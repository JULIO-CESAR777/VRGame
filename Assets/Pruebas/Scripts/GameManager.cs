using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

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

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        // VR
        //bulletText = GameObject.Find("BulletText").GetComponent<TextMeshProUGUI>();
        //pointsText = GameObject.Find("PointsText").GetComponent<TextMeshProUGUI>();
        //lifeText = GameObject.Find("HealthTextNVR").GetComponent<TextMeshProUGUI>();

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

    public void ChangePointsText(int addPoints) {
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
        AddBullets(someBullets);
        ChangeBulletText(bullets);
    }

    private void AddBullets(int extraBullets) { 
        bullets += extraBullets;
        if (bullets >= maxBullets) bullets = maxBullets;
    }

    public void DmgPlayer(int dmg) { 
        life -= dmg;

        if(life <= 0) ChangeDeathScene();

        ChangeLifeText(life);
    }

    public void HealPlayer(int healing) { 
        life += healing;
        if(life >= 100) life = 100;
        ChangeLifeText(life);
    }

}
