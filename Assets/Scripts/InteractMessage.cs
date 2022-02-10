using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractMessage : MonoBehaviour
{
    [SerializeField] private string interactMessage;
    [SerializeField] private bool specifyPlayer;
    [SerializeField] private float displayTime;
    [SerializeField] private Text textElement;

    private bool[] playerInField;

    private float messageTimer;

    void Start()
    {
        playerInField = new bool[2] { false, false };
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) InteractPlayer1();
        if (Input.GetKeyDown(KeyCode.Slash)) InteractPlayer2();

        if (messageTimer > 0)
        {
            messageTimer -= Time.deltaTime;
        }
        else
        {
            textElement.text = "";
        }
    }

    void InteractPlayer1() => Interact(0);

    void InteractPlayer2() => Interact(1);

    void Interact(int index)
    {
        Debug.LogFormat("[{0}, {1}]", playerInField[0], playerInField[1]);
        if (playerInField[index]) DisplayMessage(index);
    }

    void DisplayMessage(int index)
    {
        textElement.text = (specifyPlayer ?
            string.Format("Player {0}: " + interactMessage, index + 1)
            :
            interactMessage
        );
        messageTimer = displayTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Player 1":
                playerInField[0] = true;
                break;
            case "Player 2":
                playerInField[1] = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Player 1":
                playerInField[0] = true;
                break;
            case "Player 2":
                playerInField[1] = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.gameObject.name)
        {
            case "Player 1":
                playerInField[0] = false;
                break;
            case "Player 2":
                playerInField[1] = false;
                break;
            default:
                break;
        }
    }

}
