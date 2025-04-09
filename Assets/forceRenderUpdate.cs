using UnityEngine;

public class forceRenderUpdate : MonoBehaviour
{

    public Camera blackHoleCamera;
    
    void Update()
    {
        if (blackHoleCamera.targetTexture != null)
        {
            blackHoleCamera.Render();
        }
    }

}
