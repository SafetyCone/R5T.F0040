using System;

using R5T.T0131;


namespace R5T.F0040
{
	[ValuesMarker]
	public partial interface IProjectDirectoryRelativePaths : IValuesMarker
	{
        /// <summary>
        /// <para>Assumes the debug build configuration, and .NET 6.0.</para>
        /// "bin\Debug\net6.0\"
        /// </summary>
        public string DefaultOutputBinariesDirectoryRelativePath => @"bin\Debug\net6.0\";
	}
}