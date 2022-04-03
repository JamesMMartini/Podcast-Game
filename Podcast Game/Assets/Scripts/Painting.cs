using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : HoldableObject
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Fire")
        {
            StartCoroutine(DestroyPainting());
        }
    }

    IEnumerator DestroyPainting()
    {
        transform.SetParent(null);
        GetComponent<Rigidbody>().isKinematic = false;
        held = false;

        yield return new WaitForSeconds(2f);

        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Rigidbody>().isKinematic = false;
                transform.GetChild(i).SetParent(null);
            }
        }

        Destroy(gameObject);
    }
}
