using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct Range
{
    public float min;
    public float max;
}

public class BacteriaController : MonoBehaviour {

    // FIELDS
    private float _verticalSpeed;
    private float _horizontalSpeed;
	public int maxHp = 2;
	public int hp;

    [SerializeField] private float resetPosition; //horizontal reset position
    [SerializeField] private float resetPosition2; //Verticle reset position
    [SerializeField] private Range horizontalSpeed;
    [SerializeField] private Range verticalSpeed;
    [SerializeField] private float verticalBorder;
    [SerializeField] private float horizontalBorder;

    // TODO: new variables we need
    private float initialVerticalPosition;
    private float verticalDistance = 250;

    // Use this for initialization
    void Start()
    {
        //this.Height = gameObject.GetComponent<Renderer>().bounds.extents.y;
        //this.IsColliding = false;
        //this.Name = "Cloud";
        this._reset();
    }

    // Update is called once per frame
    void Update()
    {
        float newVerticalPosition = transform.position.y - this._verticalSpeed;
        float newHorizontalPosition = transform.position.x - this._horizontalSpeed;
        //(X,Y)
        transform.position = new Vector2(newHorizontalPosition, newVerticalPosition);

        // TODO: check position and maybe change verticalSpeed
        if (Mathf.Abs(transform.position.y - initialVerticalPosition) > verticalDistance)
        {
            _verticalSpeed = -_verticalSpeed;
        }

        this._checkBounds();
    }

    private void _reset()
    {
		// reset hp to maxHp
		hp = maxHp;

        //Random speed for x,and y movements
        // TODO: changed reset method
        //this._horizontalSpeed = Random.Range(this.horizontalSpeed.min, this.horizontalSpeed.max);
        this._horizontalSpeed = this.horizontalSpeed.min;
        this._verticalSpeed = Random.Range(this.verticalSpeed.min, this.verticalSpeed.max);

        //Limit y axis where bacteria spawns (380, -380)
        float randomVerticlePosition = Random.Range(verticalBorder, -verticalBorder);

        transform.position = new Vector2(this.resetPosition, randomVerticlePosition);
        //transform.Rotate(0.0f, 0.0f, Random.Range(0, 360));
        //var randomScale = Random.Range(0.5f, 1.0f);
        //transform.localScale = new Vector2(randomScale, randomScale);

        // TODO: record initial y position
        initialVerticalPosition = transform.position.y;
    }

    private void _checkBounds()
    {
        //Checks to see if bacteria reachers the end
        if (transform.position.x <= -this.resetPosition || transform.position.y <= -this.resetPosition2)
        {
            this._reset();
        }

    }

	public void Hit() {
		// what happens when the enemy is hit by a bullet
		hp--;
		if (hp <= 0) {
			// what happens when the enemy is hit *then* dies
			_reset ();
			GameObject.Find ("GameController").SendMessage ("BacteriaKilled");
		}
	}
}
