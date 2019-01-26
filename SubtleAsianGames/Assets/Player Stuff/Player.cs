using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public float moveSpeed = 5f;
  private Rigidbody2D rb;

  void Awake()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    
  }

  public void Move(int x, int y) {
    rb.velocity = new Vector3(moveSpeed * x, 0, 0);
  }
}
