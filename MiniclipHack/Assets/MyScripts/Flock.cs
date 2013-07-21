using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Flock : MonoBehaviour {

	// Use this for initialization
	int _numberOfBirds = 5;
	
	
	public Bird birdPrefab;
	public Bird[] _birds;
	
	void Awake()
	{
		Random.seed = (int)(Time.time*1000);
	}
	
	void Start () {
	
		_birds = new Bird[_numberOfBirds];
		
		for(int i = 0; i < _numberOfBirds; i++)
		{
			int rX = Random.Range(-_numberOfBirds,_numberOfBirds);
			int rY = Random.Range(0-_numberOfBirds,_numberOfBirds);
			 //Debug.Log("random number: " + rX + " " + rY);
			_birds[i] = Instantiate(birdPrefab,new Vector3(i%5, i/5, 0), birdPrefab.transform.rotation ) as Bird;
			_birds[i].setID(i);
			_birds[i].setFlock(this);
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	//	gameObject.transform.Translate(-gameObject.transform.position + _birds[0].transform.position); 
		//Debug.Log("FLock pos: " + gameObject.transform.position);
		//Debug.Log("Bird0 pos: " + _birds[0].transform.position);
	}
	/*
	public  ArrayList<ArrayList> getNeighbours(Bird bird)
	{
		Vector3 birdPosition = bird.transform.position;
		float birdSquareRadius = bird.getRadius();
		birdSquareRadius *= birdSquareRadius;
		float birdDirection = bird.getDirection();
		float birdAngleOfPerception = bird.getAngle();
		ArrayList birdsInNeighbourhood = new ArrayList<ArrayList>();
		birdsInNeighbourhood.Add(getNeighbours(bird, bird.getSeparationRange()));
		
		birdsInNeighbourhood.Add(getNeighbours(bird, bird.getAlignementRange()));
		
		birdsInNeighbourhood.Add(getNeighbours(bird, bird.getCohesionRange()));
		
		return birdsInNeighbourhood;
	}
	*/
	public  List<Bird> getNeighbours(Bird bird, float distance)
	{
		Vector3 birdPosition = bird.transform.position;
		float birdSquareRadius = distance;
		birdSquareRadius *= birdSquareRadius;
		float birdDirection = bird.transform.eulerAngles.z;//bird.getDirection();
		float birdAngleOfPerception = bird.getAngle();
		List<Bird> birdsInNeighbourhood = new List<Bird>();
		foreach (Bird b in _birds)
		{
			if(bird.getID() == b.getID())
				continue;
			
			Vector3 bPosition = b.transform.position;
			
			float diffX = bPosition.x - birdPosition.x;
			float diffY = bPosition.y - birdPosition.y;
			//check in range
			
			if(diffX*diffX + diffY*diffY <= birdSquareRadius)
			{
				
				//check if in correct angle interval
				//float arcTanInDegrees = Mathf.Atan2(diffY , diffX )  * 180 / Mathf.PI;
				
			//Debug.Log(diffX + " " + diffY + " " + birdSquareRadius + " " + arcTanInDegrees);
				//if( Utils.angle_between(	(int)arcTanInDegrees,
				//					(int)(birdDirection + birdAngleOfPerception/2), 
				//					(int)(birdDirection - birdAngleOfPerception/2) ) )
				{
					//Debug.Log("im in");
					birdsInNeighbourhood.Add(b);
				}
			}
		}
		
		return birdsInNeighbourhood;
	}
	
	
}
