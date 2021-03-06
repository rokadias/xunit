#if !PLATFORM_DOTNET

using System.CodeDom.Compiler;
using System.IO;
using Xunit;

public class AcceptanceTestV2Assembly : AcceptanceTestAssembly
{
    private AcceptanceTestV2Assembly() { }

    protected override void AddStandardReferences(CompilerParameters parameters)
    {
        base.AddStandardReferences(parameters);

        parameters.ReferencedAssemblies.Add(Path.Combine(BasePath, "xunit.core.dll"));
        parameters.ReferencedAssemblies.Add(Path.Combine(BasePath, "xunit.execution.desktop.dll"));
    }

    public static AcceptanceTestV2Assembly Create(string code, params string[] references)
    {
        var assembly = new AcceptanceTestV2Assembly();
        assembly.Compile(code, references);
        return assembly;
    }
}

#endif
