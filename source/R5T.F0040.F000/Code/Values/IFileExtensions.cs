using System;

using R5T.T0131;


namespace R5T.F0040.F000
{
    [ValuesMarker]
    public partial interface IFileExtensions : IValuesMarker
    {
        public string CSharpProjectFile => "csproj";
    }
}
