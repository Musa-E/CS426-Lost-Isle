using TMPro;
using UnityEngine;

public class OxygenCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI oxygenLevelText;

    public int oxygenLevel = 100;
    public float RateOfO2Reduction = 1f; 
    private float oxygenTimer;
    public int timeToO2Reduction = 1;

    private void Start()
    {
        UpdateOxygenLevelText(oxygenLevel);
    }

    private void Update()
    {
        HandleOxygenReduction();
    }
    private void HandleOxygenReduction()
    {
        oxygenTimer += Time.deltaTime;

        if (oxygenTimer >= timeToO2Reduction)
        {
            oxygenLevel = O2LevelReduction(oxygenLevel, Mathf.RoundToInt(RateOfO2Reduction));
            UpdateOxygenLevelText(oxygenLevel);

            oxygenTimer = 0f; 
        }
        if (oxygenLevel < 0)
        {
            oxygenLevel = 0;
            UpdateOxygenLevelText(oxygenLevel);
        }
    }

    private int O2LevelReduction(int currentO2Level, int RateOfO2Reduction)
    {
        return currentO2Level - RateOfO2Reduction;
    }
    private void UpdateOxygenLevelText(int currentO2Level)
    {
        oxygenLevelText.text = $"Oxygen: {currentO2Level}";
    }
    
}
