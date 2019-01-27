using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ScoreScript : MonoBehaviour
{    
    
    public static int scoreValue =  3;
    Text score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {    
        score.text = "Lives " + scoreValue;
        kidsWin();
    }
    
    void kidsWin()
    {
        if(scoreValue == 0){
            SceneManager.LoadScene("KidsWIn Scene", LoadSceneMode.Single);
        }
    }
}
