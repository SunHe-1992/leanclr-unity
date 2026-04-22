# LeanCLR for Unity

Languages: [中文](./README.md) | [English](./README_EN.md)

[![GitHub](https://img.shields.io/badge/GitHub-leanclr4unity-181717?logo=github)](https://github.com/focus-creative-games/leanclr4unity) [![LeanCLR](https://img.shields.io/badge/LeanCLR-Runtime-181717?logo=github)](https://github.com/focus-creative-games/leanclr) [![license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/focus-creative-games/leanclr4unity/blob/main/LICENSE) [![Discord](https://img.shields.io/badge/Discord-Join-7289DA?logo=discord&logoColor=white)](https://discord.gg/esAYcM6RDQ)

**leanclr4unity** is the **Unity integration package** for [LeanCLR](https://github.com/focus-creative-games/leanclr/blob/main/README.md). For release targets such as **WebGL / mini-game hosts**, it uses LeanCLR to **replace IL2CPP** as the scripting backend. While keeping **AOT + Interpreter** hybrid execution and high **ECMA-335** compatibility, it can **significantly reduce wasm package size and runtime memory usage**.

This repository (package name `com.code-philosophy.leanclr`) is responsible for Unity Editor-side integration, build pipeline connection, and release workflow. The **LeanCLR runtime core** is an independent C++ project; see the upstream repository for details.

## Why LeanCLR for Unity

On Unity WebGL / mini-game targets, IL2CPP is commonly used to compile managed code into native (wasm) output with relatively high package size and memory overhead. LeanCLR is designed from scratch for **resource-constrained platforms**. With strong **ECMA-335** compliance, it provides a **more compact, embeddable, low-memory** CLR implementation and follows a fully consistent **AOT + Interpreter** path across platforms. It is especially suitable for **H5 / mini-game** scenarios where package size and memory are critical.

For more complete background, comparison with CoreCLR / Mono / IL2CPP, roadmap, and module progress, please refer to the **[LeanCLR README](https://github.com/focus-creative-games/leanclr/blob/main/README.md)**.

## Documentation

### Supported Unity versions and platforms

- Currently supports Unity Editor on Windows. Future versions will support macOS and Linux.
- Supports Unity `2019.x.y` to `6000.x.y`.
- Supports WebGL and MiniGame platforms.
- Other platforms (such as Win64) are supported to a limited extent, but only in single-thread mode, and manual build script changes may be required. For example, when publishing for Win64, remove the il2cpp argument `--static-lib-il2-cpp` from `Il2CppOutputProject.vcxproj`; otherwise startup may fail with `il2cpp init failed`.

### Limitations

As this is still an early version, some parts are not fully implemented yet.

- **GC is not supported yet**, but will be added soon.
- Only single-threaded execution is supported.
- Only pinvoke functions introduced by `mscorlib` and Unity engine DLLs are supported. PInvoke functions defined in user assemblies are not supported.

### Installation

In Unity Package Manager, click `Add package from git URL...` and enter `https://github.com/focus-creative-games/hybridclr_unity.git` to install.

### Settings

- Open the settings page from the `LeanCLR/Settings` menu. Currently, only enabling or disabling this plugin is supported.

### Build

No manual action is required. This plugin automatically replaces il2cpp with leanclr when building for WebGL or mini-game platforms.

## Related repositories

| Repository | Description |
|------|------|
| [leanclr4unity](https://github.com/focus-creative-games/leanclr4unity) | This Unity Package (Editor integration and release workflow) |
| [leanclr](https://github.com/focus-creative-games/leanclr) | LeanCLR runtime and toolchain (C++17, zero external dependencies) |

## Support and contact

- Email: `leanclr#code-philosophy.com`
- Discord: <https://discord.gg/esAYcM6RDQ>
- QQ Group: 1047250380

## License

Released under the [MIT License](https://github.com/focus-creative-games/leanclr4unity/blob/main/LICENSE).
