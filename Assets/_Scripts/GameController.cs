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
    public int pointsToWin = 500;

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

		this._whiteBloodCell = new List<GameObject>();
		//creating pool of bacteria to keep track of amount of bacteria
		for (int i = 0; i < this.WhiteBloodCellAmount; i++)
		{
			this._bacteria.Add(Instantiate(WhiteBloodCell));
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

        // TODO: check if going to next level
        if (this._points > pointsToWin)
        {
            //Loads the video for the boss level introduction
            SceneManager.LoadScene("BossIntro");
        }

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
        if (this.GetLifePoints() <=0)
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

	public void BacteriaKilled() {
		SetPoints (GetPoints () + 5, true);
	}
}

//Notes to self
//Try to spawn bacteria at a random rate, but will spawn more according to total amount of score 