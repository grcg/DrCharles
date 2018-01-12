using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    //Public properties 
    public GameController gameController;
    //Borders
    public float LeftBoundary;
    public float RightBoundary;
    public float TopBoundary;
    public float BottomBoundary;


    //Public methods


    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        float mousePosX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        Vector3 mousepositionX = new Vector3(mousePosX, 0f, 0f);
        if (mousepositionX.x > this.RightBoundary)
        {
            mousepositionX.x = this.RightBoundary;
        }
        if (mousepositionX.x < this.LeftBoundary)
        {
            mousepositionX.x = this.LeftBoundary;
        }


        float mousePosY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
        Vector3 mousepositionY = new Vector3(0f, mousePosY, 0f);
        if (mousepositionY.y > this.TopBoundary)
        {
            mousepositionY.y = this.TopBoundary;
        }
        if (mousepositionY.y < this.BottomBoundary)
        {
            mousepositionY.y = this.BottomBoundary;
        }
        //every frame sets the player's position to the mouse position
        transform.position = mousepositionX + mousepositionY;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag =="WhiteBloodCell")
        {
            gameController.SetPoints(gameController.GetPoints() + 25, true);
            Debug.Log("Collided with White Cell");           
        }
        if (collision.gameObject.tag == "Bacteria")
        {
            gameController.SetLifePoints(gameController.GetLifePoints() - 5, true);
            Debug.Log("Collided with Bacteria");

        }
    }
}
