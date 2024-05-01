using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameoverScript : MonoBehaviour
{
    int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(life < 0)
        {
            gameover();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
      Destroy(collision.gameObject);
        life--;
    }
    private void gameover()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
