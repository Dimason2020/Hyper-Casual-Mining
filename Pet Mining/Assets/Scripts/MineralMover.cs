using System;
using UnityEngine;

public class MineralMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 
            transform.position.y, 
            transform.position.z - (Time.deltaTime * moveSpeed));
    }
}
