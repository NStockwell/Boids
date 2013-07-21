using UnityEngine;
using System.Collections;

public static class Utils 
{
	
	static public float DegToRad(float deg)
	{
		return deg*Mathf.PI / 180;
	}
	
	public static float RadToDeg(float rad)
	{
		return rad* 180 / Mathf.PI;
	}
	
	public static bool angle_between(int angle, int angleA,int angleB)
	{
		
	angle = (360 + (angle % 360)) % 360;
	angleA = (3600000 + angleA) % 360;
	angleB = (3600000 + angleB) % 360;
		
		Debug.Log("angle_between: " + angle + " " + angleA + " " + angleB);
	if (angleA < angleB)
		return angleA <= angle && angle <= angleB;
	return angleA <= angle || angle <= angleB;
	}
	/// <summary>
	/// Ang_between the specified ang1e and angleOfTarget.
	/// </summary>
	/// <param name='ang1e'> bird.transoform.eulerangle.z
	/// If set to <c>true</c> ang1e.
	/// </param>
	/// <param name='angleOfTarget'>
	/// If set to <c>true</c> angle of target.
	/// </param>
	public static bool ang_between(int ang1e, int angleOfTarget, int angleRange)
	{
		float anglediff = (ang1e - angleOfTarget + 180) % 360 - 180;
		
		return (anglediff <= angleRange && anglediff>=-angleRange);
	}
	
	public static float squareDistance(Vector3 pos1, Vector3 pos2)
	{
		float diffX = pos1.x - pos2.x;
		float diffY = pos1.y - pos2.y;
		return diffX*diffX + diffY*diffY;
	}
	
}

