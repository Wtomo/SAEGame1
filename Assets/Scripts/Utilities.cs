using UnityEngine;
using System.Collections;

public static class Utilities{
    static LayerMask m_mouseRaycastLayer;
    static Utilities()
    {
        m_mouseRaycastLayer = LayerMask.GetMask("Ground");
    }
	public static RaycastHit? CursorRayCast(Camera camera)
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit rHit;
        if(Physics.Raycast(ray, out rHit, float.MaxValue, m_mouseRaycastLayer))
        {
            return rHit;
        }
        return null;
    }
}
