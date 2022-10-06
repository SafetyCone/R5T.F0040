using System;


namespace R5T.F0040
{
	public class ProjectDirectoryRelativePaths : IProjectDirectoryRelativePaths
	{
		#region Infrastructure

	    public static IProjectDirectoryRelativePaths Instance { get; } = new ProjectDirectoryRelativePaths();

	    private ProjectDirectoryRelativePaths()
	    {
        }

	    #endregion
	}
}