using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is player 1 control - good player
// Uses Arrow Keys
public class PlayControl1 : MonoBehaviour
{
  private Player player;

  void Awake() {
    player = GetComponent<Player>();   
    if(!player) {
      Debug.Log("No Object of type Player found!");
    }
  }
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.UpArrow)) {
      player.Jump();
    }      
    else if(Input.GetKeyDown(KeyCode.DownArrow)) {
      player.ClimbStairs();
    }
    else if(Input.GetKey(KeyCode.LeftArrow)) {
      player.Move(-1, 0);
    }
    else if(Input.GetKey(KeyCode.RightArrow)) {
      player.Move(1, 0);
    }
  }
}
