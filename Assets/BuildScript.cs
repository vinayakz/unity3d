using UnityEngine;
using UnityEditor;

public class BuildScript : MonoBehaviour
{
    public static void Build()
    {
        // Path to the build folder
        string buildPath = "Builds/Windows/";

        // Ensure the build folder exists
        if (!System.IO.Directory.Exists(buildPath))
        {
            System.IO.Directory.CreateDirectory(buildPath);
        }

        // Build player
        BuildPipeline.BuildPlayer(GetEnabledScenes(), buildPath + "YourGameName.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
    }

    // Helper method to get enabled scenes in the build settings
    private static string[] GetEnabledScenes()
    {
        EditorBuildSettingsScene[] scenes = EditorBuildSettings.scenes;
        string[] enabledScenes = new string[scenes.Length];
        for (int i = 0; i < scenes.Length; i++)
        {
            enabledScenes[i] = scenes[i].path;
        }
        return enabledScenes;
    }
}