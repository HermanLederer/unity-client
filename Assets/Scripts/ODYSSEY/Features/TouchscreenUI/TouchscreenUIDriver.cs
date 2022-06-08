using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Odyssey;

public interface ITouchscreenUIDriver
{
    // void ShowHideMinimap(bool show);
    // bool IsExpanded();
    // void Clear();
}

public class TouchscreenUIDriver : MonoBehaviour, IRequiresContext, ITouchscreenUIDriver
{
    [Header("References")]
    [SerializeField]
    TouchscreenUI touchscreenUI;

    void OnEnable()
    {
        touchscreenUI.Driver = this;
        _c.Get<IReactBridge>().ShowHideTouchscreenUI_Event += OnToggleTouchscreenUI;
    }

    void OnDisable()
    {
        touchscreenUI.Driver = null;
        _c.Get<IReactBridge>().ShowHideTouchscreenUI_Event -= OnToggleTouchscreenUI;
    }

    public void Init(IMomentumContext context)
    {
        _c = context;
    }

    #region Event Handlers

    [ContextMenu("Toggle TouchscreenUI")]
    private void OnToggleTouchscreenUI(bool show)
    {
        touchscreenUI.SetVisibility(show);
    }

    #endregion

    IMomentumContext _c;
}
