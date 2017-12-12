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
	/// <summary>Represents a summary of a boardmeeting. Can be inherited.</summary>
	public class Summary
	{
		#region Fields
		/// <summary>The content of the summary.</summary>
		protected string content;
		/// <summary>The date and time for that last edit.</summary>
		protected DateTime lastEdit;
		/// <summary>The date and time for the creation of the summary.</summary>
		protected DateTime creationDate;
		/// <summary>The unique id</summary>
		protected int id;
		#endregion


		#region Constructors
		/// <summary>Creates a new <see cref="Summary"/> object with the intend of making a completly new <see cref="Summary"/></summary>
		/// <param name="content">The content of the summary.</param>		
		public Summary(string content)
		{
			Content = content;
			CreationDate = DateTime.Now;
		}
		/// <summary>Creates a new <see cref="Summary"/> object with the intend of making it oof an already exsisting <see cref="Summary"/> from the database</summary>
		/// <param name="content">The content of the summary.</param>
		/// <param name="lastEdit">The date and time for that last edit.</param>
		/// <param name="creationDate">The date and time for the creation of the summary</param>
		public Summary(string content, DateTime lastEdit, DateTime creationDate)
		{
			Content = content;
			LastEdit = lastEdit;
			CreationDate = creationDate;
		}
		#endregion


		#region Properties	
		public string Content
		{
			get => content;
			set => content = value;
		}
		public DateTime LastEdit
		{
			get => lastEdit;
			set => lastEdit = value;
		}
		public DateTime CreationDate
		{
			get => creationDate;
			set => creationDate = value;
		}
		#endregion


		#region Methods
		/// <summary>Appends a string to the content while also adding a timestamp for when the method was called</summary>
		/// <param name="newContent">The content of the summary.</param>
		public void Append(string newContent)
		{
			content = content + newContent;
			lastEdit = DateTime.Now;
		}
		#endregion


		#region Overrides
		public override string ToString()
		{
			return $"{creationDate}";
		}


		public override bool Equals(object obj)
			=> Equals(obj as Summary);

		public override int GetHashCode()
		{
			var hashCode = -1541159169;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(content);
			hashCode = hashCode * -1521134295 + lastEdit.GetHashCode();
			hashCode = hashCode * -1521134295 + creationDate.GetHashCode();
			hashCode = hashCode * -1521134295 + id.GetHashCode();
			return hashCode;
		}
		#endregion
	}
}
