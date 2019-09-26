using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MouseManager : MonoBehaviour
{
    // what objects are clickable
    public LayerMask clickableLayer;

    // swap cursors per object
    public Texture2D pointer;
    public Texture2D target;
    public Texture2D doorway;
    public Texture2D combat;

    public EventVector3 OnClickEnviroment;
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 50, clickableLayer.value))
        {
            bool door = false;
            if (hit.collider.gameObject.tag == "Doorway"){
                Cursor.SetCursor(doorway, new Vector2(16,16), CursorMode.Auto);
                door = true;
            }
            else{
                Cursor.SetCursor(target, new Vector2(16,16), CursorMode.Auto);
            }
            if (Input.GetMouseButtonDown(0))
            {
                OnClickEnviroment.Invoke(hit.point);
            }
        }
        else
        {
            Cursor.SetCursor(pointer, new Vector2(0, 0), CursorMode.Auto);
        }
    }
}

[System.Serializable]
public class EventVector3: UnityEvent<Vector3> { }
