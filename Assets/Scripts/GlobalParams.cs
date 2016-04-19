using UnityEngine;
using System.Collections;

public class GlobalParams : MonoBehaviour {

    
    public static bool WithExample = false;
    public static int MinSum = 1;
    public static int MaxSum = 100;
    public static int CorrectAnsw;
	public static bool levelChanged = false;
    public static GameObject BlnWithExample;
    public static int Score = 0;
    public static int Maxpassedblns = 5;
    public static int Passedblns = 0;
    public static float minSpeed = 0.01f;
    public static float maxSpeed = 0.07f;
    public static float SpawnRate = 0.5f;


    public static int curranteLevel = 1;
        
	
	void Start () 
	{
		ChangeLevel (curranteLevel);
	}

	public static void ChangeLevel(int _level)
	{
		MinSum = (_level - 1) * 20;
		MaxSum = _level * 20;
		minSpeed = _level *0.01f;
		maxSpeed = (_level +1) * 0.01f;
		SpawnRate = 3;
	}
	
	void Update () {
		if (Score > 50*curranteLevel && levelChanged == false) 
		{
			levelChanged = true;
			Debug.Log (curranteLevel);
			curranteLevel++;
			ChangeLevel (curranteLevel);
			Debug.Log (curranteLevel);
		}
	}
}
