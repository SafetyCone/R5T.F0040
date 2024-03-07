using System;


namespace R5T.F0040.F000
{
    public static class Instances
    {
        public static L0066.IFileExtensionOperator FileExtensionOperator => L0066.FileExtensionOperator.Instance;
        public static IFileExtensions FileExtensions => F000.FileExtensions.Instance;
        public static L0066.IFileNameOperator FileNameOperator => L0066.FileNameOperator.Instance;
        public static L0066.IPathOperator PathOperator { get; } = L0066.PathOperator.Instance;
        public static IProjectFileNameOperator ProjectFileNameOperator => F000.ProjectFileNameOperator.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = F000.ProjectPathsOperator.Instance;
    }
}