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
                this.GetDocumentationFileName_FromProjectName);

            return output;
        }

        public string GetDocumentationFilePath_ForAssemblyFilePath(string assemblyFilePath)
        {
            var documentationFileName = this.GetDocumentationFileName_FromAssemblyFilePath(assemblyFilePath);

            var directoryPath = F0002.PathOperator.Instance.GetParentDirectoryPath_ForFile(assemblyFilePath);

            var documentationFilePath = F0002.PathOperator.Instance.GetFilePath(
                directoryPath,
                documentationFileName);

            return documentationFilePath;
        }

        public string GetDocumentationFileName_FromProjectName(string projectName)
        {
            var documentationFileName = F0000.FileNameOperator.Instance.GetFileName(
                projectName,
                F0000.FileExtensions.Instance.Xml);

            return documentationFileName;
        }

        public string GetDocumentationFileName_FromAssemblyFilePath(string assemblyFilePath)
        {
            var assemblyName = F0002.PathOperator.Instance.GetFileNameStem(assemblyFilePath);

            var documentationFileName = F0000.FileNameOperator.Instance.GetFileName(
                assemblyName,
                F0000.FileExtensions.Instance.Xml);

            return documentationFileName;
        }

        public string GetDocumentationFileName_FromProjectFilePath(string projectFilePath)
        {
            // Same as assembly file name.
            var output = this.GetDocumentationFileName_FromAssemblyFilePath(projectFilePath);
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