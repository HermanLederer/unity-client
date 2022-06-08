using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchscreenUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    GameObject Viewport;

    public TouchscreenUIDriver Driver { get; set; }

    void Awake()
    {
        SetVisibility(false);
    }

    public void SetVisibility(bool visibility)
    {
        Viewport.gameObject.SetActive(visibility);
    }
}
