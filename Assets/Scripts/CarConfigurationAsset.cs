using UnityEditor;

public class CarConfigurationAsset
{
        [MenuItem("Assets/Scriptable Objects")]
        public static void CreateAsset()
        {
                ScriptableObjectUtility.CreateAsset<CarConfiguration>();
        }
}