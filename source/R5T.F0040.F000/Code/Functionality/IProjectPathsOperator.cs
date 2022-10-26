using System;
using System.Collections.Generic;

using R5T.T0132;


namespace R5T.F0040.F000
{
	[FunctionalityMarker]
	public partial interface IProjectPathsOperator : IFunctionalityMarker
	{
		/// <summary>
		/// Gets the project directory path from the project file path.
		/// <inheritdoc cref="Documentation.ProjectDirectory"/>
		/// </summary>
		public string GetProjectDirectoryPath(string projectFilePath)
		{
			var projectDirectoryPath = Instances.PathOperator.GetParentDirectoryPath_ForFile(projectFilePath);
			return projectDirectoryPath;
		}

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

			var projectDirectoryRelativeFilePath = Instances.PathOperator.GetRelativePath(
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

			var projectDirectoryRelativePathsByPath = Instances.PathOperator.GetRelativePaths(
				projectDirectoryPath,
				paths);

			return projectDirectoryRelativePathsByPath;
		}

		/// <summary>
		/// For a project directory relative path (either a directory or file path), combine the relative path and the project directory path to get the directory or file path.
		/// </summary>
		/// <param name="path">Either a directory or file path.</param>
		public string GetPath_ForProjectDirectoryRelativePath(
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
			var projectFileName = Instances.PathOperator.GetFileName(projectFilePath);
			return projectFileName;
		}

		public string GetProjectName(string projectFilePath)
		{
			var projectFileName = this.GetProjectFileName(projectFilePath);

			var projectName = F0000.FileNameOperator.Instance.GetFileNameStem(projectFileName);
			return projectName;
		}
	}
}