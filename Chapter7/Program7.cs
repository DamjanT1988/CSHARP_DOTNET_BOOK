//--CHAPTER 7 - UNDERSTA´NDING AND PACKAGING .NET TYPES


//understanding .NET core components 227

/*
 .NET Core is made up of several pieces, which are as follows:
• Language compilers: These turn your source code written with languages
such as C#, F#, and Visual Basic into intermediate language (IL) code stored
in assemblies. With C# 6.0 and later, Microsoft switched to an open source
rewritten compiler known as Roslyn that is also used by Visual Basic.
• Common Language Runtime (CoreCLR): This runtime loads assemblies,
compiles the IL code stored in them into native code instructions for your
computer's CPU, and executes the code within an environment that manages
resources such as threads and memory.
• Base Class Libraries (BCL) of assemblies in NuGet packages (CoreFX):
These are prebuilt assemblies of types packaged and distributed using NuGet
for performing common tasks when building applications.
• You can use them to quickly build anything you want rather like combining
LEGO™ pieces. .NET Core 2.0 implemented .NET Standard 2.0, which is a
superset of all previous versions of .NET Standard, and lifted .NET Core up
to parity with .NET Framework and Xamarin. .NET Core 3.0 implements
.NET Standard 2.1, which adds new capabilities and enables performance
improvements beyond those available in .NET Framework.
 */