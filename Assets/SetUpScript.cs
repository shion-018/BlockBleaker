using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    // オブジェクトを生成する元となるPrefabへの参照を保持します。
    [SerializeField] GameObject prefabBlock = default!;
    [SerializeField] TextMeshProUGUI life_rest = default!;
    int life = 3;// 残弾数

    int block_number = 0;

    void Start()
    {
        CreateBlockObject(2, 3, 30f, 30f);// Stage1
    }

    void createStage2()
    {
        CreateBlockObject(5, 4, 20f, 10f);// Stega2以降
    }

    /// <Summary>
    /// Prefabからブロックとして使うオブジェクトを生成します。
    /// </Summary>
    void CreateBlockObject(int row, int column, float xOffset, float yOffset)
    {
        block_number = row * column;

        for (int j = 0; j < row; j++)
        {
            for (int i = 0; i < column; i++)
            {
                // ゲームオブジェクトを生成します。
                GameObject obj = Instantiate(prefabBlock, Vector3.zero, Quaternion.identity);

                // ゲームオブジェクトの位置を設定します。
                float xPos = xOffset * i;
                float yPos = yOffset * j;
                obj.transform.localPosition = new Vector3(xPos - 30.0f, yPos, 0.5f);
            }
        }
    }

    public void DestroyBlock()
    {
        if(--block_number <= 0){
            createStage2();
        }
    }

    public void FallBall()
    {
        life--;
        life_rest.text = "life : " + life;

        if (life <= 0)
        {
            gameover();
        }
    }

    void gameover()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

