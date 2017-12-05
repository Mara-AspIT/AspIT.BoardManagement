/**************************************************************************************************
*  Author: Mads Mikkel Rasmussen (mara@aspit.dk), github: https://github.com/Mara-AspIT/          *
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                 *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                           *
*  Repository: https://github.com/Mara-AspIT/AspIT.Bms.git                                        *
**************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspIT.BoardManagement.Entities
{
    /// <summary>The kind of vote</summary>
    public enum VoteKind
    {
        /// <summary>The vote kind cast when in favor.</summary>
        Yay,

        /// <summary>The vote kind cast when not in favor.</summary>
        Nay,

        /// <summary>The vote kind cast when neither in favor or not in favor.</summary>
        Blank
    }
}