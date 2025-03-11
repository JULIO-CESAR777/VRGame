using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    //UI
    public TextMeshProUGUI bulletText;
    public TextMeshProUGUI lifeText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        bulletText = GameObject.Find("BulletText").GetComponent<TextMeshProUGUI>();
        //lifeText = GameObject.Find("LifeText").GetComponent<TextMeshProUGUI>();
    }

    public void ChangeBulletText(int amount)
    {
        bulletText.text = amount.ToString();
    }

    public void ChangeLifeText(int amount)
    {
        //lifeText.text = amount.ToString();
    }

    public void ChangeDeathScene()
    {
        //Cambia a escena de muerte jijijjiijiji
    }


}
