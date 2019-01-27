using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float moveSpeed = 5f;
  public float jumpPower = 10f;

  public enum team {GOOD, BAD};
  public float closeEnoughDistance = 0.05f;
  private Rigidbody2D rb;
  private BoxCollider2D box;
  private bool grounded;
  private bool touchingStairs;
  private bool canMove = true;
  private team teamID;

  private FallingObject targetObject = null;

  private IEnumerator coroutine;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
    box = GetComponent<BoxCollider2D>();
  }

  public void SetTeam(team teamID) {
    this.teamID = teamID;
  }

  void OnCollisionEnter2D(Collision2D col) {
    if(col.gameObject.tag == "Ground") {
      grounded = true;
    }
  }

  void OnTriggerEnter2D(Collider2D col) {
    if(col.gameObject.tag == "Stairs") {
      touchingStairs = true;
      coroutine = MoveTo(col.gameObject.GetComponent<Stairs>().targetStair.position);
    }
    else if(col.gameObject.tag == "FallingObject") {
      targetObject = col.gameObject.GetComponent<FallingObject>();
      if(this.teamID == team.GOOD) {
        col.gameObject.transform.position = this.transform.position;
        col.gameObject.transform.parent = this.transform;
        Debug.Log("SCORE!");
        Destroy(col.gameObject, 2);
      }
    }
  }

  void OnTriggerExit2D(Collider2D col) {
    if(col.gameObject.tag == "Stairs") {
      touchingStairs = false;
    }
    else if(col.gameObject.tag == "FallingObject") {
      targetObject = null;
    }
  }

  public void Move(int x, int y) {
    if(!canMove) {
      return;
    }
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
    if(canMove && touchingStairs) {
      grounded = false;
      StartCoroutine(coroutine);
    }
  }

  public void DropObject() {
    Debug.Log("HERE");
    if(targetObject != null) {
      targetObject.StartFalling();
    }
  }

  IEnumerator MoveTo(Vector3 target) {
    rb.gravityScale = 0;
    rb.velocity = Vector2.zero;
    box.enabled = false;
    canMove = false;
    while((transform.position - target).magnitude > closeEnoughDistance) {
      float dt = Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, target, moveSpeed * dt);
      yield return new WaitForSeconds(dt);
    }
    rb.gravityScale = 1;
    box.enabled = true;
    canMove = true;
  }

}
