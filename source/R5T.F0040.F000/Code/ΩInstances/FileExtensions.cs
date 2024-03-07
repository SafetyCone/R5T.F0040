using System;


namespace R5T.F0040.F000
{
    public class FileExtensions : IFileExtensions
    {
        #region Infrastructure

        public static IFileExtensions Instance { get; } = new FileExtensions();


        private FileExtensions()
        {
        }

        #endregion
    }
}
