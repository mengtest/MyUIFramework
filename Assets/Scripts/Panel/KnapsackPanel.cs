using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackPanel : UIBasePanel {
    public override void OnEnter()
    {
        if (m_CanvasGroup == null)
            m_CanvasGroup = GetComponent<CanvasGroup>();

        m_CanvasGroup.alpha = 1;
        m_CanvasGroup.blocksRaycasts = true;
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
        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.blocksRaycasts = false;
    }

    public void OnItemButtonOnClick()
    {
        UIManager.GetInstance().PushPanel(UIPanelType.ItemMessage);
    }
}
