using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Vector3 mousePos, pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //マウスの座標を取得するS
        mousePos = Input.mousePosition;
        //マウス位置を確認
        //Debug.Log(mousePos);
        //スクリーン座標をワールド座標に変換する
        pos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 220, 116f));
        //ワールド座標をゲームオブジェクトの座標に設定する
        transform.position = pos;
    }
}
