using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingObject : MonoBehaviour
{
  public float fallSpeed = 5f;
  bool falling = true;

  
  // Start is called before the first frame update
  void Start()
  {
    StartFalling();      
  }

  public void StartFalling() {
    StartCoroutine("Fall");
  }  

  void OnTriggerEnter2D(Collider2D col) {
    if(col.gameObject.tag == "Ground") {
      Debug.Log("hit ground");
      falling = false;
      ScoreScript.scoreValue = ScoreScript.scoreValue - 1;
      Debug.Log(ScoreScript.scoreValue);
    }
  }

  IEnumerator Fall() {
    while(falling) {
      float dt = Time.deltaTime;
      Vector3 pos = this.transform.position;
      pos.y -= fallSpeed * dt;
      this.transform.position = pos;
      yield return new WaitForSeconds(dt);
    }
  }
}
