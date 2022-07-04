using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextToggleScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(true);
    }

    public void OnTriggerStay2D(Collider2D collision) 
    {
        GameObject collisionGameObject = collision.gameObject;
        if(collisionGameObject.name == "mc")
        {
            print("ui active");
            uiObject.SetActive(true);
        }
    }

    // IEnumerator WaitForSec()
    // {
    //     yield return new WaitForSeconds(5);
    //     Destroy(uiObject);
    //     Destroy(gameObject);
    // }
}
