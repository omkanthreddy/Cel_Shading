
using UnityEngine;
using UnityEditor;

public class Cel_ShaderTool : EditorWindow
{

    Color color;
    Texture2D mytexture;
    Material myMaterial;


    [MenuItem("My Tool/Cel Editor Tool")]
    static void OpenWindow()
    {
        Cel_ShaderTool celShader = (Cel_ShaderTool)GetWindow(typeof(Cel_ShaderTool));
        celShader.Show();
    }

    private void OnGUI()
    {
        //GUILayout
        // select any object and change the textures and color : one Method 
        GUILayout.Label("Two Ways of Changing Texture and Color", EditorStyles.boldLabel);
        GUILayout.Space(10);
        GUILayout.Label("1.Select Object and Change the Texture and Color Directly!", EditorStyles.boldLabel);
        GUILayout.Space(20);
        // ColorField Setup
        color = EditorGUILayout.ColorField("color", color);
        // Texture Feild Setup
        mytexture = EditorGUILayout.ObjectField("Diffuse_Texture", mytexture, typeof(Texture2D), true) as Texture2D;
        // Buttons to assign colors and Textures
        if (GUILayout.Button("ChangeColor"))
        {
            ChangeMyColor();
        }
        if (GUILayout.Button("ChangeTexture"))
        {
            ChangeTexture();
        }

        GUILayout.Space(20);
        // Assign material and change the textures and color : second Method 
        // we no need to select any object here
        GUILayout.Label("2.Assign Material and change Texture and color", EditorStyles.boldLabel);
        GUILayout.Space(10);
        // Material Feild Setup
        myMaterial = EditorGUILayout.ObjectField("Material", myMaterial, typeof(Material), true) as Material;

        // Buttons to assign colors and Textures
        if (GUILayout.Button("Change_Color"))
        {
            Change_Color();
        }
        if (GUILayout.Button("Change_Texture"))
        {
            Change_Texture();
        }

    }

    void ChangeMyColor()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer = obj.GetComponent<MeshRenderer>();
            if(renderer!=null)
            {
                renderer.sharedMaterial.SetColor("_BaseColor", color);
            }
        }
    }

    void ChangeTexture()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer myRenderer = obj.GetComponent<MeshRenderer>();
            if (myRenderer != null)
            {
                myRenderer.material.mainTexture = mytexture;
              
            }
        }
    }
    void Change_Color()
    {
        myMaterial.SetColor("_BaseColor", color);
    }
    void Change_Texture()
    {
        myMaterial.mainTexture = mytexture;

    }
}
