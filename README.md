# Vintage Story — Decompiled DLL Reference

> **This repository is for modding reference only.**
> All content is the intellectual property of Anego Studios. See [LICENSE.md](LICENSE.md) for full terms.

---

## Overview

This repository contains decompiled C# source files derived from Vintage Story game binaries, maintained as a reference resource for mod development. It also includes setup documentation for configuring a VS modding environment in Visual Studio Code.

Decompiled files are an approximation of the original source and may not perfectly reflect the original implementation. They are provided here because the VS API documentation alone is often insufficient for understanding internal game behaviour — particularly when writing Harmony patches or working with systems not exposed by the public API.

---

## Contents

### Decompiled Binaries

| File | Description |
|---|---|
| `VintagestoryLib.cs` | Core engine library — closed source, decompiled. Contains most internal game systems. |
| `VintagestoryAPI.cs` | Decompiled version of the public API module. |
| `VSSurvivalMod.cs` | Decompiled survival mod — includes rift, stability, and mob spawning systems. |
| `VSEssentials.cs` | Decompiled essentials mod. |
| `VintagestoryServer.cs` | Decompiled server binary. |
| `Vintagestory.cs` | Launcher entry point — minimal content. |

### Documentation

| File | Description |
|---|---|
| `VSCode_Modding_Setup.md` | Step-by-step guide for setting up a Vintage Story modding environment in VS Code. |
| `VS_Modding_Setup_Guide.docx` | Word document version of the setup guide. |

---

## Official Sources

For files where official source is available, prefer the Anego Studios repositories:

- **VS API:** https://github.com/anegostudios/vsapi
- **Survival Mod:** https://github.com/anegostudios/vssurvivalmod
- **Essentials Mod:** https://github.com/anegostudios/vsessentialsmod
- **Mod Template:** https://github.com/anegostudios/vsmodtemplate
- **Mod Examples:** https://github.com/anegostudios/vsmodexamples
- **API Reference Docs:** https://apidocs.vintagestory.at

The decompiled files in this repo are most useful for `VintagestoryLib.dll`, which has no official public source.

---

## Usage Notes

- Files were decompiled using [ILSpy](https://github.com/icsharpcode/ILSpy) or [dnSpy](https://github.com/dnSpy/dnSpy)
- Decompiled code is readable but may contain artifacts — local variable names in particular may differ from the originals
- Files will be updated periodically as the game receives major updates
- Game version at time of last update is noted in commit history

---

## Legal

All Vintage Story game code, assets, and intellectual property belong exclusively to **Anego Studios** (Tyron Madlener). This repository exists with respect for the VS modding community's practices and Anego Studios' general support of modding. If requested by Anego Studios, this repository will be removed immediately.

See [LICENSE.md](LICENSE.md) for full terms.
