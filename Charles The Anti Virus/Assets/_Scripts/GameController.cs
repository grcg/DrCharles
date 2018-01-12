using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    //Public Fields
    //public int minSpawn;
    //public int maxSpawn;

    //Audio source
    public AudioSource goodSound;
    public AudioSource badSound;
    //Bacteria spawn num
    public GameObject Bacteria;
    public int bacteriaNumber;
    //display txt: life and score
    public Text PointsLabel;
    public Text LifePoints;
    //Private Fields
    private List<GameObject> _bacteria;
    private int _points;
    private int _lifePoints;


    // Use this for initialization
    void Start () {
        //bacteriaNumber = Random.Range(minSpawn, maxSpawn);
        this.goodSound.Stop();
        this.badSound.Stop();
        //Set scores and life points to default values of 0 and 100
        //if using these sound will play in beginning
        this.SetPoints(0, false);
        this.SetLifePoints(100, false);

        this._bacteria = new List<GameObject>();
        //creating pool of bacteria to keep track of amount of bacteria
        for (int i = 0; i < this.bacteriaNumber; i++)
        {
            this._bacteria.Add(Instantiate(Bacteria));
        }
	}
	
	// Update is called once per frame
	void Update () {
        //bacteriaNumber = Random.Range(minSpawn, maxSpawn);

    }

    //Set score 
    public void SetPoints(int points, bool playsound)
    {
        this._points = points;
        this.PointsLabel.text = "POINTS: " + points;
        //When true play the sound fx
        if (playsound)
        {
            this.goodSound.Play();
        }
    }
    //Set Life Points
    public void SetLifePoints(int lifePoints, bool playSound)
    {
        this._lifePoints = lifePoints;
        this.LifePoints.text = "Life: " + lifePoints;
        //When true play the sound fx
        if (playSound)
        {
            this.badSound.Play();
        }
        //If lives depletes to zero then lose condition activates, goes to end scene
        if (this.GetLifePoints() <=0)
        {
            SceneManager.LoadScene("End");
            //Add losing sound
        }
    }
    //gets points
    public int GetPoints()
    {
        return this._points;
    }
    //gets life points
    public int GetLifePoints()
    {
        return this._lifePoints;
    }
}

//Notes to self
//Try to spawn bacteria at a random rate, but will spawn more according to total amount of score 