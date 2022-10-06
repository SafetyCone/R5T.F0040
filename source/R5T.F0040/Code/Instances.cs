using System;

using R5T.F0002;


namespace R5T.F0040
{
    public static class Instances
    {
        public static IPathOperator PathOperator { get; } = F0002.PathOperator.Instance;
        public static IProjectDirectoryRelativePaths ProjectDirectoryRelativePaths { get; } = F0040.ProjectDirectoryRelativePaths.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = F0040.ProjectPathsOperator.Instance;
    }
}