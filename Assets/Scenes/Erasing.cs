using Destructible2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Erasing : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    public float Intercept;
    public GameObject IndicatorPrefab;
    public Texture2D StampTex;
    public float Hardness = 1.0f;
    public float Thickness = 1.0f;
    private GameObject eraserPre;
    [SerializeField] TMP_Text txtFps;
    float fps;
    // Update is called once per frame

    private void Start()
    {
        InvokeRepeating("GetFPS", 1, 1);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGame();
        }
        if (Input.GetMouseButton(0))
        {
            Erases();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndGame();
        }
    }
    public void StartGame()
    {
        if (eraserPre != null)
            return;
        eraserPre = Instantiate(IndicatorPrefab);
    }
    public void Erases()
    {
        if (eraserPre == null)
            return;

        var endMousePosition = Input.mousePosition;
        Vector3 posErase = Camera.main.ScreenToWorldPoint(endMousePosition);

        eraserPre.transform.position =new Vector3(posErase.x,posErase.y,0) ;

        var startPos = D2dHelper.ScreenToWorldPosition(endMousePosition, Intercept, mainCamera);

        var endPos = startPos +  eraserPre.transform.localScale;

        D2dDestructible.SliceAll(startPos, endPos, Thickness, StampTex, Hardness);
    }
    public void EndGame()
    {
        if (eraserPre != null)
        {
            Destroy(eraserPre.gameObject);
        }
    }

    public void GetFPS()
    {
        fps = (int)(1 / Time.unscaledDeltaTime);
        txtFps.text ="FPS " +  fps.ToString();
    }
}
