using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    [SerializeField] Camera refCam;
    [SerializeField] float vertSpd;
    [SerializeField] float horizSpd;

    Rigidbody rb1, rb2;

    private void Start()
    {
        rb1 = p1.GetComponent<Rigidbody>();
        rb2 = p2.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float vert1 = Input.GetAxis("Vertical1") * Time.deltaTime;
        float horiz1 = Input.GetAxis("Horizontal1") * Time.deltaTime;
        float vert2 = Input.GetAxis("Vertical2") * Time.deltaTime;
        float horiz2 = Input.GetAxis("Horizontal2") * Time.deltaTime;
        Vector3 camFwd = (refCam.transform.forward - (Vector3.up * refCam.transform.forward.y)).normalized;
        Vector3 camRight = (refCam.transform.right - (Vector3.up * refCam.transform.right.y)).normalized;
        p1.transform.Translate(camFwd * vert1 * vertSpd);
        p1.transform.Translate(camRight * horiz1 * horizSpd);
        p2.transform.Translate(camFwd * vert2 * vertSpd);
        p2.transform.Translate(camRight * horiz2 * horizSpd);
        rb1.velocity = Vector3.Lerp(rb1.velocity, Vector3.zero, 0.25f);
        rb2.velocity = Vector3.Lerp(rb2.velocity, Vector3.zero, 0.25f);
    }
}
