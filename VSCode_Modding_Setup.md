# Modding:Setting up VS Code for Code Mods

*From Vintage Story Wiki (Community Supplement)*

---

> **Note:** This guide is a community-written supplement to the official wiki, covering setup for **Visual Studio Code** on **Windows 10/11**.
> The official *Preparing For Code Mods* and *Creating A Code Mod* tutorials assume you are using Visual Studio Community. If you prefer VS Code, follow this guide instead.
>
> This guide was written for **Vintage Story 1.21.x** (stable), which requires **.NET 8**. If you are targeting the 1.22 RC or later, replace every reference to `.NET 8` with `.NET 10`.

---

## Contents

1. [Why VS Code](#1-why-vs-code)
2. [What You Need](#2-what-you-need)
3. [Step 1 — Install VS Code and Extensions](#step-1--install-vs-code-and-extensions)
4. [Step 2 — Install the .NET 8 SDK](#step-2--install-the-net-8-sdk)
5. [Step 3 — Set the VINTAGE_STORY Environment Variable](#step-3--set-the-vintage_story-environment-variable)
6. [Step 4 — Get the Mod Template](#step-4--get-the-mod-template)
7. [Step 5 — Rename the Template for Your Mod](#step-5--rename-the-template-for-your-mod)
8. [Step 6 — Open the Project in VS Code](#step-6--open-the-project-in-vs-code)
9. [Step 7 — Build and Launch Your Mod](#step-7--build-and-launch-your-mod)
10. [Step 8 — Package Your Mod for Release](#step-8--package-your-mod-for-release)
11. [Updating the .NET Target Framework](#updating-the-net-target-framework)
12. [Troubleshooting](#troubleshooting)
13. [Moving Forward](#moving-forward)

---

## 1. Why VS Code

Visual Studio Code is a free, lightweight, and cross-platform code editor. While the official tutorials use Visual Studio Community (Windows-only), VS Code is a fully supported IDE for Vintage Story modding and is widely used in the modding community. It is also the recommended option for Linux users.

> **Recommendation:** If you are on Windows and have no strong preference, the official Visual Studio Community workflow is slightly more seamless for first-time setup. VS Code is an excellent choice if you prefer a lighter editor, are on Linux, or simply prefer VS Code's workflow.

---

## 2. What You Need

Before starting, make sure you have or can obtain the following:

| Item | Notes |
|---|---|
| **Visual Studio Code** | Free download at code.visualstudio.com |
| **.NET 8 SDK** | Required for VS 1.21.x. Free from Microsoft. |
| **Vintage Story** | Installed on your machine |
| **Git** (optional) | Recommended for cloning the template |

> **Which .NET version?**
> - Vintage Story **1.21.x (stable)** → **.NET 8**
> - Vintage Story **1.22+** → **.NET 10**
>
> The `.NET 7` references on some wiki pages are outdated. Do not install .NET 7 for a new setup.

---

## Step 1 — Install VS Code and Extensions

### Install VS Code

Download and install Visual Studio Code from:
**https://code.visualstudio.com/**

Accept the default installation options. On Windows, it is useful to check **"Add to PATH"** and **"Add 'Open with Code' action"** during setup.

### Install Required Extensions

Once VS Code is open, press `Ctrl+Shift+X` to open the Extensions panel. Search for and install the following:

**C# Dev Kit** *(Publisher: Microsoft)*

> **Important:** Install **C# Dev Kit**, not just the base "C#" extension. C# Dev Kit is the current Microsoft-supported package and includes IntelliSense, solution explorer support, and the debugger. The older OmniSharp-based C# extension is legacy and may cause issues.

No other extensions are strictly required to get started, though **NuGet Package Manager** and **GitLens** are popular community additions.

---

## Step 2 — Install the .NET 8 SDK

Download the **.NET 8 SDK** from:
**https://dotnet.microsoft.com/en-us/download/dotnet/8.0**

Select the **Windows x64** installer unless you know you need a different version.

After installation, verify it is working. Open **Windows PowerShell** and run:

```powershell
dotnet --list-sdks
```

You should see at least one entry beginning with `8.0.`. For example:

```
8.0.404 [C:\Program Files\dotnet\sdk]
```

> **SDK not listed?**
> Restart your PC and run the command again. If it is still missing, repeat the SDK installation.

---

## Step 3 — Set the VINTAGE_STORY Environment Variable

The mod template uses a `VINTAGE_STORY` environment variable to locate your game installation. This needs to be set once.

### Find Your Vintage Story Installation Folder

The default installation path is:

```
C:\Users\<YourUsername>\AppData\Roaming\Vintagestory
```

You can navigate there quickly by typing `%appdata%` into the Windows Explorer address bar and pressing Enter. Look for the `Vintagestory` folder (not `VintagestoryData` — that folder holds saves and settings, not the game itself).

Confirm you are in the correct folder — it should contain sub-folders named `assets`, `lib`, and `mods`.

> **Custom install location?**
> If you installed Vintage Story somewhere other than the default path, substitute your actual installation path in the command below.

### Set the Variable via PowerShell

Open the folder containing your Vintage Story installation in File Explorer. Then open PowerShell **inside that folder**:

- **Windows 10:** Click **File** in the menu bar → **Open Windows PowerShell**
- **Windows 11:** Right-click inside the folder (with nothing selected) → **Open in Terminal**

Run the following command:

```powershell
[Environment]::SetEnvironmentVariable("VINTAGE_STORY", ($pwd.path), "User")
```

This sets `VINTAGE_STORY` to the folder you currently have open in PowerShell.

### Verify the Variable

Open a **new** PowerShell window and run:

```powershell
echo $env:VINTAGE_STORY
```

It should print the full path to your Vintage Story folder. If it does not, repeat this step.

> **Restart recommended:** After setting a new environment variable, restart your PC to ensure VS Code and all other programs pick it up correctly.

---

## Step 4 — Get the Mod Template

> **Why not `dotnet new vsmod`?**
> The NuGet-based template installer (`dotnet new install VintageStory.Mod.Templates`) has had availability and versioning issues and may fail with an error. The method below — cloning the template repository directly — is more reliable and gives you the same files.

### Option A: Clone with Git (Recommended)

Open PowerShell in the folder where you want to store your mods and run:

```powershell
git clone https://github.com/anegostudios/vsmodtemplate.git MyModName
```

Replace `MyModName` with your chosen project folder name.

### Option B: Download as ZIP

1. Go to **https://github.com/anegostudios/vsmodtemplate**
2. Click the green **Code** button → **Download ZIP**
3. Extract the ZIP to your preferred location and rename the extracted folder to your mod name

---

## Step 5 — Rename the Template for Your Mod

The template uses placeholder names that need to be updated before you start coding.

### Mod ID and Naming Rules

Your mod ID must:
- Contain only **lowercase letters and numbers** (no spaces, hyphens, or underscores)
- Be **unique** on the VS Mod DB if you plan to publish

### Files to Edit

Open the template folder. You will need to rename and edit the following:

**1. Rename the project folder**

Rename the `ModTemplate` folder to your mod name in PascalCase (e.g. `MyFirstMod`).

**2. Rename the `.csproj` file**

Inside that folder, rename `ModTemplate.csproj` to match (e.g. `MyFirstMod.csproj`).

**3. Edit `modinfo.json`**

Located at `ModTemplate/assets/modtemplate/modinfo.json` (path will reflect your renamed folder).

```json
{
  "type": "code",
  "modid": "myfirstmod",
  "name": "My First Mod",
  "authors": [ "YourName" ],
  "description": "A short description of your mod.",
  "version": "1.0.0",
  "dependencies": {
    "game": ""
  }
}
```

Set `modid` to your lowercase mod ID and fill in the other fields.

**4. Edit the `.csproj` file**

Open the renamed `.csproj` file in a text editor and check the `TargetFramework` line:

```xml
<TargetFramework>net7.0</TargetFramework>
```

If it says `net7.0`, change it to `net8.0`:

```xml
<TargetFramework>net8.0</TargetFramework>
```

> **This step is important.** The template was originally written for .NET 7. If you skip this, your mod will build against the wrong runtime and may fail to load in Vintage Story 1.21.

**5. Update `ModTemplate.sln`**

Open `ModTemplate.sln` in a text editor. It references `ModTemplate` by name in several places. You can either:
- Rename it to `MyFirstMod.sln` and do a find-and-replace of `ModTemplate` → `MyFirstMod`, or
- Leave it as-is — VS Code will still work correctly opening it, but the solution name will show as `ModTemplate` in the explorer.

---

## Step 6 — Open the Project in VS Code

Open VS Code, then use **File → Open Folder** and select the root of your template folder (the one containing the `.sln` file).

The C# Dev Kit extension will automatically detect the solution file and load the project. You may be prompted to select a solution — choose the `.sln` file at the root.

Allow a moment for the extension to restore NuGet packages and index the project. You will see status messages in the bottom status bar. IntelliSense and code completion will become active once this is complete.

> **IntelliSense not working after the project loads?**
> Press `F1` to open the Command Palette and run **"Reload Window"**. The C# language server sometimes needs a restart after initially loading a new project.

### Verify the .vscode Folder

The template includes a `.vscode` folder at the project root containing pre-configured `launch.json` and `tasks.json` files. These tell VS Code how to build your mod and launch Vintage Story with it attached.

You do not need to edit these files for a standard setup on Windows. They reference `$(VINTAGE_STORY)` which will be resolved from the environment variable you set in Step 3.

---

## Step 7 — Build and Launch Your Mod

### Build

Press `Ctrl+Shift+B` to run the default build task, or go to **Terminal → Run Build Task**.

A successful build will produce a `.dll` file inside the `bin/` subfolder of your mod project.

### Launch with Debugging

Press `F5` or go to the **Run and Debug** panel (`Ctrl+Shift+D`) and select the **"Launch Client"** configuration from the dropdown, then press the green play button.

This will:
1. Build your mod
2. Copy the output to Vintage Story's mods folder
3. Launch Vintage Story with your mod loaded

Once the game loads to the main menu, open the **Mod Manager** to verify your mod appears in the list.

> **Game not launching?**
> Check that the `VINTAGE_STORY` environment variable is set correctly (Step 3) and that VS Code was opened **after** the variable was set (or after a PC restart). Environment variables set while VS Code is open will not be picked up until VS Code is restarted.

---

## Step 8 — Package Your Mod for Release

When you are ready to create a distributable `.zip` of your mod, VS Code uses the Cake build system included in the template.

Go to **Terminal → Run Task...** and select **package**.

This will:
- Validate all JSON asset files for correct syntax
- Build the mod in Release configuration
- Produce a `Releases/mymodid_1.0.0.zip` file ready to upload to the VS Mod DB

The version number in the output filename is taken from your `modinfo.json`.

---

## Updating the .NET Target Framework

When Vintage Story updates to a new .NET version, you will need to update your project to match. Signs that this is needed include build errors about framework incompatibility or the mod failing to load after a game update.

Open your `.csproj` file and find:

```xml
<TargetFramework>net8.0</TargetFramework>
```

Replace `net8.0` with the version the game now requires. As of writing:

| Game Version | Required .NET |
|---|---|
| 1.21.x (stable) | `net8.0` |
| 1.22+ | `net10.0` |

After changing this line, rebuild the project.

---

## Troubleshooting

### "The VINTAGE_STORY variable is not set" or build cannot find game DLLs

- Confirm the variable is set by running `echo $env:VINTAGE_STORY` in a new PowerShell window
- Restart VS Code (or your PC) after setting the variable
- Make sure the path points to the game folder itself (containing `assets`, `lib`, `mods`) and not to `VintagestoryData`

### NuGet restore fails / packages cannot be found

Run the following in PowerShell to ensure the NuGet source is registered:

```powershell
dotnet nuget add source "https://api.nuget.org/v3/index.json" --name "nuget.org"
```

Then re-open VS Code or run **Terminal → Run Task → restore**.

### IntelliSense shows errors on valid code

- Wait for the C# Dev Kit to finish indexing (watch the status bar)
- Run `F1` → **"Reload Window"**
- If errors persist, run `F1` → **".NET: Restart Language Server"**

### Mod appears in Mod Manager but does not do anything

- Confirm the `modid` in `modinfo.json` is all lowercase with no spaces
- Check the in-game **Mod Manager** error log for load errors
- Check `%appdata%\VintagestoryData\Logs\server-main.txt` for exception output

### Build succeeds but game launches vanilla (mod not loaded)

- Confirm the build is copying output to the correct mods folder. Check `launch.json` — the `postBuildEvent` should reference `$(VINTAGE_STORY)\Mods`
- Alternatively, manually copy the `.dll` and `modinfo.json` into `%appdata%\VintagestoryData\Mods` and launch the game normally to test

---

## Moving Forward

With your environment set up, you are ready to begin writing mod code. The following resources are recommended next steps:

- **[Modding:Code Tutorial Essentials](https://wiki.vintagestory.at/Modding:Code_Tutorial_Essentials)** — important concepts before starting the tutorials
- **[Modding:Basic Code Tutorials](https://wiki.vintagestory.at/Modding:Basic_Code_Tutorials)** — beginner code tutorials (blocks, items, commands)
- **[Vintage Story API Docs](https://apidocs.vintagestory.at)** — full API reference
- **[VS Mod DB](https://mods.vintagestory.at)** — browse existing mods for reference implementations
- **[Official Discord](https://discord.gg/Tndr3w8)** — the `#mod-dev` channel is active and helpful

> **Decompiling game code:** To understand how existing game systems work, use **ILSpy** or **dnSpy** to decompile the game DLLs found in your `$(VINTAGE_STORY)/Lib` folder. This is essential for writing Harmony patches or extending built-in systems.

---

*This guide covers Vintage Story 1.21.x with .NET 8 and VS Code. For the official Visual Studio setup, see [Modding:Preparing For Code Mods](https://wiki.vintagestory.at/Modding:Preparing_For_Code_Mods).*
