using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;

// Headless multi-platform build entry points, invoked via Unity -batchmode -executeMethod.
public static class HeadlessBuild
{
    static string[] Scenes()
    {
        var list = new List<string>();
        foreach (var s in EditorBuildSettings.scenes)
            if (s.enabled) list.Add(s.path);
        return list.ToArray();
    }

    static void One(BuildTargetGroup group, BuildTarget target, string path)
    {
        Debug.Log("[HeadlessBuild] === " + target + " START ===");
        EditorUserBuildSettings.selectedBuildTargetGroup = group;
        if (EditorUserBuildSettings.activeBuildTarget != target)
            EditorUserBuildSettings.SwitchActiveBuildTarget(group, target);

        var opts = new BuildPlayerOptions
        {
            scenes = Scenes(),
            locationPathName = path,
            target = target,
            targetGroup = group,
            options = BuildOptions.None
        };
        BuildReport report = BuildPipeline.BuildPlayer(opts);
        var s = report.summary;
        Debug.Log("[HeadlessBuild] === " + target + " RESULT: " + s.result +
                  " sizeBytes=" + s.totalSize + " errors=" + s.totalErrors +
                  " time=" + s.totalTime + " ===");
        if (s.result != BuildResult.Succeeded)
            Debug.LogError("[HeadlessBuild] FAILED: " + target);
    }

    public static void BuildWindows() { One(BuildTargetGroup.Standalone, BuildTarget.StandaloneWindows64, "Builds/StandaloneWindows64/ShadowGarden.exe"); }
    public static void BuildOSX()     { One(BuildTargetGroup.Standalone, BuildTarget.StandaloneOSX,        "Builds/StandaloneOSX/ShadowGarden.app"); }
    public static void BuildLinux()   { One(BuildTargetGroup.Standalone, BuildTarget.StandaloneLinux64,    "Builds/StandaloneLinux64/ShadowGarden.x86_64"); }
    public static void BuildWebGL()   { One(BuildTargetGroup.WebGL,      BuildTarget.WebGL,                "Builds/WebGL"); }

    public static void BuildAll()
    {
        BuildWindows();
        BuildOSX();
        BuildLinux();
        BuildWebGL();
        Debug.Log("[HeadlessBuild] ALL DONE");
    }
}
