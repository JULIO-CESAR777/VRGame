using System;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    private int maxLife = 100;
    private int life;

    private int points;

    private void Awake()
    {
        life = maxLife;
        points = 0;
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy")) HitPlayer(10); //Aqui se podria agregar que entra a una funcion
        // donde saca el danio de cada enemigo dependiendo de que se le haya dado
    }

    public void HitPlayer(int damage)
    {
        //Condicionales
        life -= damage;
        ChangeLifeText(life);
        
        if (life >= 0f) GameManager.instance.ChangeDeathScene();
    }

    public void AddLife()
    {
        life += 20;
        if(life >= maxLife) life = maxLife;
        ChangeLifeText(life);
    }

    private void ChangeLifeText(int newLife)
    {
        GameManager.instance.ChangeLifeText(newLife);
    }


    public void WinPoints()
    {
        points += 20;
        
    }

}
