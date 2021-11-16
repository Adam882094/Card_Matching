using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    [SerializeField] private string targetMessage;

    public void OnMouseDown()
    {
        if (targetObject != null)
        {
            targetObject.SendMessage(targetMessage);
        }
    }
}
