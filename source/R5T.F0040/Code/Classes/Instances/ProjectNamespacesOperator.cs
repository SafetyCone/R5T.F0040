using System;


namespace R5T.F0040
{
	public class ProjectNamespacesOperator : IProjectNamespacesOperator
	{
		#region Infrastructure

	    public static IProjectNamespacesOperator Instance { get; } = new ProjectNamespacesOperator();

	    private ProjectNamespacesOperator()
	    {
        }

	    #endregion
	}
}