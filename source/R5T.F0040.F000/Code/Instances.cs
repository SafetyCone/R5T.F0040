using System;


namespace R5T.F0040.F000
{
    public static class Instances
    {
        public static L0066.IFileNameOperator FileNameOperator => L0066.FileNameOperator.Instance;
        public static L0066.IPathOperator PathOperator { get; } = L0066.PathOperator.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = F000.ProjectPathsOperator.Instance;
    }
}