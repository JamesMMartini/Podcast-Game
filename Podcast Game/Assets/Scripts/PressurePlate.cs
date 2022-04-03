using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : PuzzleObject
{
    public int stacks = 0;
    [SerializeField] int requiredStacks;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Contains("Book Stack"))
        {
            stacks++;

            if (stacks >= requiredStacks)
            {
                Activate();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Contains("Book Stack"))
        {
            stacks--;
        }
    }
}
