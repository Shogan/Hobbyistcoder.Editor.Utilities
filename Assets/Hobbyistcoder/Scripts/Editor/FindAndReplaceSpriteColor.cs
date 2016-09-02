using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace Hobbyistcoder.Editor.Utilities
{
    public class FindAndReplaceSpriteColor : EditorWindow
    {
        public Color existingColor = Color.white;
        public Color replaceColor = Color.white;
        public float variance = 0.01f;

        [MenuItem("Hobbyistcoder/Find And Replace Sprite Color")]
        private static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(FindAndReplaceSpriteColor));
        }

        void OnGUI()
        {
            GUILayout.BeginArea(new Rect(10, 10, 300, 400));
            GUILayout.Label("Find and replace Sprite Renderer color in scene.");
            GUILayout.Label("Which color do you want to replace");
            existingColor = EditorGUILayout.ColorField("Existing color", existingColor);
            GUILayout.Label("Which color do you want to replace it with");
            replaceColor = EditorGUILayout.ColorField("New Color", replaceColor);
            variance = EditorGUILayout.FloatField("Variance", variance);

            if (GUILayout.Button("Replace", GUILayout.Width(250)))
            {
                var changesMade = false;
                var sprites = UnityEditor.Editor.FindObjectsOfType<SpriteRenderer>();
                foreach (var sprite in sprites)
                {
                    if (!IsApproximateColor(sprite.color, existingColor, variance))
                    {
                        
                        continue;
                    }
                    sprite.color = replaceColor;
                    changesMade = true;
                }

                if (changesMade) EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
            }
            GUILayout.EndArea();
        }

        private static bool IsApproximateColor(Color input1, Color input2, float allowedVariance)
        {
            var rVariance = Mathf.Abs(input1.r - input2.r);
            var gVariance = Mathf.Abs(input1.g - input2.g);
            var bVariance = Mathf.Abs(input1.b - input2.b);
            if (rVariance <= allowedVariance && gVariance <= allowedVariance && bVariance <= allowedVariance)
                return true;

            return false;
        }
    }

}