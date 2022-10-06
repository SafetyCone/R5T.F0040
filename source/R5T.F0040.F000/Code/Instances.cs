using System;

using R5T.F0002;


namespace R5T.F0040.F000
{
    public static class Instances
    {
        public static IPathOperator PathOperator { get; } = F0002.PathOperator.Instance;
        public static IProjectPathsOperator ProjectPathsOperator { get; } = F000.ProjectPathsOperator.Instance;
    }
}