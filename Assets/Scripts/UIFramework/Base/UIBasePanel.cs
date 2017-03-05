using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class UIBasePanel : MonoBehaviour
{
    protected CanvasGroup m_CanvasGroup;
    void Start()
    {
        if (m_CanvasGroup == null)
            m_CanvasGroup = GetComponent<CanvasGroup>();
    }

    /// 界面的四个生命周期
    public virtual void OnEnter()
    {
        
    }

    public virtual void OnPause()
    {
        
    }

    public virtual void OnResume()
    {
        
    }

    public virtual void OnExit()
    {
        
    }

    public void OnClosePanel()
    {
        UIManager.GetInstance().PopPanel();
    }
}
