/****************************************************************************************************
*  Author: Mikkel Højer Jensen (mikk4388@edu.campusvejle.dk), github: https://github.com/MikkelHoier*
*  Solution: .NET version: 4.7.1, C# version: 7.1                                                   *
*  Visual Studio version: Visual Studio Enterprise 2017, version 15.4.5                             *
*  Repository: https://github.com/Mara-AspIT/AspIT.BoardManagement                                  *
*****************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspIT.BoardManagement.Entities
{
	public class Secretary
	{
		#region Fields
		/// <summary>The current <see cref="Summary"/> that the <see cref="Secretary"/> is working on</summary>
		protected Summary current;
		#endregion


		#region Overrides
		public override string ToString()
		{
			return base.ToString();
		}
		#endregion
	}
}
