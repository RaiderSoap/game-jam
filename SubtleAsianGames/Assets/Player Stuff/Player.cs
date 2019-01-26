using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float moveSpeed = 5f;
  public float jumpPower = 10f;
  private Rigidbody2D rb;
  private bool grounded;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  void OnCollisionEnter2D(Collision2D col) {
    if(col.gameObject.tag == "Ground") {
      grounded = true;
    }
  }

  public void Move(int x, int y) {
    Vector3 vel = rb.velocity;
    vel.x = moveSpeed * x;
    rb.velocity = vel;
  }

  public void Jump() {
    if(grounded) {
      rb.AddForce(transform.up * jumpPower);
      grounded = false;
    }
  }

}
