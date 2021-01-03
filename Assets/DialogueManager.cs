using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public List<NPCMonsieurLapin> npcs;
    int state = 0;
    bool Alice = false;


    bool isTalking = false;

    float distance;
    float curResponseTracker = 0;
    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;



    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
       
        
        NPCMonsieurLapin npc = npcs[state];

        distance = Vector3.Distance(player.transform.position, this.transform.position);
        if (distance <= 2.5f)
        {
           
            //trigger dialogue
            if (Input.GetKeyDown(KeyCode.E) && isTalking == false)
            {
                StartConversation();
            }
            else if (Input.GetKeyDown(KeyCode.E) && isTalking == true)
            {
                EndDialogue();
            }
            if (!isTalking) return;

            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                curResponseTracker++;
                if (curResponseTracker >= npc.playerDialogue.Length - 1)
                {
                    curResponseTracker = npc.playerDialogue.Length - 1;
                }
            }

            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                curResponseTracker--;
                if (curResponseTracker < 0)
                {
                    curResponseTracker = 0;
                }

            }
            if (curResponseTracker == 0 && npc.playerDialogue.Length >= 0)
            {
                playerResponse.text = npc.playerDialogue[0];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    
                    int dialogue = Alice ? (npc.dialogue.Length/2) + 1 : 1;
                    npcDialogueBox.text = npc.dialogue[dialogue];
                    if (state == 1) Alice = true;
                    if (state < npcs.Count - 1)
                    {
                        state++;
                        curResponseTracker = 0;
                        playerResponse.text = npcs[state].playerDialogue[0];

                    }
                }

            }
            else if (curResponseTracker == 1 && npc.playerDialogue.Length >= 1)
            {
                playerResponse.text = npc.playerDialogue[1];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    int dialogue = Alice ? (npc.dialogue.Length / 2) + 2 : 2;
                    npcDialogueBox.text = npc.dialogue[dialogue];
                    if (state < npcs.Count - 1)
                    {
                        state++;
                        curResponseTracker = 0;
                        playerResponse.text = npcs[state].playerDialogue[0];
                    }
                }
            }
            else if (curResponseTracker == 2 && npc.playerDialogue.Length >= 2)
            {
                playerResponse.text = npc.playerDialogue[2];
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    int dialogue = Alice ? (npc.dialogue.Length / 2) + 3 : 3;
                    npcDialogueBox.text = npc.dialogue[dialogue];
                    if (state < npcs.Count - 1)
                    {
                        state++;
                        curResponseTracker = 0;
                        playerResponse.text = npcs[state].playerDialogue[0];
                    }
                }
            }
        }
        else
        {
            EndDialogue();
        }
    }

    void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npcs[state].lapinName;
        npcDialogueBox.text = npcs[state].dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);

    }


}
