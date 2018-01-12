using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



	void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log ("bullet collision");
		if (collider.gameObject.CompareTag ("Bacteria")) {
			//collider.gameObject.SendMessage("Hit");
			collider.gameObject.GetComponent<BacteriaController>().Hit();
			//calls the reset method
			//SendMesssage is used because _reset is private
			Destroy(gameObject);
		}

        Debug.Log("bullet boss collision");
        if (collider.gameObject.CompareTag("Boss"))
        {
            //collider.gameObject.SendMessage("Hit");
            collider.gameObject.GetComponent<BossBehaviour>().Hit();
            //calls the reset method
            //SendMesssage is used because _reset is private

            Destroy(gameObject);
            Debug.Log("Disappear");
        }
    }
}
