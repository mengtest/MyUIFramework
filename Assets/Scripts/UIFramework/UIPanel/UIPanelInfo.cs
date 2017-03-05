using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UIPanelInfo : ISerializationCallbackReceiver {
    [NonSerialized]
    public UIPanelType PanelType;
    public string PanelTypeString;
    public string Path;

    public void OnBeforeSerialize()
    {

    }

    // 反序列化 从文本到对象
    public void OnAfterDeserialize()
    {

        UIPanelType type = (UIPanelType)Enum.Parse(typeof(UIPanelType), PanelTypeString);
        PanelType = type;
    }
}
