using System.Reflection;
using StarsProject.RawData.Constellations;
using StarsProject.Constellations;
using UnityEditor;
using UnityEngine;

namespace StarsProject.Editor.Constellations
{
    public class ConstellationConfigCreator : EditorWindow
    {
        private TextAsset data;

        private Sprite star;
        private Sprite preview;

        private DefaultAsset folder;
        
        [MenuItem("Assets/Constellation config creator")]
        public static void ShowWindow()
        {
            GetWindow<ConstellationConfigCreator>("Constellation config creator");
        }
        
        private void OnGUI()
        {
            TextField(ref data, "Constellation data:");
            SpriteField(ref star, "Star texture:");
            SpriteField(ref preview, "Preview texture:");
            FolderField(ref folder, "Save folder:");

            if (data && star && preview && folder)
            {
                if (GUILayout.Button("Generate config"))
                {
                    GenerateConfigs();
                }
            }
        }

        private void TextField(ref TextAsset currentValue, string text)
        {
            currentValue = (TextAsset)EditorGUILayout.ObjectField(text, data, typeof(TextAsset), false);
        }
        
        private void SpriteField(ref Sprite currentValue, string text)
        {
            currentValue = (Sprite)EditorGUILayout.ObjectField(text, currentValue, typeof(Sprite), false);
        }

        private void FolderField(ref DefaultAsset currentValue, string text)
        {
            currentValue = (DefaultAsset)EditorGUILayout.ObjectField(text, folder, typeof(DefaultAsset), false);

            if (currentValue == null)
            {
                return;
            }
            
            var folderPath = AssetDatabase.GetAssetPath(currentValue);
            if (AssetDatabase.IsValidFolder(folderPath))
            {
                return;
            }
            
            EditorGUILayout.HelpBox("Please select a folder.", MessageType.Warning);
            currentValue = null;
        }

        private void GenerateConfigs()
        {
            var constellations = ConstellationJsonConverter.Convert(data.text);

            foreach (var constellation in constellations)
            {
                GenerateConfig(constellation);
            }
        }
        
        private void GenerateConfig(Constellation constellation)
        {
            var config = CreateInstance<ConstellationConfig>();

            SetValueProp(nameof(config.Constellation), config, constellation);
            SetValueProp(nameof(config.Star), config, star);
            SetValueProp(nameof(config.Preview), config, preview);
     
            var path = AssetDatabase.GetAssetPath(folder) + $"/{constellation.Name}.asset";
            path = AssetDatabase.GenerateUniqueAssetPath(path); 
            
            AssetDatabase.CreateAsset(config, path);
            AssetDatabase.SaveAssets();
        }

        private void SetValueProp(string propName, object target, object value)
        {
            var prop = typeof(ConstellationConfig).GetProperty(propName, BindingFlags.Public | BindingFlags.Instance);
            prop.SetValue(target, value);
        }
    }
}