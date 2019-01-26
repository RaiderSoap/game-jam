using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float moveSpeed = 5f;
  public float jumpPower = 10f;

  public float closeEnoughDistance = 0.05f;
  private Rigidbody2D rb;
  private BoxCollider2D box;
  private bool grounded;
  private bool touchingStairs;

  private IEnumerator coroutine;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    box = GetComponent<BoxCollider2D>();
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

  void OnTriggerEnter2D(Collider2D col) {
    Debug.Log(col.gameObject.tag);
    if(col.gameObject.tag == "Stairs") {
      touchingStairs = true;
      coroutine = MoveTo(col.gameObject.GetComponent<Stairs>().targetStair.position);
    }
  }

  void OnTriggerExit2D(Collider2D col) {
    Debug.Log(col.gameObject.tag);
    if(col.gameObject.tag == "Stairs") {
      touchingStairs = false;
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

  public void ClimbStairs() {
    if(touchingStairs) {
      Debug.Log("Climbing stairs!");
      grounded = false;
      StartCoroutine(coroutine);
    }
  }

  IEnumerator MoveTo(Vector3 target) {
    rb.gravityScale = 0;
    box.enabled = false;
    while((transform.position - target).magnitude > closeEnoughDistance) {
      float dt = Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * dt);
      yield return new WaitForSeconds(dt);
    }
    rb.gravityScale = 1;
    box.enabled = true;
  }

}
