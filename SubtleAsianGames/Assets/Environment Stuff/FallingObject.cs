using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
  public float fallSpeed = 5f;
  public float rotateSpeed = 500f;
  bool falling = true;

  public void StartFalling() {
    StartCoroutine("Fall");
  }  

  void OnTriggerEnter2D(Collider2D col) {
    if(col.gameObject.tag == "Ground") {
      falling = false;
    }
  }

  IEnumerator Fall() {
    while(falling) {
      float dt = Time.deltaTime;
      Vector3 pos = this.transform.position;
      pos.y -= fallSpeed * dt;
      this.transform.position = pos;
      this.transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
      yield return new WaitForSeconds(dt);
    }
  }
}
