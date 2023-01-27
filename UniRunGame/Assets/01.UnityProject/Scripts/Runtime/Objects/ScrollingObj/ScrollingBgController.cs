using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBgController : ScrollingObjController
{
    public override void Start()
    {
        base.Start();
    }       // Start()

    public override void Update()
    {
        base.Update();
    }       // Update()

    protected override void InitObjsPosition()
    {
        base.InitObjsPosition();

        // { ������ ������Ʈ�� ��ġ�� �����Ѵ�.
        float horizonPos =
            objPrefabSize.x * (scrollingObjCount - 1) * (-1) * 0.5f;
        for (int i = 0; i < scrollingObjCount; i++)
        {
            scrollingPool[i].SetLocalPos(horizonPos, 0f, 0f);
            horizonPos = horizonPos + objPrefabSize.x;
        }       // loop: ������ ������Ʈ�� ���η� ���ʺ��� ���ʴ�� �����ϴ� ����
        // } ������ ������Ʈ�� ��ġ�� �����Ѵ�.
    }       // InitObjsPosition()

    protected override void RepositionFirstObj()
    {
        base.RepositionFirstObj();

        // ��ũ�Ѹ� Ǯ�� ù��° ������Ʈ�� ���������� �������Ŵ� �ϴ� ����
        float lastScrObjCurrentXPos = scrollingPool[scrollingObjCount - 1].transform.localPosition.x;
        if (lastScrObjCurrentXPos <= objPrefabSize.x * 0.5f)
        {
            float lastScrObjInitXPos =
                Mathf.Floor(scrollingObjCount * 0.5f) *
                objPrefabSize.x + (objPrefabSize.x * 0.48f);

            scrollingPool[0].SetLocalPos(lastScrObjInitXPos, 0f, 0f);
            scrollingPool.Add(scrollingPool[0]);
            scrollingPool.RemoveAt(0);

            // DEBUG: 
            //GFunc.Log($"List Pos: {scrollingPool[0].transform.localPosition}, " +
            //    $"{scrollingPool[2].transform.localPosition}");

        }       // if: ��ũ�Ѹ� ������Ʈ�� ������ ������Ʈ�� ȭ�� ���� �������� Draw �Ǵ� ��
    }       // RepositionFirstObj()
}
