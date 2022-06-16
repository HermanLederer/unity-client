using UnityEngine;

public class CameraRig : MonoBehaviour
{
    public Camera cam1;
    public Camera cam2;

    private DiscoveryPage discovery;

    [Range(0f, 7.9f)]
    public float scroll = 0f;

    private void Awake()
    {
        discovery = gameObject.GetComponentInParent<DiscoveryPage>();
    }

    private void Update()
    {
        // scroll += Time.deltaTime * 0.2f;

        // Set camera positions
        int cam1Page = Mathf.FloorToInt(scroll * 0.5f + 0.5f) * 2;
        int cam2Page = Mathf.FloorToInt(scroll * 0.5f) * 2 + 1;
        OpenPage(cam1, cam1Page);
        OpenPage(cam2, cam2Page);

        // Set viewport rects and FOVs based on scroll
        var fovPad = 0.1f;

        var bottom1 = Mathf.Max(0f, (scroll + 1f) % 2f - 1f);
        var height1 = Mathf.Min(1f, (scroll + 1f) % 2f);
        cam1.rect = new Rect(0, bottom1, 1, height1);
        cam1.fieldOfView = 73.4f * (fovPad + (1f - fovPad) * Mathf.Abs((scroll % 2f) - 1f));

        var bottom2 = Mathf.Max(0f, scroll % 2f - 1f);
        var height2 = Mathf.Min(1f, scroll % 2f);
        cam2.rect = new Rect(0, bottom2, 1, height2);
        cam2.fieldOfView = 73.4f * (fovPad + (1f - fovPad) * Mathf.Abs(((scroll + 1f) % 2f) - 1f));
    }

    private void OpenPage(Camera cam, int page)
    {
        var pos = discovery.postLocations[page].position;
        var rot = discovery.postLocations[page].rotation;
        cam.transform.position = pos;
        cam.transform.rotation = rot;
    }
}
