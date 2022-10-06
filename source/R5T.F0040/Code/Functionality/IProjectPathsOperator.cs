using System;

using R5T.T0132;


namespace R5T.F0040
{
	[FunctionalityMarker]
	public partial interface IProjectPathsOperator : IFunctionalityMarker,
		F000.IProjectPathsOperator
	{
        /// <summary>
        /// Gets the output directory file path for a project file path and a file name based on the project name.
        /// </summary>
        public string GetOutputBinariesDirectoryFilePathForProject(
            string projectFilePath,
            Func<string, string> getFileNameFromProjectName)
        {
            var projectFileExists = F0000.FileSystemOperator.Instance.FileExists(projectFilePath);

            var projectDirectoryPath = this.GetProjectDirectoryPath(projectFilePath);

            string GetBinariesOutputDirectoryRelativePath()
            {
                var hasTargetFramework = F0020.ProjectFileOperator.Instance.HasTargetFramework(projectFilePath);

                var targetFramework = hasTargetFramework.ResultOrIfNotFound(
                    F0020.TargetFrameworkMonikerStrings.Instance.Default);

                var binariesOutputDirectoryRelativePath = $@"bin\Debug\{targetFramework}\";
                return binariesOutputDirectoryRelativePath;
            }

            var binariesOutputDirectoryRelativePath = projectFileExists
                ? GetBinariesOutputDirectoryRelativePath()
                : Instances.ProjectDirectoryRelativePaths.DefaultOutputBinariesDirectoryRelativePath
                ;

            var binariesDirectoryPath = Instances.PathOperator.GetDirectoryPath(
                projectDirectoryPath,
                binariesOutputDirectoryRelativePath);

            var projectName = Instances.PathOperator.GetFileNameStem(projectFilePath);

            var fileName = getFileNameFromProjectName(projectName);

            var output = Instances.PathOperator.GetFilePath(
                binariesDirectoryPath,
                fileName);

            return output;
        }

        /// <summary>
        /// Gets the output documentation XML file path for a project file path (in the output directory).
        /// </summary>
        public string GetDocumentationFilePathForProjectFilePath(string projectFilePath)
        {
            var output = this.GetOutputBinariesDirectoryFilePathForProject(
                projectFilePath,
                projectName => $"{projectName}.xml");

            return output;
        }

        /// <summary>
        /// Gets the output assembly file path for a project file path (in the output directory).
        /// </summary>
        public string GetAssemblyFilePathForProjectFilePath(string projectFilePath)
        {
            var output = this.GetOutputBinariesDirectoryFilePathForProject(
                projectFilePath,
                projectName => $"{projectName}.dll");

            return output;
        }
    }
}