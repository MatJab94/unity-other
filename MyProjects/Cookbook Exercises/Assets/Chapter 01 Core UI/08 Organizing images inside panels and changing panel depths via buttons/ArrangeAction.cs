using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ArrangeAction : MonoBehaviour
{
    private RectTransform panelRectTransform;

    void Start()
    {
        panelRectTransform = GetComponent<RectTransform>();
    }

    public void MoveDownOne()
    {
        print("(before change) " + gameObject.name + " index = " + panelRectTransform.GetSiblingIndex());

        int currentSiblingIndex = panelRectTransform.GetSiblingIndex();
        panelRectTransform.SetSiblingIndex(Mathf.Clamp(currentSiblingIndex - 1, 0, currentSiblingIndex));

        print("(after change) " + gameObject.name + " index = " + panelRectTransform.GetSiblingIndex());
    }

    public void MoveUpOne()
    {
        print("(before change) " + gameObject.name + " index = " + panelRectTransform.GetSiblingIndex());

        int currentSiblingIndex = panelRectTransform.GetSiblingIndex();
        panelRectTransform.SetSiblingIndex(currentSiblingIndex + 1);

        print("(after change) " + gameObject.name + " index = " + panelRectTransform.GetSiblingIndex());
    }
}
