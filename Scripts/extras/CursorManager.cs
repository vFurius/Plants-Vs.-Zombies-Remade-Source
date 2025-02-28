using UnityEngine;

public class CursorManager : MonoBehaviour
{
    [SerializeField] private Texture2D cursorDefault; 
    [SerializeField] private Texture2D cursorClick;  

    [SerializeField] private Vector2 defaultHotspot = Vector2.zero; 
    [SerializeField] private Vector2 clickHotspot = new Vector2(5f, 0f); 

    [SerializeField] private LayerMask interactableLayer; 

    private void Start()
    {
        SetDefaultCursor();
    }

    private void Update()
    {
        HandleCursorChange();
    }

    private void HandleCursorChange()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, interactableLayer);

        if (hit.collider != null)
        {
            SetClickCursor();
        }
        else
        {
            SetDefaultCursor();
        }

        if (Input.GetMouseButtonDown(0) && hit.collider != null)
        {
            Debug.Log("Objeto clickeado: " + hit.collider.name);
        }
    }

    public void SetDefaultCursor()
    {
        if (cursorDefault != null)
        {
            Cursor.SetCursor(cursorDefault, defaultHotspot, CursorMode.Auto);
        }
    }

    public void SetClickCursor()
    {
        if (cursorClick != null)
        {
            Cursor.SetCursor(cursorClick, clickHotspot, CursorMode.Auto);
        }
    }
}