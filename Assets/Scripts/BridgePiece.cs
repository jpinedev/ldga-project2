using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePiece : MonoBehaviour
{
    public bool isAttacked;
    public bool isBuilt;
    public Material wood;

    MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        isAttacked = false;
        isBuilt = false;
        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isAttacked && Input.GetKeyDown(KeyCode.R)){
            Defend();
        }

        if(isAttacked && Input.GetKeyDown(KeyCode.T)){
            Destroy();
        }



        
    }

    public void Build(){

        mesh.enabled = true;
        isBuilt = true;
    }

    public void Attacked(){

        isAttacked = true;
        mesh.material.color = Color.blue;
    }

    void Defend(){

        isAttacked = false;
        mesh.material = wood;
    }

     void Destroy(){

        isAttacked = false;
        isBuilt = false;
        mesh.material = wood;
        mesh.enabled = false;
        
    }


}
