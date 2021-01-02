using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPC file" , menuName = "NPC Files Archive")]
public class NPCMonsieurLapin : ScriptableObject
{
    public string lapinName;
    [TextArea(3, 15)]
    public string[] dialogue;
    [TextArea(3, 15)]
    public string[] playerDialogue;
}
