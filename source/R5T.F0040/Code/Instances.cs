using System;


namespace R5T.F0040
{
    public static class Instances
    {
        public static L0066.IPathOperator PathOperator { get; } = L0066.PathOperator.Instance;
        public static IProjectDirectoryRelativePaths ProjectDirectoryRelativePaths { get; } = F0040.ProjectDirectoryRelativePaths.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = F0040.ProjectPathsOperator.Instance;
    }
}