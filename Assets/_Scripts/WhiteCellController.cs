using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCellController : MonoBehaviour {

    [SerializeField] private float resetPosition;
    [SerializeField] private float horizontalSpeed;
    //[SerializeField] private float horizontalBorder;
    [SerializeField] private float verticleBorder;


    // Use this for initialization
    void Start()
    {
  
        this._reset();
    }

    // Update is called once per frame
    void Update()
    {
        //float newVerticalPosition = transform.position.y - this.verticalSpeed;
        //transform.position = new Vector2(transform.position.x, newVerticalPosition);
        //this._checkBounds();

        float newHorizontalPosition = transform.position.x - this.horizontalSpeed;
        transform.position = new Vector2(newHorizontalPosition,transform.position.y);
        this._checkBounds();
    }
    //collision detection, once detected, reset position of cell, Could be used for powerups
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    _reset();
    //}

    private void _reset()
    {
        //float randomHorizontalPosition = Random.Range(-horizontalBorder, horizontalBorder);
        //transform.position = new Vector2(randomHorizontalPosition, this.resetPosition);

        float randomVerticlePosition = Random.Range(verticleBorder, -verticleBorder);

        // TODO: modify the starting x position
        transform.position = new Vector2(this.resetPosition + 4000, randomVerticlePosition);
    }

    private void _checkBounds()
    {
        if (transform.position.x <= -this.resetPosition)
        {
            this._reset();
			Debug.Log ("Hello");
        }
    }
}
