using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    public GameObject prefabObj;

    // 生成したオブジェクトの親オブジェクトへの参照を保持します。
    public Transform parentTran;
    public static int block_number;
    int row;
    int column;
    float xOffset;
    float yOffset;

    void Start()
    {
        row = 2;
        column = 3;
        block_number = 6;
        xOffset = 30f;
        yOffset = 30f;
        CreateBlockObject();
        BallScript.blocks = block_number;
    }

    void Update()
    {
        if (BallScript.blocks <= 0)
        {
            stage2create();
            BallScript.blocks = block_number;
        }
    }
    /// <Summary>
    /// Prefabからブロックとして使うオブジェクトを生成します。
    /// </Summary>
    void CreateBlockObject()
    {
        
        for (int j = 0; j < row; j++)
        {
            for (int i = 0; i < column; i++)
            {
                // ゲームオブジェクトを生成します。
                GameObject obj = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);

                // ゲームオブジェクトの親オブジェクトを設定します。
                obj.transform.SetParent(parentTran);

                // ゲームオブジェクトの位置を設定します。
                float xPos = xOffset * i;
                float yPos = yOffset * j;
                obj.transform.localPosition = new Vector3(xPos - 30, yPos, 0.5f);
            }
        }
    }

    public void stage2create()
    {
        row = 5;
        column = 4;
        block_number = 20;
        xOffset = 20f;
        yOffset = 10f;
        CreateBlockObject();
    }
}

