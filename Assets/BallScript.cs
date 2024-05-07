using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BallScript : MonoBehaviour
{
    [SerializeField] float Speed = 100.0f;
    Vector2 Direction = new Vector2(1, 1);// 初期方向
    [SerializeField] SetUpScript setupScript = default!;
    [SerializeField] Rigidbody rigidBody = default!;
    bool isShoot = false;//ボールが動いているかどうか

    void Reset()
    {
        isShoot = false;
        rigidBody.velocity = Vector3.zero;
        rigidBody.position = new Vector3(0, -25, -2.5f);
    }

    void Start()
    {
        Reset();
    }

    void Update()
    {
        if(!isShoot) return;

        // 水平に動くのを防ぐ
        if (Mathf.Abs(rigidBody.velocity.y) <= 1)
        {
            rigidBody.velocity += Vector3.up * 5f * (rigidBody.velocity.y >= 0 ? 1 : -1);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "out")
        {
            setupScript.FallBall();
            Reset();
            return;
        }

        Vector3 C = collision.contacts[0].normal;
        rigidBody.velocity = Vector3.Reflect(-collision.relativeVelocity, C);
        rigidBody.velocity = rigidBody.velocity.normalized * Speed;
    }
    
    public void Shoot()
    {
        if (isShoot) return;// 既にボールが動いている場合は何もしない

        isShoot = true;
        rigidBody.AddForce(Direction.normalized * Speed, ForceMode.Impulse);
    }
}
