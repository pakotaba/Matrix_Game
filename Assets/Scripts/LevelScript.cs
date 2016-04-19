using UnityEngine;
using System.Collections;

public class LevelScript : MonoBehaviour {

    public int Level = 1;
    public int Min = 0;
    public int Max = 20;
    public float minSpeed = 1;
    public float maxSpeed = 5;
    public float SpawnRate = 0.5f;
	
	void Start ()
	{
		ChangeLevel (1);
	}
	public void ChangeLevel(int _level)
	{
		Min = (_level - 1) * 20;
		Max = _level * 20;
	}
	public void ActivateLevel()
    {
        GlobalParams.curranteLevel = Level;
        GlobalParams.MinSum = Min;
        GlobalParams.MaxSum = Max;
        GlobalParams.minSpeed = minSpeed;
        GlobalParams.maxSpeed = maxSpeed;
        GlobalParams.SpawnRate = SpawnRate;
        print("agia magi" +GlobalParams.SpawnRate);
    }

	void Update ()
	{
	
	}
}
