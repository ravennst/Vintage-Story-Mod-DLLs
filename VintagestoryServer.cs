
// C:\Users\Liner\AppData\Roaming\Vintagestory\VintagestoryServer.dll
// VintagestoryServer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// Global type: <Module>
// Entry point: Vintagestory.ServerWindows.Main
// Architecture: x64
// Runtime: v4.0.30319
// This assembly was compiled using the /deterministic option.
// Hash algorithm: SHA1
// Debug info: Loaded from portable PDB: C:\Users\Liner\AppData\Roaming\Vintagestory\VintagestoryServer.pdb

using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Vintagestory.Server;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("Vintagestory Standalone Server")]
[assembly: AssemblyDescription("www.vintagestory.at")]
[assembly: AssemblyCompany("Tyron Madlener (Anego Studios)")]
[assembly: AssemblyProduct("Vintage Story")]
[assembly: AssemblyCopyright("Copyright © 2016-2024 Anego Studios")]
[assembly: ComVisible(false)]
[assembly: Guid("f2185540-59e6-44a5-9862-678ee2cb0a65")]
[assembly: AssemblyFileVersion("1.21.6")]
[assembly: TargetFramework(".NETCoreApp,Version=v8.0", FrameworkDisplayName = ".NET 8.0")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
[module: RefSafetyRules(11)]
namespace Vintagestory;

public class ServerWindows
{
	private static void Main(string[] args)
	{
		ServerProgram.Main(args);
	}
}
