using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{

    public GameObject[] allChildren;

    // Start is called before the first frame update
    void Start()
    {

        allChildren = GameObject.FindGameObjectsWithTag("Bridge");

        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.Space)){

            for(int i = 0; i < allChildren.Length; i++){

                var child = allChildren[i];
                var piece = child.GetComponent<BridgePiece>();
                if(!piece.isBuilt){

                    piece.Build();
                    break;
                }
            }



        }

        allChildren = GameObject.FindGameObjectsWithTag("Bridge");


        if(Input.GetKeyDown(KeyCode.E)){
            var rand = Random.Range(0, allChildren.Length);
            GameObject chosen = allChildren[rand];

            var piece = chosen.GetComponent<BridgePiece>();
            if(!piece.isAttacked && piece.isBuilt)
                piece.Attacked();
        }
        
    }

}
