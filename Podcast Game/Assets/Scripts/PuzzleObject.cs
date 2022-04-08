using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleObject : MonoBehaviour
{
    //public bool activated = false;

    public int activationTick;
    public int activationRequirement;

     
    [SerializeField] public GameObject[] activatedObjects;

    public virtual void Activate()
    {
        activationTick++;

        Debug.Log("Activated");

        if (activationTick >= activationRequirement)
        {
            foreach (GameObject gameObject in activatedObjects)
            {
                //gameObject.GetComponent<PuzzleObject>().activated = true;
                gameObject.GetComponent<PuzzleObject>().Activate();
            }
        }
    }

    public virtual void Deactivate()
    {
        activationTick--;
    }
}
