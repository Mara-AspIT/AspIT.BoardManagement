/*********************************************************************************************
*  Author: Emil Georgi (emil376g@edu.campusvejle.dk), github: https://github.com/emil376g/   *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                            *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                      *
*  Repository: https://github.com/Mara-AspIT/AspIT.Bms.git                                   *
*********************************************************************************************/


namespace AspIT.BoardManagement.Entities
{
    /// <summary>
    /// Its for the things there are going into the database
    /// </summary>
    public interface IPersistable
    {
        int Id { get; }
    }
}
