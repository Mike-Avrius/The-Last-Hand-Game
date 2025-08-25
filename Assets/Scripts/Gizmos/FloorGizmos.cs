using System;
using UnityEngine;

public class FloorGizmos : MonoBehaviour
{
    [SerializeField]  public Color gizmoColor = Color.red;
    
    // Creates a gizmo for the boundaries of the play area when there is fog in the scene.
    private void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
