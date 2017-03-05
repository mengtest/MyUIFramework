using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager {
    private static UIManager m_Instance = null;
    public static UIManager GetInstance()
    {
        if (m_Instance == null)
        {
            m_Instance = new UIManager();
        }
        return m_Instance;
    }

    private Transform m_CanvasTransform;
    private Transform CanvasTransform
    {
        get
        {
            m_CanvasTransform = m_CanvasTransform ?? GameObject.Find("Canvas").transform;
            return m_CanvasTransform;
        }
    }

    // 储存所有面板Prefab的路径
    private Dictionary<UIPanelType, string> m_PanelPathDict;
    // 储存所有实例化的面板基类s
    private Dictionary<UIPanelType, UIBasePanel> m_PanelDict;

    public UIManager()
    {
        ParseUIPanelTypeJson();
    }

    private void ParseUIPanelTypeJson()
    {
        m_PanelPathDict = new Dictionary<UIPanelType, string>();
        TextAsset ta = Resources.Load<TextAsset>("UIPanelType");

        UIPanelTypeJson panelInfoList = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);
        foreach(UIPanelInfo info in panelInfoList.InfoList)
        {
            m_PanelPathDict.Add(info.PanelType, info.Path);
        }
    }

    public UIBasePanel GetPanel(UIPanelType panelType)
    {
        if (m_PanelDict == null)
        {
            m_PanelDict = new Dictionary<UIPanelType, UIBasePanel>();
        }

        UIBasePanel panel = m_PanelDict.TryGet(panelType);
        if (panel == null)
        {
            // 如果当前没有保存这个面板，则通过prefab实例化
            string path = m_PanelPathDict.TryGet(panelType);
            GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
            instPanel.transform.SetParent(CanvasTransform, false);
            m_PanelDict.Add(panelType, instPanel.GetComponent<UIBasePanel>());
            return instPanel.GetComponent<UIBasePanel>();
        }
        else
        {
            return panel;
        }
    }

    class UIPanelTypeJson
    {
        public List<UIPanelInfo> InfoList;
    }

    public void Test()
    {
        string path;
        m_PanelPathDict.TryGetValue(UIPanelType.ItemMessage, out path);
        Debug.Log(path);
    }
}
