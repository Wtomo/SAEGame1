using UnityEngine;
using System.Collections;

public static class Utilities{

	static RaycastHit? CursorRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rHit;
        if(Physics.Raycast(ray, out rHit))
        {
            return rHit;
        }
        return null;
    }
}
