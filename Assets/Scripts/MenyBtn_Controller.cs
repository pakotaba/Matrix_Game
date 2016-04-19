using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenyBtn_Controller : MonoBehaviour {

    public GameObject ExtendedSettings;
   
    public void StartGame()
    {
        Application.LoadLevel("Game");

        
        
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Clouds").gameObject.transform.position.x > -9 && GameObject.FindGameObjectWithTag("Clouds").gameObject.transform.position.x < 9)
        { GameObject.FindGameObjectWithTag("Clouds").gameObject.transform.position = new Vector2(GameObject.FindGameObjectWithTag("Clouds").gameObject.transform.position.x + 1, GameObject.FindGameObjectWithTag("Clouds").gameObject.transform.position.y); }


    }

    public void ShowOrHideExtendedSettings()
    {
        
            ExtendedSettings.SetActive(!ExtendedSettings.activeInHierarchy);

    }


}
