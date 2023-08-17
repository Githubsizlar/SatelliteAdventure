using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoScript : MonoBehaviour
{
    public float speed;

 
    // Update is called once per frame
    // get input from player for walking
    // apply movement  to sprite
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        transform.position += direction * speed * Time.deltaTime;


    }
}
