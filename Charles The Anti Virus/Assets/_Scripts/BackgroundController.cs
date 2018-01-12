using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    // PRIVATE INSTANCE VARIABLES
    [SerializeField] private float rightPosition;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float leftBoundary;


    // Use this for initialization
    void Start()
    {
        this._reset();
    }

    // Update is called once per frame
    void Update()
    {
        float newHorizontalPosition = transform.position.x - this.horizontalSpeed;
        transform.position = new Vector2(newHorizontalPosition, 0f);
        this._checkBounds();
    }

    /// <summary>
    /// Reset the vertical position of the ocean object to the top position
    /// </summary>
    private void _reset()
    {
        transform.position = new Vector2(this.rightPosition, 0f);
    }

    /// <summary>
    /// Checks if the ocean reaches the Top Boundary of the Screen.
    /// Then calls the _reset method.
    /// </summary>
    private void _checkBounds()
    {
        if (transform.position.x <= this.leftBoundary)
        {
            this._reset();
        }
    }


}


//Background Plane border is 439px x -438px