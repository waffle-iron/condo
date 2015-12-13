---
layout: docs
title: info
group: shades
---

@{/*

info
    Saves assembly information to the specified assembly info file, or any assembly info file
    contained within the specified path.

info_path
    Required. The path to the assembly info file to update, or a path containing an assembly info
    file.

*/}

use namespace = 'System'

default info_path    = ''

info-collect once='info-collect'

var info_asm_path    = '${ info_path }'

@{
    Build.Log.Header("info");
    Build.Log.Argument("path", info_path);
    Build.Log.Header();

    if (!string.IsNullOrEmpty(info_asm_path) && !info_asm_path.EndsWith("AssemblyInfo.cs"))
    {
        info_asm_path = Path.Combine(info_asm_path, "Properties", "Condo.AssemblyInfo.cs");
    }

    if (string.IsNullOrEmpty(info_asm_path))
    {
        throw new ArgumentException("info: a project file must be specified.", "info_path");
    }

    AssemblyInfo.SaveInfo(info_asm_path);
}