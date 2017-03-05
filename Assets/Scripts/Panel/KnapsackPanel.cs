using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnapsackPanel : UIBasePanel {
    private CanvasGroup m_CanvasGroup;

    void Start()
    {
    }

    public void OnClosePanel()
    {
        UIManager.GetInstance().PopPanel();
    }
}
