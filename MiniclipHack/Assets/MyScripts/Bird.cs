using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bird : MonoBehaviour {
	
	float _cohesionRange = 8f;
	float _alignmentRange = 3f;
	float _separationRange = 26f;
	
	float _alignmentRatio = 0.1f;
	float _cohesionRatio = 0.1f;
	float _separationRatio = 0.1f;
	
	//float _coefficient = 1f;
	
	//ID
	int _ID;
	
	//Velocity
	Vector2 _velocity;
	float _maxVelocity;
	float _minVelocity;
	
	Vector2 _force;
	
	//Direction
	float _direction;
	
	//Radius of Influence
	float _radius;
	
	//Angle of perception
	int _angle;
	
	Flock _flock;
	
	
	//
	//GETTERS AND SETTERS
	//
	public void setID(int id)
	{
		_ID = id;
	}
	
	public void setFlock(Flock flock)
	{
		_flock = flock;
	}
	public void setVelocity(Vector2 vel)
	{
		//if(_flock)
			//Debug.Log("Setting velocity of flock bird to: " + vel);
		//else
			//Debug.Log("Setting velocity to: " + vel);
		_velocity = vel;
	}
	public void incVelocity(Vector2 vel)
	{
		
		_velocity += vel;
		
		//	if(_flock)
		//	Debug.Log("Inc velocity of flock bird to: " + _velocity);
		//else
		//Debug.Log("Inc velocity to: " + _velocity);
	}
	
	
	public float getCohesionRange()
	{
		return _cohesionRange ;
	}
	
	
	public float getAlignementRange()
	{
		return _alignmentRange;
	}
	
	public float getSeparationRange()
	{
		return _separationRange;
	}
	
	public int getAngle()
	{
		return _angle;
	}
	public float getRadius()
	{
		return _radius;
	}
	public float getDirection()
	{
		return _direction;
	}
	public Vector2 getVelocity()
	{
		return _velocity;
	}
	public float getMaxVelocity()
	{
		return _maxVelocity;
	}
	public float getMinVelocity()
	{
		return _minVelocity;
	}
	public int getID()
	{
		return _ID;
	}
	
	void Awake()
	{
		_direction = Random.Range(2, 3);
		_angle = 360;
		_minVelocity = -0.8f;
		_maxVelocity = 0.8f;

		_radius = _cohesionRange;
		_velocity = Vector2.zero;
		//_velocity = new Vector2(Random.Range(_minVelocity, _maxVelocity) ,Random.Range(_minVelocity, _maxVelocity));

		
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if(_flock)
		{
	
			
			List<Bird> fakedNeighbours = new List<Bird>();
			//if(_ID == 10)
			{
				
				
			GameObject[] capsules = GameObject.FindGameObjectsWithTag("MyCapsule");
			foreach(GameObject go in capsules)
			{
					//Debug.Log("adding mycapsule");
				fakedNeighbours.Add(go.GetComponent("Bird") as Bird);
			}
			}
				//Seperate(fakedNeighbours);
			List<Bird> neighbours =	_flock.getNeighbours(this, 3);
			foreach(Bird go in neighbours)
				fakedNeighbours.Add(go);
			
			if(fakedNeighbours.Count == 0)
				return;
			
		//	Cohese(fakedNeighbours);
			Seperate(fakedNeighbours);
			//Align(fakedNeighbours);
			
				
			
		}
		
			float xVel =  (_velocity.x + _force.x)*Time.fixedDeltaTime ;
			float yVel = (_velocity.y + _force.y)*Time.fixedDeltaTime;
			gameObject.transform.Translate(xVel,yVel,0,Space.World);
		
		
		FaceDirection(_velocity.x, _velocity.y);
		_force = Vector2.zero;
		
	}
	
	void FaceDirection(float xVel, float yVel)
	{
		float newRotation = transform.eulerAngles.z + 90;
		if(xVel != 0)
		{
			float newAngle = Mathf.Atan2(yVel,xVel);
			if(!float.IsNaN(newAngle))
				gameObject.transform.Rotate(new Vector3(0,0, Utils.RadToDeg(newAngle) - newRotation));
		}
		else
		{
			if(yVel == 0)
				return;
			
			if(yVel > 0)
			{
				gameObject.transform.Rotate(new Vector3(0,0,90 - newRotation));
			}
			else
			{
				gameObject.transform.Rotate(new Vector3(0,0,270 - newRotation));
			}
		}
	}
	
	void Align(List<Bird> neighbours)
	{
		
		int l = neighbours.Count;
		Vector2 newVelocity = Vector2.zero;
		//Debug.Log(l);
		foreach	(Bird b in neighbours)
		{
			
			newVelocity += b.getVelocity();// b.transform.eulerAngles;
			//Debug.Log("adding to new velocity: " + b.getVelocity());
			
		}		
		
		//Debug.Log("total new velocity: " + newVelocity);
		newVelocity = (newVelocity ) / (l) ;// transform.eulerAngles;
		
		
		newVelocity -= _velocity;		
		//Debug.Log("new velocity difference: " + newVelocity);
		
		
		newVelocity *= _alignmentRatio;
		//Debug.Log("new velocity scaled: " + newVelocity);
		
		
		//setVelocity(newVelocity);
	//pushForce(newVelocity);
		incVelocity(newVelocity);
		
	}
	

	void Seperate(List<Bird> neighbours)
	{
		int l = neighbours.Count;
		Vector2 force = Vector2.zero;// 0.0f;
		foreach(Bird b in neighbours)
		{
			float distX = transform.position.x - b.transform.position.x;
			float distY = transform.position.y - b.transform.position.y;
			float distance = (b.transform.position - transform.position).sqrMagnitude;
			//Debug.Log(distX + " " + distY + " " + distance);
			if(distance ==  0)
			{
				Debug.Log("SAME POSITION");
				force.x +=  Random.Range(-_separationRange, _separationRange);
				force.y += Random.Range(-_separationRange, _separationRange);
			}
			else
			{
				force.x += distX * (_separationRange - distance);
				force.y += distY *  (_separationRange - distance);
			}
			//force +=  _separationRange - Mathf.Sqrt( diffX*diffX + diffY * diffY);
		}
		force = force * _separationRatio / l;
		//Debug.Log("Seperating by: " + force  + " from " + l);
		//Debug.Log( _ID + "separating with "+ l + " other birds. in radius of:"+_radius+" " + " with force: " + force );
		
		pushForce(force);
		//incVelocity(force);
		
	}
	
	
	
	void Cohese(List<Bird> neighbours)
	{
		int l = neighbours.Count;
		Vector2 position = Vector2.zero;// transform.position;
		foreach(Bird b in neighbours)
		{
			position.x += b.transform.position.x;
			position.y += b.transform.position.y;
		}
		position.x = position.x / l;
		position.y = position.y / l;
		
		position = position - new Vector2(transform.position.x, transform.position.y);
		
		position *= _cohesionRatio;
		
		incVelocity(position);
		//pushForce(position);
	}
	
	void pushForce(Vector2 force)
	{
		_force += force;		
	}
}
