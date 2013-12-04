using System.Reflection;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle( "SQL" )]
[assembly: AssemblyProduct( "SQL" )]
[assembly: AssemblyDescription( "Simple and fluent SQL helpers. (Alpha version)" )]

[assembly: AssemblyCompany( "Carlos J. López - twitter/carlosjln" )]
[assembly: AssemblyCopyright( "Copyright © 2012" )]
[assembly: AssemblyTrademark( "" )]

[assembly: AssemblyVersion( "1.0.0.1" )]
//[assembly: AssemblyFileVersion( "1.0.0.1" )]
//[assembly: AssemblyInformationalVersion("1.0.0.1")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#else
[assembly: AssemblyConfiguration("Release")]
#endif

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid( "5433FB96-273E-4993-9B89-102D267A1130" )]