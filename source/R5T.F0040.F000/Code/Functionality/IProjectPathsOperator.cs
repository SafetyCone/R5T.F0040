using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0132;


namespace R5T.F0040.F000 /// <see cref="R5T.F0040.F000.Documentation"/>
{
    [FunctionalityMarker]
	public partial interface IProjectPathsOperator : IFunctionalityMarker
	{
        public string Get_ProjectFilePath(
            string projectDirectoryPath,
            string projectName)
        {
            var projectFileName = Instances.ProjectFileNameOperator.Get_ProjectFileName_FromProjectName(projectName);

            var projectFilePath = Instances.PathOperator.Get_FilePath(
                projectDirectoryPath,
                projectFileName);

            return projectFilePath;
        }

        /// <summary>
        /// Gets the project directory path from the project file path.
        /// <inheritdoc cref="Documentation.ProjectDirectory"/>
        /// </summary>
        public string GetProjectDirectoryPath(string projectFilePath)
		{
			var projectDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(projectFilePath);
			return projectDirectoryPath;
		}

		/// <summary>
		/// Chooses <see cref="Enumerate_ProjectDirectoryPaths_Distinct(IEnumerable{string})"/> as the default.
		/// </summary>
		public IEnumerable<string> Enumerate_ProjectDirectoryPaths(IEnumerable<string> projectFilePaths)
			=> this.Enumerate_ProjectDirectoryPaths_Distinct(projectFilePaths);

		/// <inheritdoc cref="Enumerate_ProjectDirectoryPaths(IEnumerable{string})"/>
		public string[] Get_ProjectDirectoryPaths(IEnumerable<string> projectFilePaths)
			=> this.Enumerate_ProjectDirectoryPaths(projectFilePaths)
				.Now();

        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_Distinct(IEnumerable<string> projectFilePaths)
			=> this.Enumerate_ProjectDirectoryPaths_NonDistinct(projectFilePaths)
				.Distinct();

        public IEnumerable<string> Enumerate_ProjectDirectoryPaths_NonDistinct(IEnumerable<string> projectFilePaths)
			=> projectFilePaths.Select(this.GetProjectDirectoryPath);

		/// <summary>
		/// For a path (either a directory or file path), get the relative path to the directory or file, relative to the project directory path.
		/// This is useful since Visual Studio interprets most project-related paths as relative to the project directory, not project file.
		/// </summary>
		/// <param name="path">Either a directory or file path.</param>
		public string GetProjectDirectoryRelativePath(
			string projectFilePath,
			string path)
		{
			var projectDirectoryPath = this.GetProjectDirectoryPath(projectFilePath);

			var projectDirectoryRelativeFilePath = Instances.PathOperator.Get_RelativePath(
				projectDirectoryPath,
				path);

			return projectDirectoryRelativeFilePath;
		}

		/// <inheritdoc cref="GetProjectDirectoryRelativePath(string, string)"/>
		public Dictionary<string, string> GetProjectDirectoryRelativePaths(
			string projectFilePath,
			IEnumerable<string> paths)
		{
			var projectDirectoryPath = this.GetProjectDirectoryPath(projectFilePath);

			var projectDirectoryRelativePathsByPath = Instances.PathOperator.Get_RelativePaths(
				projectDirectoryPath,
				paths);

			return projectDirectoryRelativePathsByPath;
		}

		/// <summary>
		/// For a project directory relative path (either a directory or file path), combine the relative path and the project directory path to get the directory or file path.
		/// </summary>
		public string Get_Path_ForProjectDirectoryRelativePath(
			string projectFilePath,
			string projectDirectoryRelativePath)
        {
			var projectDirectoryPath = this.GetProjectDirectoryPath(projectFilePath);

			var projectDirectoryRelativeFilePath = Instances.PathOperator.Combine(
				projectDirectoryPath,
				projectDirectoryRelativePath);

			return projectDirectoryRelativeFilePath;
		}

		public string GetProjectFileName(string projectFilePath)
		{
			var projectFileName = Instances.PathOperator.Get_FileName(projectFilePath);
			return projectFileName;
		}

		/// <summary>
		/// Gets the name of the project from the file name of the project.
		/// <para>
		/// Note: does not examine the project file contents, so the file does not have to exist.
		/// </para>
		/// </summary>
		public string GetProjectName(string projectFilePath)
		{
			var projectFileName = this.GetProjectFileName(projectFilePath);

			var projectName = Instances.FileNameOperator.Get_FileNameStem(projectFileName);
			return projectName;
		}
	}
}