using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RingScript : MonoBehaviour
{
    public bool done = false;
    public GameObject hole;
    public GameObject celebrate;
    public GameObject counterObject;

    private void OnCollisionEnter(Collision collision)
    {
        if ((done == false) && collision.collider.CompareTag("Floor"))
        {
            done = true;
            Finish();
        }
    }

    private void LateUpdate()
    {
        this.GetComponent<Rigidbody>().WakeUp();
    }

    private void Finish()
    {
        GetComponentInParent<Rigidbody>().freezeRotation = true;
        transform.DOLocalJump(hole.transform.position, 1, 1, 1).OnComplete(RingCollected);
    }

    private void RingCollected()
    {
        Instantiate(celebrate, this.transform.position, Quaternion.Euler(0, 0, 0));
        counterObject.SendMessage("RingCollected");
        Destroy(this.gameObject);
    }
}
