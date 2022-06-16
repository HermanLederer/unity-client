using UnityEngine;
using UnityEngine.Rendering;

public class CameraRig : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    private DiscoveryPage discovery;

    [Range(-1f, 9f)]
    public float scroll = 0f;

    private void Awake()
    {
        discovery = gameObject.GetComponentInParent<DiscoveryPage>();
    }

    private void Update()
    {
        // Set camera positions
        int cam1Page = Mathf.FloorToInt(scroll * 0.5f + 0.5f) * 2;
        int cam2Page = Mathf.FloorToInt(scroll * 0.5f) * 2 + 1;
        OpenPage(cam1, cam1Page);
        OpenPage(cam2, cam2Page);

        // Set viewport rects and FOVs based on scroll
        float pScroll = scroll + 1f; // padded scroll
        const float power = 0.8f;

        var bottom1 = Mathf.Max(0f, pScroll % 2f - 1f);
        var height1 = Mathf.Min(1f, pScroll % 2f);
        cam1.rect = new Rect(0, bottom1, 1, height1);
        cam1.fieldOfView = 73.4f * Mathf.Pow(Mathf.Abs(((pScroll + 1f) % 2f) - 1f), power);

        var bottom2 = Mathf.Max(0f, (pScroll + 1f) % 2f - 1f);
        var height2 = Mathf.Min(1f, (pScroll + 1f) % 2f);
        cam2.rect = new Rect(0, bottom2, 1, height2);

        cam2.fieldOfView = 73.4f * Mathf.Pow(Mathf.Abs((pScroll % 2f) - 1f), power);
    }

    private void OpenPage(Camera cam, int page)
    {
        if (page < 0 || page >= discovery.postLocations.Count)
        {
            cam.cullingMask = 0;
            return;
        }

        cam.cullingMask = ~0;
        var pos = discovery.postLocations[page].position;
        var rot = discovery.postLocations[page].rotation;
        cam.transform.position = pos;
        cam.transform.rotation = rot;
    }
}
