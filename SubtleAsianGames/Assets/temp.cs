using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var newX = this.transform.position.x + 0.01f;
        this.transform.SetPositionAndRotation(new Vector3(newX, 0.0f), Quaternion.identity);
    }
}
