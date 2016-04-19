using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

     float Speed;
	int jami;
	bool clicked = false;
    void Start() {

        Speed = Random.Range(GlobalParams.minSpeed, GlobalParams.maxSpeed);
    }
       
        public void showExample()
       {
        gameObject.name = "WithExample";
        GlobalParams.WithExample = true;

        jami = Random.Range(GlobalParams.MinSum, GlobalParams.MaxSum);
        GlobalParams.CorrectAnsw = jami;
        int pirveli = Random.Range(0, jami);
        int meore = jami - pirveli;
        string magaliti = pirveli + "+" + meore;

        gameObject.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = magaliti;

    }
   
	void Update () {

        gameObject.transform.Translate(new Vector2(0, 1) * Speed);
	
	}

   void OnBecameInvisible()
    {
        if(gameObject.name == "WithExample")
        {
          GlobalParams.WithExample = false;
		  if(!clicked)
         	 GlobalParams.Passedblns++;
        }
        
        Destroy(gameObject);
    }

    public void KillMe()
    {
		clicked = true;
        GetComponent<AudioSource>().Play();
		if (GlobalParams.levelChanged)
			GlobalParams.levelChanged = false;
		GlobalParams.Score+= jami;
        gameObject.GetComponent<Animator>().SetTrigger("TriggerBoom");
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
