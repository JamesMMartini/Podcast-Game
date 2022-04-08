using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorTarget : MonoBehaviour
{
    [SerializeField] string target;
    [SerializeField] GameObject puzzleObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains(target))
        {
            puzzleObject.GetComponent<PuzzleObject>().Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name.Contains(target))
        {
            puzzleObject.GetComponent<PuzzleObject>().Deactivate();
        }
    }
}
