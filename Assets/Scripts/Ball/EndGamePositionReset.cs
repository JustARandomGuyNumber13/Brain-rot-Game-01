using System.Collections.Generic;
using UnityEngine;

public class EndGamePositionReset : MonoBehaviour
{
    [SerializeField] Transform[] resetObjects;
    Dictionary<Transform, Vector3> positionRecord = new();
    Game_Manager manager;

    private void Start()
    {
        manager = Game_Manager.instance;

        foreach (var obj in resetObjects)
            positionRecord.Add(obj, obj.transform.localPosition);

        manager.OnGameEnd.AddListener(ResetPosition);
        enabled = false;
    }

    private void ResetPosition()
    { 
        foreach (var obj in positionRecord.Keys)
            obj.transform.localPosition = positionRecord[obj];
    }
}
