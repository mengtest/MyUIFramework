﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackPanel : UIBasePanel {
    public override void OnEnter()
    {
        if (m_CanvasGroup == null)
            m_CanvasGroup = GetComponent<CanvasGroup>();

        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.blocksRaycasts = true;

        Vector3 temp = transform.localPosition;
        temp.y = -Screen.height / 2.0f;
        transform.localPosition = temp;
        transform.DOLocalMoveY(0, 0.5f);
        m_CanvasGroup.DOFade(1, 0.5f);
    }

    public override void OnPause()
    {
        m_CanvasGroup.blocksRaycasts = false;
    }

    public override void OnResume()
    {
        m_CanvasGroup.blocksRaycasts = true;
    }

    public override void OnExit()
    {
        m_CanvasGroup.blocksRaycasts = false;

        transform.DOLocalMoveY(-Screen.width / 2.0f, 0.5f);
        m_CanvasGroup.DOFade(0, 0.5f);
    }

    public void OnItemButtonOnClick()
    {
        UIManager.GetInstance().PushPanel(UIPanelType.ItemMessage);
    }
}
