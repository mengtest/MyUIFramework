using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : UIBasePanel {

    public void OnPushPanel(string panelTypeString)
    {
        UIPanelType panelType = (UIPanelType)Enum.Parse(typeof(UIPanelType), panelTypeString);
        UIManager.GetInstance().PushPanel(panelType);
    }

    public override void OnPause()
    {
        m_CanvasGroup.blocksRaycasts = false;
    }

    public override void OnResume()
    {
        m_CanvasGroup.blocksRaycasts = true;
    }
}
