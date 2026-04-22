# LeanCLR for Unity

语言: [中文](./README.md) | [English](./README_EN.md)

[![GitHub](https://img.shields.io/badge/GitHub-leanclr4unity-181717?logo=github)](https://github.com/focus-creative-games/leanclr4unity) [![LeanCLR](https://img.shields.io/badge/LeanCLR-Runtime-181717?logo=github)](https://github.com/focus-creative-games/leanclr) [![license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/focus-creative-games/leanclr4unity/blob/main/LICENSE) [![Discord](https://img.shields.io/badge/Discord-Join-7289DA?logo=discord&logoColor=white)](https://discord.gg/esAYcM6RDQ)

**leanclr4unity** 是 [LeanCLR](https://github.com/focus-creative-games/leanclr/blob/main/README.md) 的 **Unity 集成包**：在发布 **WebGL / 各类小游戏宿主** 等场景时，用 LeanCLR **替代 IL2CPP** 作为脚本后端，从而在保持 **AOT + Interpreter** 混合执行与较高 **ECMA-335** 兼容度的前提下，**显著缩减 wasm 包体并降低运行时内存占用**。

本仓库（包名 `com.code-philosophy.leanclr`）负责 Unity Editor 侧集成、构建管线衔接与发布工作流；**LeanCLR 运行时本体** 为独立 C++ 项目，详见上游仓库说明。

## 为什么使用 LeanCLR for Unity

Unity 在 WebGL / 小游戏路径上通常依赖 IL2CPP 将托管代码编译为体积与内存开销都较大的原生（wasm）输出。LeanCLR 从零面向 **资源受限平台** 设计：在高度符合 **ECMA-335** 的前提下，提供 **更紧凑、易嵌入、低内存** 的 CLR 实现，并采用 **AOT + Interpreter 全平台一致** 的路线，特别适合 **H5 / 小游戏** 等对包体与内存敏感的目标。

更完整的背景、与 CoreCLR / Mono / IL2CPP 的对比、路线图与模块进度，请参阅 **[LeanCLR README](https://github.com/focus-creative-games/leanclr/blob/main/README.md)**。

## 文档

### 支持的Unity版本和平台

- 暂时支持Windows平台Unity Editor，后续版本会支持MacOS和linux
- 支持Unity 2019- Unity 6000 所有版本（含LTS和非LTS版本）
- 支持团结引擎所有版本
- 支持WebGL和MiniGame平台
- 部分支持其他平台（如Win64），但仅支持单线程，并且可能需要手动修改相应平台的构建工程文件（如Unity 6000 发布Win64平台时需要在Il2CppOutputProject.vcxproj文件中移除il2cpp的命令行参数`--static-lib-il2-cpp`，否则启动时会有 `il2cpp init failed`错误。）

### 限制

由于目前还处于早期版本，某些方面实现还不完整。

- **不支持GC**，但后续版本很快会跟进
- 只支持单线程
- 仅支持mscorlib和Unity引擎的dll中引入的pinvoke函数，不支持用户程序集中定义pinvoke函数。

### 安装

在Unity Package Manager中点击`Add package from git URL...`，填入 `https://github.com/focus-creative-games/hybridclr_unity.git` 即可完成安装。

### 设置

- `LeanCLR/Settings`菜单打开设置页面，当前仅可以设置开启或者禁用本插件。

### 构建

无需任何操作，本插件会自动在发布到WebGL或小游戏平台时使用leanclr替换il2cpp。

## 相关仓库

| 仓库 | 说明 |
|------|------|
| [leanclr4unity](https://github.com/focus-creative-games/leanclr4unity) | 本 Unity Package（Editor 集成与发布工作流） |
| [leanclr](https://github.com/focus-creative-games/leanclr) | LeanCLR 运行时与工具链（C++17，零外部依赖） |

## 支持与联系

- 邮箱：`leanclr#code-philosophy.com`
- Discord：<https://discord.gg/esAYcM6RDQ>
- QQ 群：1047250380

## 许可证

使用 [MIT License](https://github.com/focus-creative-games/leanclr4unity/blob/main/LICENSE)。
