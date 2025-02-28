using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [Header("Graphics Settings")]
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown qualityDropdown;
    public Toggle vsyncToggle;

    [Header("Controls Settings")]
    public Slider mouseSensitivitySlider;
    public Toggle invertYAxisToggle;

    private Resolution[] resolutions;

    void Start()
    {
        LoadSettings();
    }

    void LoadSettings()
    {
        // Verifica que los elementos UI no sean nulos
        if (resolutionDropdown == null || qualityDropdown == null || vsyncToggle == null)
        {
            Debug.LogError("Uno o más elementos UI no están asignados en el Inspector.");
            return;
        }

        // Cargar resoluciones disponibles
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        if (resolutions.Length > 0)
        {
            foreach (var res in resolutions)
            {
                resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(res.width + "x" + res.height));
            }

            int savedIndex = PlayerPrefs.GetInt("ResolutionIndex", resolutions.Length - 1);
            resolutionDropdown.value = Mathf.Clamp(savedIndex, 0, resolutions.Length - 1);
        }

        // Cargar otros ajustes
        qualityDropdown.value = PlayerPrefs.GetInt("Quality", 2);
        vsyncToggle.isOn = PlayerPrefs.GetInt("VSync", 1) == 1;

        mouseSensitivitySlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 1f);
        invertYAxisToggle.isOn = PlayerPrefs.GetInt("InvertYAxis", 0) == 1;
    }

    public void ApplySettings()
    {
        // Aplicar configuraciones gráficas
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, Screen.fullScreen);
        QualitySettings.SetQualityLevel(qualityDropdown.value);
        QualitySettings.vSyncCount = vsyncToggle.isOn ? 1 : 0;
        PlayerPrefs.SetInt("ResolutionIndex", resolutionDropdown.value);
        PlayerPrefs.SetInt("Quality", qualityDropdown.value);
        PlayerPrefs.SetInt("VSync", vsyncToggle.isOn ? 1 : 0);

        // Aplicar configuraciones de control
        PlayerPrefs.SetFloat("MouseSensitivity", mouseSensitivitySlider.value);
        PlayerPrefs.SetInt("InvertYAxis", invertYAxisToggle.isOn ? 1 : 0);

        PlayerPrefs.Save();
    }
}