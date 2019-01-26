using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    void Update()
  {
    if(Input.GetKeyDown(KeyCode.UpArrow)) {
      Debug.Log("Up");
    }      
    else if(Input.GetKeyDown(KeyCode.DownArrow)) {
      Debug.Log("Down");
    }
    else if(Input.GetKeyDown(KeyCode.LeftArrow)) {
      Debug.Log("Left");
    }
    else if(Input.GetKeyDown(KeyCode.RightArrow)) {
      Debug.Log("Right");
    }
  }
}
