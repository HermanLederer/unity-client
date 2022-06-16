using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DiscoveryPage : MonoBehaviour
{
    public Volume desaturationVolume;

    private bool hacksInitialized = false;
    private GameObject player;
    private Camera playerCam;

    public GameObject postLocationsGO;
    public List<Transform> postLocations = new List<Transform>();
    private int page = 0;

    private void Awake()
    {
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

        desaturationVolume.weight = 1f;
        playerCam.gameObject.SetActive(false);

    }

    [ContextMenu("CloseDiscoveryMode")]
    public void CloseDiscoveryMode()
    {
        TryInitHacks();

        desaturationVolume.weight = 0f;
        playerCam.gameObject.SetActive(true);
    }
}
