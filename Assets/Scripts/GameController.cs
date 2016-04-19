using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public enum GameStates
    {
        Playng,
        GameOver,
        GamePaused
    }

    GameStates GameState;
     float timer;
    float OldTimer;
    
    public List<GameObject> Blns;
    public List<GameObject> Btns;
    public List<int> RandomNums;
    public GameObject Gameover_Panel;

	float[] BlnArr = { -5.5f, -4, -2.5f,  -1,  1,  2.5f, 4,  5.5f };
    int BlnArrayIndex;
    void Start()
    {
		GlobalParams.ChangeLevel (1);
        timer = GlobalParams.SpawnRate;
        OldTimer = timer;

        GameState = GameStates.Playng;

        BlnArr.Shuffle();
		GameObject InstanceBln = Instantiate(Blns[Random.Range(0, Blns.Count)], new Vector2(BlnArr[BlnArrayIndex], -8), Quaternion.identity) as GameObject;

    }

    

    void GenerateBtnsNumbers()
    {


        List<int> numbers = new List<int>();

        // marto es shevcvalot diapazonistvis (11 is nacvlad unda chavcerot stagebis 6, 10 , 15 , 20)
        for (int i = GlobalParams.MinSum; i < GlobalParams.MaxSum; i++)
        {
            if (GlobalParams.CorrectAnsw != i)
            {
                numbers.Add(i);
            }

        }
        List<int> randomNumbers = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            int thisNumber = Random.Range(0, numbers.Count);
            randomNumbers.Add(numbers[thisNumber]);
            numbers.RemoveAt(thisNumber);
        }
        randomNumbers.Add(GlobalParams.CorrectAnsw);
        randomNumbers.Shuffle();

        for (int i = 0; i < Btns.Count; i++)
        {
            Btns[i].transform.GetChild(0).GetComponent<Text>().text = randomNumbers[i].ToString();
        }
    }
    void Update()
    {
        if (GameState == GameStates.GameOver) return;

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
         
            //კლონს რომ მივწვდეთ, ვაქცევთ "GameObject"-ად.
            if (BlnArrayIndex == BlnArr.Length-1)
            {
                BlnArr.Shuffle();
                BlnArrayIndex = 0;
                print("shuffli gaaketa");
            }
            else
                BlnArrayIndex++;

            GameObject InstanceBln = Instantiate(Blns[Random.Range(0, Blns.Count)], new Vector2(BlnArr[BlnArrayIndex], -8), Quaternion.identity) as GameObject;

            if (!GlobalParams.WithExample)
            {
                //მაშინ გამოვიძახოთ მაგალითიანი ბუშტი.
                InstanceBln.GetComponent<BallScript>().showExample();
                GenerateBtnsNumbers();
                GlobalParams.BlnWithExample = InstanceBln;
                
            }
            timer = OldTimer;
        }

        if(GameState != GameStates.GameOver && GlobalParams.Passedblns >= GlobalParams.Maxpassedblns)
        {
            
            Gameover_Panel.gameObject.SetActive(true);
			GlobalParams.Score = 0;
            GameState = GameStates.GameOver;
        }
        

    }

}

static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}