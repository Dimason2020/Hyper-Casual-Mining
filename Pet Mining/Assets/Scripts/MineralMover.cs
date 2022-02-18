using System;
using UnityEngine;

public class MineralMover : MonoBehaviour
{
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 
            transform.position.y, 
            transform.position.z - (Time.deltaTime * 4.5f));
    }
}
