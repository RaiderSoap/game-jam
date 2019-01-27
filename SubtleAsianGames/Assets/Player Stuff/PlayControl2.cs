using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is player 2 control - good player
// Uses WASD Keys.
public class PlayControl2 : MonoBehaviour
{
  private Player player;

  void Awake() {
    player = GetComponent<Player>();   
    if(!player) {
      Debug.Log("No Object of type Player found!");
    }
    player.SetTeam(Player.team.BAD);
  }
  void Update()
  {
    if(Input.GetKeyDown(KeyCode.W)) {
    //  player.Jump();
      player.DropObject();
    }      
    else if(Input.GetKeyDown(KeyCode.S)) {
      player.ClimbStairs();
    }
    else if(Input.GetKey(KeyCode.A)) {
      player.Move(-1, 0);
    }
    else if(Input.GetKey(KeyCode.D)) {
      player.Move(1, 0);
    }
  }
}
