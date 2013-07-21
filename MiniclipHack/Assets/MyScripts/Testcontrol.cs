using UnityEngine;
using System.Collections;

public class Testcontrol : MonoBehaviour {
	
	float moveSpeed = 0.5f;
	float turnSpeed = 30f;
	Bird birdComponent;
	float yIncrement = 0.5f;
	float xIncrement = 0.5f;
	// Use this for initialization
	void Start () {
		birdComponent = GetComponent("Bird") as Bird;
	}
	
	// Update is called once per frame
	void Update () {
	
		if(Input.GetKey(KeyCode.W))
		{
			//Debug.Log("Uparrow");
			birdComponent.incVelocity(new Vector2(0,yIncrement));
            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
        if(Input.GetKey(KeyCode.S))
		{
			
			birdComponent.incVelocity(new Vector2(0,-yIncrement));
			//Debug.Log("Downarrow");
           // transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A))
		{
			//Debug.Log("Uparrow");
			birdComponent.incVelocity(new Vector2(-xIncrement,0));
            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
        if(Input.GetKey(KeyCode.D))
		{
			
			birdComponent.incVelocity(new Vector2(xIncrement,0));
			//Debug.Log("Downarrow");
           // transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.Space))
		{
			birdComponent.setVelocity(Vector2.zero);
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			//Debug.Log("Uparrow");
			birdComponent.setVelocity(Vector2.up);
            //transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
		}
        if(Input.GetKey(KeyCode.DownArrow))
		{
			
			birdComponent.setVelocity(-Vector2.up);
			//Debug.Log("Downarrow");
           // transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
		}
        if(Input.GetKey(KeyCode.LeftArrow))
		{
			
			birdComponent.setVelocity(-Vector2.right);
			//Debug.Log("Leftarrow");
			//transform.Rotate(Vector3.forward, turnSpeed * Time.deltaTime);
	}
        if(Input.GetKey(KeyCode.RightArrow))
         
		{
			
			birdComponent.setVelocity(Vector2.right);
			//Debug.Log("Rightarrow");
			//transform.Rotate(Vector3.forward, -turnSpeed * Time.deltaTime);
		}
	}
}
