/*
 *  Zlib License
 *  
 *  Copyright (c) 2020 AoiKamishiro/神城葵
 *  
 *  
 *  This software is provided 'as-is', without any express or implied warranty.
 *  In no event will the authors be held liable for any damages arising from the use of this software.
 *  
 *  Permission is granted to anyone to use this software for any purpose,
 *  including commercial applications, and to alter it and redistribute it
 *  freely, subject to the following restrictions:
 *  
 *     1. The origin of this software must not be misrepresented; you must not
 *           claim that you wrote the original software. If you use this software
 *           in a product, an acknowledgment in the product documentation would be
 *           appreciated but is not required.
 *           
 *     2. Altered source versions must be plainly marked as such, and must not be
 *          misrepresented as being the original software.
 *          
 *     3. This notice may not be removed or altered from any source distribution. 
 *     
 */

//LastUpdate:2020/08/15(JST) 

using UnityEditor;
using UnityEngine;
public class VRCLayerSetup : EditorWindow
{
    [MenuItem("Tools/Kamishiro/VRCLayerSetup", priority = 150)]
    private static void OnEnable()
    {
        VRCLayerSetup window = GetWindow<VRCLayerSetup>("VRCLayerSetup");
        window.minSize = new Vector2(320, 360);
        window.Show();
    }

    //GUI Component
    private const string version = "VRCLayerSetup V1.0 by 神城葵";
    private const string linktext = "操作説明等はこちら";
    private const string link = "https://github.com/AoiKamishiro/UnityCustomEditor_VRCLayerSetup";

    private void OnGUI()
    {
        //Editor Window
        using (new GUILayout.VerticalScope())
        {
            EditorGUILayout.LabelField(version);
            if (GUILayout.Button(linktext)) { OpenLink(link); }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Layer 設定", EditorStyles.boldLabel);
            if (UpdateLayers.AreLayersSetup())
            {
                EditorGUILayout.LabelField("レイヤーは VRChat 向けに設定されています。");
            }
            else
            {
                if (GUILayout.Button("Setup Layers"))
                {
                    if (EditorUtility.DisplayDialog("Setup Layers for VRChat", "プロジェクトのレイヤー設定を VRChat 用に設定します。よろしいですか？", "OK", "Cancel"))
                    {
                        UpdateLayers.SetupEditorLayers();
                    }
                }
            }

            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Collision 設定", EditorStyles.boldLabel);
            if (UpdateLayers.IsCollisionLayerMatrixSetup())
            {
                EditorGUILayout.LabelField("レイヤー毎衝突判定は VRChat 向けに設定されています。");
            }
            else
            {
                if (GUILayout.Button("Setup Collision Matrix"))
                {
                    if (EditorUtility.DisplayDialog("Setup Collision Matrix for VRChat", "プロジェクトのレイヤー毎衝突判定を VRChat 用に設定します。よろしいですか？", "OK", "Cancel"))
                    {
                        UpdateLayers.SetupCollisionLayerMatrix();
                    }
                }
            }
        }
    }
    private void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
