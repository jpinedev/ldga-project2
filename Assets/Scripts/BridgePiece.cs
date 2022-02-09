using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgePiece : MonoBehaviour
{
    public bool isAttacked;
    public bool isBuilt;

    [SerializeField] private GameObject blockPlayer, sharkBiting;

    MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        isAttacked = false;
        isBuilt = false;
        mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = false;
        blockPlayer.SetActive(true);
        sharkBiting.SetActive(false);
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
        blockPlayer.SetActive(false);
    }

    public void Attacked(){

        isAttacked = true;
        sharkBiting.SetActive(true);
    }

    void Defend(){

        isAttacked = false;
        sharkBiting.SetActive(false);
    }

     void Destroy(){

        isAttacked = false;
        isBuilt = false;
        mesh.enabled = false;
        blockPlayer.SetActive(true);
        sharkBiting.SetActive(false);
    }


}
