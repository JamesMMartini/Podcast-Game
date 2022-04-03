using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logs : PuzzleObject
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bottle")
        {
            Activate();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
