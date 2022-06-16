using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DiscoveryPage : MonoBehaviour
{
    public Volume volume;
    public CameraRig camRig;

    private bool hacksInitialized = false;
    private GameObject player;
    private Camera playerCam;

    public GameObject postLocationsGO;
    public List<Transform> postLocations = new List<Transform>();

    public DiscoveryPageDriver Driver { get; set; }

    private void Awake()
    {
        camRig.gameObject.SetActive(false);

        foreach (Transform child in postLocationsGO.transform)
        {
            postLocations.Add(child);
        }
    }

    private void TryInitHacks()
    {
        if (hacksInitialized) return;

        // Find the player GO
        player = GameObject.FindGameObjectWithTag("Player");
        playerCam = Camera.main;

        hacksInitialized = true;
    }

    [ContextMenu("OpenDiscoveryMode")]
    public void OpenDiscoveryMode()
    {
        TryInitHacks();

        volume.weight = 1f;
        camRig.gameObject.SetActive(true);
        playerCam.gameObject.SetActive(false);
        RenderSettings.fog = true;
        RenderSettings.fogColor = new Color(0.07f, 0.07f, 0.07f);
        RenderSettings.fogDensity = 0.1f;
    }

    [ContextMenu("CloseDiscoveryMode")]
    public void CloseDiscoveryMode()
    {
        TryInitHacks();

        volume.weight = 0f;
        camRig.gameObject.SetActive(false);
        playerCam.gameObject.SetActive(true);
        RenderSettings.fog = false;
    }
}
