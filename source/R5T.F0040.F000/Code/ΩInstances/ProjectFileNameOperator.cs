using System;


namespace R5T.F0040.F000
{
    public class ProjectFileNameOperator : IProjectFileNameOperator
    {
        #region Infrastructure

        public static IProjectFileNameOperator Instance { get; } = new ProjectFileNameOperator();


        private ProjectFileNameOperator()
        {
        }

        #endregion
    }
}
