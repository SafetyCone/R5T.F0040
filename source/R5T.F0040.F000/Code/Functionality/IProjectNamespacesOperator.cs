using System;

using R5T.T0132;


namespace R5T.F0040.F000
{
	[FunctionalityMarker]
	public partial interface IProjectNamespacesOperator : IFunctionalityMarker
	{
		public string Get_DefaultNamespaceName_FromProjectName(string projectName)
		{
			// The default namespace name is just the project name.
			var defaultNamespaceName = projectName;
			return defaultNamespaceName;
		}

		public string Get_DefaultNamespaceName_FromProjectFilePath(string projectFilePath)
		{
			var projectName = Instances.ProjectPathsOperator.GetProjectName(projectFilePath);

			var defaultNamespaceName = this.Get_DefaultNamespaceName_FromProjectName(projectName);
			return defaultNamespaceName;
		}

		/// <summary>
		/// Chooses <see cref="Get_DefaultNamespaceName_FromProjectFilePath(string)"/> as the default.
		/// </summary>
		public string Get_DefaultNamespaceName(string projectFilePath)
		{
			var defaultNamespaceName = this.Get_DefaultNamespaceName_FromProjectFilePath(projectFilePath);
			return defaultNamespaceName;
		}
	}
}