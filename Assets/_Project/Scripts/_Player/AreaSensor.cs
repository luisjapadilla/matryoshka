using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSensor : MonoBehaviour
{
    public float distance = 2;
    public float angle = 30;
    public float height = 1.0f;
    public Color Meshcolor;

    private bool isActive = false;
    // Start is called before the first frame update
    private Vector3 mousePosition;
    Mesh mesh;
    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;

    void Start()
    {
        CreateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isActive = !isActive;
            meshRenderer.enabled = isActive;
        }
    }

    Mesh CreateMesh()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance));
        Vector3 direction = mousePosition - transform.position;
        mesh = new Mesh();
        meshFilter = GetComponent<MeshFilter>();
        meshRenderer = GetComponent<MeshRenderer>();
        meshFilter.mesh = mesh;
        int numtriagles = 8;
        int numVertices = numtriagles * 3;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[numVertices];

        Vector3 bottomCenter = new Vector3(0, -0.5f, 0);
        Vector3 bottomLeft = Quaternion.Euler(0, -angle, 0) * Vector3.forward * distance;
        Vector3 bottomright = Quaternion.Euler(0, angle, 0) * Vector3.forward * distance;

        Vector3 topCenter = bottomCenter + Vector3.up * height;
        Vector3 topRight = bottomright + Vector3.up * height;
        Vector3 topLeft = bottomLeft + Vector3.up * height;

        int vert = 0;

        //left
        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomLeft;
        vertices[vert++] = topLeft;

        vertices[vert++] = topLeft;
        vertices[vert++] = topCenter;
        vertices[vert++] = bottomCenter;

        //right
        vertices[vert++] = bottomCenter;
        vertices[vert++] = topCenter;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = bottomright;
        vertices[vert++] = bottomCenter;
        //far

        vertices[vert++] = bottomLeft;
        vertices[vert++] = bottomright;
        vertices[vert++] = topRight;

        vertices[vert++] = topRight;
        vertices[vert++] = topLeft;
        vertices[vert++] = bottomLeft;

        //top 

        vertices[vert++] = topCenter;
        vertices[vert++] = topLeft;
        vertices[vert++] = topRight;

        //bottom

        vertices[vert++] = bottomCenter;
        vertices[vert++] = bottomright;
        vertices[vert++] = bottomLeft;

        for(int i = 0; i < numVertices; i++)
        {
            triangles[i] = i;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();

        return mesh;
    }

    private void OnValidate()
    {
        mesh = CreateMesh();
    }

    private void OnDrawGizmos()
    {
        if (mesh)
        {
            Gizmos.color = Meshcolor;
            Gizmos.DrawMesh(mesh, transform.position, transform.rotation);
        }
    }
}
