using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    //UI
    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI lifeText;

    public int points;

    public int bullets = 20;
    private int maxBullets = 20; 
    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        bulletText = GameObject.Find("BulletText").GetComponent<TextMeshProUGUI>();
        points = 0;
        bullets = maxBullets;
        //lifeText = GameObject.Find("LifeText").GetComponent<TextMeshProUGUI>();
    }

    public void ChangeBulletText(int amount)
    {
        bulletText.text = amount.ToString() + "/20";
    }

    public void ChangeLifeText(int amount)
    {
        //lifeText.text = amount.ToString();
    }

    public void ChangeDeathScene()
    {
        //Cambia a escena de muerte jijijjiijiji
    }

    public void losePoints(int losepoints) { 
        points -= losepoints;
        
    }


}
