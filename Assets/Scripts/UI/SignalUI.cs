using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignalUI : MonoBehaviour
{
    [SerializeField] GameObject signalPanel;
    [SerializeField] TextMeshProUGUI signalText;
    private Image slider;
    private SignalTimer timer;

    private void Start()
    {
        slider = GetComponent<Image>();
        timer = GetComponent<SignalTimer>();
    }

    public void Update()
    {
        if (timer != null && timer.IsDirty())
        {
            float maxValue = timer.GetMaxBroadcastTime();
            UpdateSlider(timer.GetBroadcastTime(), maxValue);
        }
    }
    public void UpdateSlider(float value, float maxValue)
    {
        if (signalText != null)
        {
            signalText.SetText("Signal Strength: {0:0.0}", value);
        }
        slider.fillAmount = value / maxValue;
    }

    public void DeactivateSignalPanel()
    {
        signalPanel.SetActive(false);
    }
    public void EnableSignalPanel()
    {
        signalPanel.SetActive(true);
    }
}
