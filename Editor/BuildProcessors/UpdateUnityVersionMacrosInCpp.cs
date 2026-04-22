using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace LeanCLR.BuildProcessors
{
    internal class UpdateUnityVersionMacrosInCpp : IPreprocessBuildWithReport
    {
        public int callbackOrder => 2;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (!Settings.EnableForCurrentBuildTarget)
            {
                return;
            }
            UpdateUnityVersion();
        }

        public static void UpdateUnityVersion()
        {
            var installerController = new LocalInstaller();
            if (!installerController.HasInstalledToLocal())
            {
                throw new Exception($"Please install LeanCLR first.");
            }

            string unityVersionFilePath = $"{Settings.LocalLibil2cppPath}/il2cpp/unityversion.h";

            var ver = installerController.CurVersion;
            var codes = new List<string>();
            codes.Add("#pragma once");
            codes.Add("");
            codes.Add($"#define UNITY_VERSION {ver.major:D4}{ver.minor1:D2}{ver.minor2:D2}");
            if (ver.isTuanjieEngine)
            {
                codes.Add($"#define UNITY_TUANJIE_ENGINE 1");
            }
            codes.Add("");
            File.WriteAllLines(unityVersionFilePath, codes, new UTF8Encoding(false));
            Debug.Log($"[UpdateUnityVersion] update unity version to {unityVersionFilePath}");
        }
    }
}
