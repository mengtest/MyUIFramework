using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskPanel : UIBasePanel
{
    private CanvasGroup m_CanvasGroup;

    void Start()
    {
        if (m_CanvasGroup == null)
            m_CanvasGroup = GetComponent<CanvasGroup>();
    }

    public override void OnEnter()
    {
        if (m_CanvasGroup == null)
            m_CanvasGroup = GetComponent<CanvasGroup>();

        m_CanvasGroup.alpha = 1;
        m_CanvasGroup.blocksRaycasts = true;
    }

    public override void OnExit()
    {
        m_CanvasGroup.alpha = 0;
        m_CanvasGroup.blocksRaycasts = false;
    }

    public void OnClosePanel()
    {
        UIManager.GetInstance().PopPanel();
    }
}
