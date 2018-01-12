using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour {
    public Image Bar;
    public float maximumHealth = 100f;
    public float health = 0f;
	// Use this for initialization
	void Start () {
        this.health = maximumHealth;
        //InvokeRepeating("decreaseHealth",0f,2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void decreaseHealth()
    {
        health -= 25f;
        float newHealth = health / maximumHealth;
        setHealth(newHealth); 
    }

    public void setHealth(float myhealth)
    {
        Bar.fillAmount = myhealth;
    }

    /*void Update()
    {
        //updateHealth(health);
    }*/

    /*public void updateHealth(float health)
    {
        float amount = (health / 100.0f) * 180.0f / 360;
        Bar.fillAmount = amount;
    }*/
}
