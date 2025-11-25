using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueObject", menuName = "Scriptable Objects/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    public string DialogueName;
    public DialogueType Type;
    public DialogueNode RootNode;
    
    
}
public enum DialogueType
{
    Rolling,Choice,Default
}

public class DialogueNode
{
    public string DisplayText;
    public List<DialogueNodeResponse> Responses;

}
public class DialogueNodeResponse
{
    public string respondText;
    public DialogueNode nextNode;

}


