using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossGameController : MonoBehaviour {

    //Public Fields
    //public int minSpawn;
    //public int maxSpawn;

    //Boss hp
    public int maxBossHp = 2;
    public int bossHp;

    //Audio source
    public AudioSource goodSound;
    public AudioSource badSound;
    //Bacteria spawn num
    public GameObject Bacteria;
    public int bacteriaNumber;
    public GameObject WhiteBloodCell;
    public int WhiteBloodCellAmount;
    //display txt: life and score
    public Text PointsLabel;
    //public Text LifePoints;
    //Private Fields
    private List<GameObject> _bacteria;
    private List<GameObject> _whiteBloodCell;

    private int _points;
    private int _lifePoints;

    // TODO: define next scene name
    public string nextScene;

    // Use this for initialization
    void Start()
    {
        //set score to w.e you had to switch scene or increment per hit on boss
        this.PointsLabel.text = "POINTS: " + 1000000;
        //bacteriaNumber = Random.Range(minSpawn, maxSpawn);
        this.goodSound.Stop();
        this.badSound.Stop();
        //Set scores and life points to default values of 0 and 100
        //if using these sound will play in beginning
        this.SetLifePoints(100, false);

        this._bacteria = new List<GameObject>();
        //creating pool of bacteria to keep track of amount of bacteria
        for (int i = 0; i < this.bacteriaNumber; i++)
        {
            this._bacteria.Add(Instantiate(Bacteria));
        }

        this._whiteBloodCell = new List<GameObject>();
        //creating pool of bacteria to keep track of amount of bacteria
        for (int i = 0; i < this.WhiteBloodCellAmount; i++)
        {
            this._bacteria.Add(Instantiate(WhiteBloodCell));
        }
    }

    // Update is called once per frame
    void Update()
    {
        //bacteriaNumber = Random.Range(minSpawn, maxSpawn);
    }

    //Set Life Points
    public void SetLifePoints(int lifePoints, bool playSound)
    {
        this._lifePoints = lifePoints;
        //this.LifePoints.text = "" + lifePoints;
        //When true play the sound fx
        if (playSound)
        {
            this.badSound.Play();
        }
        //If lives depletes to zero then lose condition activates, goes to end scene
        if (this.GetLifePoints() <= 0)
        {
            // TODO: write high score to storage
            PlayerPrefs.SetInt("highScore", this._points);
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

    private void _reset()
    {
        // reset hp to maxHp
        bossHp = maxBossHp;
        
    }

    public void Hit()
    {
        // what happens when the enemy is hit by a bullet
        bossHp--;
        if (bossHp <= 0)
        {
            // what happens when the enemy is hit *then* dies
            GameObject.Find("GameController").SendMessage("BacteriaKilled");
        }
    }

}

//Notes to self
//Try to spawn bacteria at a random rate, but will spawn more according to total amount of score 