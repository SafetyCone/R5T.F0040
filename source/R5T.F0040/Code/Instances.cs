using System;


namespace R5T.F0040
{
    public static class Instances
    {
        public static Z0072.Z002.IFileExtensions FileExtensions => Z0072.Z002.FileExtensions.Instance;
        public static L0066.IFileNameOperator FileNameOperator => L0066.FileNameOperator.Instance;
        public static L0066.IFileSystemOperator FileSystemOperator => L0066.FileSystemOperator.Instance;
        public static L0066.IPathOperator PathOperator { get; } = L0066.PathOperator.Instance;
        public static IProjectDirectoryRelativePaths ProjectDirectoryRelativePaths { get; } = F0040.ProjectDirectoryRelativePaths.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = F0040.ProjectPathsOperator.Instance;
    }
}