using UnityEngine;

public class InteractionCameraUI : MonoBehaviour
{
    private Camera _mainCam;
    [SerializeField] private GameObject _UIPanel;
    [SerializeField] private TMPro.TextMeshProUGUI _promptText;
    private void Start()
    {
        _mainCam = Camera.main;
        _UIPanel.SetActive(false);
    }
    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
    }
    public bool isDisplayed = false;

    public void SetUp(string prompText)
    {
        _promptText.text = prompText;
        _UIPanel.SetActive(true);
    }
    public void Close()
    {
        isDisplayed = false;
        _UIPanel.SetActive(false);
    }
}
