using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class camera_script : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset=new Vector3(4f,0f,-10f);
    private Vector3 velocity=Vector3.zero;
    private float smoothtime;
    private Vector3 targetposition=Vector3.zero;

    void FixedUpdate()
    {
        Vector3 targetposition= target.position + offset;
        transform.position=Vector3.SmoothDamp(transform.position,targetposition,ref velocity,smoothtime);
    }
}
