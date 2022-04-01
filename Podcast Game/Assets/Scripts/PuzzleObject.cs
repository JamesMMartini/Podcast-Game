using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    public bool activated = false;

    [SerializeField] GameObject[] activatedObjects;

    public virtual void Activate()
    {
        foreach (GameObject gameObject in activatedObjects)
        {
            gameObject.GetComponent<PuzzleObject>().activated = true;
            gameObject.GetComponent<PuzzleObject>().Activate();
        }
    }
}
