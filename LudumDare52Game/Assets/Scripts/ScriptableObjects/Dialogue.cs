using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialogue : ScriptableObject
{
    public Message[] messages;
    public Actor[] actors;
}

[System.Serializable]
public class Message
{
    public int actorID;
    [TextArea(2,4)]
    public string message;
}

[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}