using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    SetUpScript setupScript;

    void Start()
    {
        setupScript = GameObject.Find("blocks").GetComponent<SetUpScript>();// 良くはない
    }

    public void OnCollisionEnter(Collision target)
    {
        if (target.gameObject.tag == "ball")
        {
            setupScript.DestroyBlock();
            Destroy(gameObject);
        }
    }
}
