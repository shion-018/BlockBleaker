using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallScript : MonoBehaviour
{
    public float Speed = 1500f;
    private Vector2 Direction = new Vector2(1, 1);
    private Rigidbody rigidBody;
    int life;
    public static int blocks;
    bool isShoot;
    public GameObject ball;
    [SerializeField]TextMeshProUGUI life_rest;
    public SetUpScript setupscript;
    void Start()
    {
        setupscript = GetComponent<SetUpScript>();
        life = 3;
        isShoot = false;
        blocks = SetUpScript.block_number;
        rigidBody = GetComponent<Rigidbody>();
    }
     void Update()
    {
        if (isShoot == true)
        {
            if (Mathf.Abs(rigidBody.velocity.y) <= 1)
            {
                rigidBody.velocity += Vector3.up * 5f * (rigidBody.velocity.y >= 0 ? 1 : -1) * Time.deltaTime;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isShoot == false)
            {
                isShoot = true;
                
                rigidBody.AddForce(Direction.normalized * Speed * Time.deltaTime, ForceMode.Impulse);
            }
        }

        if (life <= 0)
        {
            gameover();
        }
        Debug.Log(isShoot);

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        rigidBody.velocity = rigidBody.velocity.normalized * Speed * Time.deltaTime;
        if (collision.gameObject.tag == "block")
        {
            Destroy(collision.gameObject);
            blocks--;
        }
        if(collision.gameObject.tag == "out")
        {
            life--;
            life_rest.text = "life : " + life;
            Reset();
        }
    }
    
    private void Reset()
    {
        isShoot = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.position = new Vector3(0, -25, -2.5f);
    }
    
    private void gameover()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
